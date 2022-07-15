const chromium = require('playwright-chromium').chromium;
const assert = require('chai').assert;

let browser, page;

describe('Accordion tests', () => {

    before(async () => {
        browser = await chromium.launch();
    });
    after(async () => {
        await browser.close();
    });

    beforeEach(async () => {
        page = await browser.newPage();
    });
    afterEach(async () => {
        await page.close();
    });

    it('when page is loaded should have 4 divs with class accordion', async () => {
        await page.goto('http://127.0.0.1:5500/Lab/01.%20Accordion/index.html');

        let firstDivContent = await page.textContent('body #main .accordion:nth-child(1) .head span');
        let secondDivContent = await page.textContent('body #main .accordion:nth-child(2) .head span');
        let thirdDivContent = await page.textContent('body #main .accordion:nth-child(3) .head span');
        let fourthDivContent = await page.textContent('body #main .accordion:nth-child(4) .head span');

        assert.equal(firstDivContent, 'Scalable Vector Graphics');
        assert.equal(secondDivContent, 'Open standard');
        assert.equal(thirdDivContent, 'Unix');
        assert.equal(fourthDivContent, 'ALGOL');
    });

    it('when click more button should change to less and show content', async () => {
        await page.goto('http://127.0.0.1:5500/Lab/01.%20Accordion/index.html');

        let isVisible = await page.isVisible('body #main .accordion .extra');
        assert.isFalse(isVisible);
        
        await page.click('text="More"');
        await page.waitForTimeout(600);

        isVisible = await page.isVisible('body #main .accordion .extra');
        assert.isTrue(isVisible);

        let button = await page.$('body #main .accordion .head button');
        assert.equal(await button.textContent(), 'Less');

        let content = await page.$('body #main .accordion .extra p');
        assert.notEqual(content.textContent(), '');
    });

    it('when click less button should hide content section', async () => {
        await page.goto('http://127.0.0.1:5500/Lab/01.%20Accordion/index.html');
        await page.click('text="More"');

        await page.click('text="Less"');

        let isVisible = await page.isVisible('body #main .accordion .extra');
        assert.isFalse(isVisible);

        let button = await page.$('body #main .accordion .head button');
        assert.equal(await button.textContent(), 'More');
    });
});