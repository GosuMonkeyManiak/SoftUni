const { chromium } = require('playwright-chromium');
const { assert } = require('chai');

const mockData = require('./mock-data.json');


let browser;
let context;
let page;

describe('E2E tests', function () {
    //this.timeout(6000);

    before(async () => {
        browser = await chromium.launch({ headless:false });
    });
    after(async () => {
        await browser.close();
    });

    beforeEach(async () => {
        context = await browser.newContext();

        // block intensive resources and external calls (page routes take precedence)
        await context.route('**/*.{png,jpg,jpeg}', route => route.abort());
        await context.route(url => {
            return url.hostname != 'localhost';
        }, route => route.abort());

        page = await context.newPage();
    });

    afterEach(async () => {
        await page.close();
        await context.close();
    });

    it('catelog Test', async () => {
        let recipes = mockData.recipes;

        await page.route('http://localhost:3030/data/recipes?select=' + encodeURIComponent('_id,name,img'), route => route.fulfill({
            status: 200,
            body: recipes
        }));

        await page.goto('http://localhost:5500/Lab/02.Cookbook/index.html');
        await page.waitForTimeout(600);

        let articles = await page.$$('#catalog .preview');

        for (let index = 0; index < articles.length; index++) {
            let h2 = articles[index].$('h2');
            let image = articles[index].$('img');

            assert.equal(await h2.textContent(), recipes[index].name);
            assert.equal(await image.getAttribute('src'), recipes[index].img);
        }
    });

    it('when i am logout and load page should have login and register', async () => {
        await page.goto('http://localhost:5500/Lab/02.Cookbook/index.html');

        let userIsVisible = await (await page.$('body header nav #user')).isVisible();
        let guestIsVisible = await  (await page.$('body header nav #guest')).isVisible();

        assert.isFalse(userIsVisible);
        assert.isTrue(guestIsVisible);
    });

    it('when click on details of recipe should display right page', async () => {
        let firstRecipe = mockData.recipes[0];

        await page.route('http://localhost:3030/data/recipes/', route => route.fulfill({
            status: 200,
            body: firstRecipe
        }));

        await page.goto('http://localhost:5500/Lab/02.Cookbook/index.html');
        await page.click('main #catalog article.preview');
        await page.waitForTimeout(600);

        let recipeTitle = await (await page.$('main #details article h2')).textContent();
        let img = await (await page.$('main #details .band .thumb img')).getAttribute('src');
        let ingretiens = await Promise.all((await page.$$('ul li')).map(async x => await x.textContent()));
        let steps = await Promise.all((await page.$$('.description p')).map(async x => await x.textContent()));

        assert.equal(recipeTitle, firstRecipe.name);
        assert.equal(img, firstRecipe.img);

        for (let index = 0; index < firstRecipe.ingredients.length; index++) {
            assert.equal(ingretiens[index], firstRecipe.ingredients[index]);
        }

        for (let index = 0; index < firstRecipe.steps.length; index++) {
            assert.equal(steps[index], firstRecipe.steps[index]);
        }
    });

    it('login test', async () => {
        await page.goto('http://localhost:5500/Lab/02.Cookbook/index.html');
        await page.click('#loginLink');

        await page.fill('input[name="email"]', 'admin@abv.bg');
        await page.fill('input[name="password"]', 'admin');

        await page.click('input[type="submit"]');
        await page.waitForTimeout(600);
       
        let isUserNavVisible = await (await page.$('header nav #user')).isVisible();
        let isGuestNavVisible = await (await page.$('header nav #guest')).isVisible();

        assert.isTrue(isUserNavVisible);
        assert.isFalse(isGuestNavVisible);
    });

    it('register test', async () => {
        await page.goto('http://localhost:5500/Lab/02.Cookbook/index.html');
        await page.click('#registerLink');

        await page.fill('input[name="email"]', 'dimitarkupanov@gmail.com');
        await page.fill('input[name="password"]', 'admin');
        await page.fill('input[name="rePass"]', 'admin');

        await page.click('input[type="submit"]');
        await page.waitForTimeout(600);
       
        let isUserNavVisible = await (await page.$('header nav #user')).isVisible();
        let isGuestNavVisible = await (await page.$('header nav #guest')).isVisible();

        assert.isTrue(isUserNavVisible);
        assert.isFalse(isGuestNavVisible);
    });

    it('create recipe', async () => {
        await page.goto('http://localhost:5500/Lab/02.Cookbook/index.html');
        await page.click('#loginLink');

        await page.fill('input[name="email"]', 'admin@abv.bg');
        await page.fill('input[name="password"]', 'admin');

        await page.click('input[type="submit"]');
        await page.waitForTimeout(600);

        await page.click('#createLink');

        await page.fill('input[name="name"]', 'Recipe 4');
        await page.fill('input[name="img"]', 'http://');
        await page.fill('textarea[name="ingredients"]', 'ingredient 1 \ningredient 2');
        await page.fill('textarea[name="steps"]', 'Mix \nCook');

        await page.click('input[type="submit"]');
        await page.waitForTimeout(600);

        let title = await (await page.$('h2')).textContent();
        let img = await (await page.$('main img')).getAttribute('src');
        let ingredient = await Promise.all((await page.$$('ul li')).map(async x => await x.textContent()));
        let steps = await Promise.all((await page.$$('.description p')).map(async x => await x.textContent()));

        assert.equal(title, 'Recipe 4');
        assert.equal(img, 'http://');
        assert.equal(ingredient.join(', '), 'ingredient 1, ingredient 2');
        assert.equal(steps.join(', '), 'Mix, Cook');
    });
});
