const chromium = require('playwright-chromium').chromium;
const assert = require('chai').assert;

let browser;
let page;

const serverData = {
    "-LxHVtajG3N1sU714pVj": {
        "author": "Spami",
        "content": "Hello, are you there?"
    },
    "-LxIDxC-GotWtf4eHwV8": {
        "author": "Garry",
        "content": "Yep, whats up :?"
    },
    "-LxIDxPfhsNipDrOQ5g_": {
        "author": "Spami",
        "content": "How are you? Long time no see? :)"
    },
    "-LxIE-dM_msaz1O9MouM": {
        "author": "George",
        "content": "Hello, guys! :))"
    },
    "-LxLgX_nOIiuvbwmxt8w": {
        "author": "Spami",
        "content": "Hello, George nice to see you! :)))"
    }
}

describe('Messenger Test', async () => {
    before(async () => browser = await chromium.launch());
    after(async () => await browser.close());

    beforeEach(async () => page = await browser.newPage());
    afterEach(async () => await page.close());

    it('when click refresh should load a messeges from the server', async () => {
        await page.goto('http://localhost:5500/Exercise/01.Messenger/index.html');
        await page.click('#refresh');
        await page.waitForTimeout(600);

        let expextedMessages = Object.values(serverData).map(message => `${message.author}: ${message.content}`).join('\n');
        let actualMessages = await (await page.$('textarea')).inputValue();

        assert.equal(actualMessages, expextedMessages);
    });

    it('when click send should new message to server', async () => {
        await page.goto('http://localhost:5500/Exercise/01.Messenger/index.html');

        await page.fill('#author', 'Dimitar');
        await page.fill('#content', 'Hello, there!');

        await page.click('#submit');
        await page.waitForTimeout(600);

        serverData['-LxLgX_nOIiuvbwmxt8a'] = {
            "author": "Dimitar",
            "content": "Hello, there!"
        };

        await page.click('#refresh');
        await page.waitForTimeout(600);

        let expextedMessages = Object.values(serverData).map(message => `${message.author}: ${message.content}`).join('\n');
        let actualMessages = await (await page.$('textarea')).inputValue();

        assert.equal(actualMessages, expextedMessages);
    });
});