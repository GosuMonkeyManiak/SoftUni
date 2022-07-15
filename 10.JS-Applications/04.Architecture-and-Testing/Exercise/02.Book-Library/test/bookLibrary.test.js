const chromium = require('playwright-chromium').chromium;
const assert = require('chai').assert;

let browser;
let page;

describe('Book Library Test', async () => {
    before(async() => browser = await chromium.launch({ headless: false}));
    after(async () => await browser.close());

    beforeEach(async () => page = await browser.newPage());
    afterEach(async () => await page.close());

    it('when click load should load all books from the api service', async () => {
        await page.goto('http://localhost:5500/Exercise/02.Book-Library/index.html');

        await page.click('#loadBooks');
        await page.waitForTimeout(600);

        let expectedData = {
            "d953e5fb-a585-4d6b-92d3-ee90697398a0": {
                "author": "J.K.Rowling",
                "title": "Harry Potter and the Philosopher's Stone"
            },
            "d953e5fb-a585-4d6b-92d3-ee90697398a1": {
                "author": "Svetlin Nakov",
                "title": "C# Fundamentals"
            }
        }

        let dataKeys = Object.keys(expectedData);

        let rowsOfBook = await page.$$('body table tbody tr');

        for (let index = 0; index < rowsOfBook.length; index++) {
            
            let bookId = await rowsOfBook[index].getAttribute('data-id');
            let bookTitle = await (await rowsOfBook[index].$(`td:nth-child(1)`)).textContent();
            let bookAuthor = await (await rowsOfBook[index].$(`td:nth-child(2)`)).textContent();

            let editButton = await (await rowsOfBook[index].$('.editBtn')).textContent();
            let deleteButton = await (await rowsOfBook[index].$('.deleteBtn')).textContent();

            let expextedBookKey = dataKeys[index];
            let expectedBookTitle = expectedData[expextedBookKey].title;
            let expectedBookAuthor = expectedData[expextedBookKey].author;

            assert.equal(bookId, expextedBookKey);
            assert.equal(expectedBookTitle, bookTitle);
            assert.equal(expectedBookAuthor, bookAuthor);
            assert.equal(editButton, 'Edit');
            assert.equal(deleteButton, 'Delete');
        }
    });

    it('when create new book wiht parameters should be create', async () => {
        await page.goto('http://localhost:5500/Exercise/02.Book-Library/index.html');

        await page.fill('#createForm input[name="title"]', 'C# Advanced');
        await page.fill('#createForm input[name="author"]', 'Svetlin Nakov');
        await page.click('#createForm button');

        await page.waitForTimeout(600);

        await page.click('#loadBooks');
        await page.waitForTimeout(600);

        let expectedData = {
            "d953e5fb-a585-4d6b-92d3-ee90697398a0": {
                "author": "J.K.Rowling",
                "title": "Harry Potter and the Philosopher's Stone"
            },
            "d953e5fb-a585-4d6b-92d3-ee90697398a1": {
                "author": "Svetlin Nakov",
                "title": "C# Fundamentals"
            },
            "d953e5fb-a585-4d6b-92d3-ee90697398a2": {
                "author": "Svetlin Nakov",
                "title": "C# Advanced"
            }
        }

        let dataKeys = Object.keys(expectedData);

        let rowsOfBook = await page.$$('body table tbody tr');

        for (let index = 0; index < rowsOfBook.length; index++) {
            
            let bookTitle = await (await rowsOfBook[index].$(`td:nth-child(1)`)).textContent();
            let bookAuthor = await (await rowsOfBook[index].$(`td:nth-child(2)`)).textContent();

            let editButton = await (await rowsOfBook[index].$('.editBtn')).textContent();
            let deleteButton = await (await rowsOfBook[index].$('.deleteBtn')).textContent();

            let expextedBookKey = dataKeys[index];
            let expectedBookTitle = expectedData[expextedBookKey].title;
            let expectedBookAuthor = expectedData[expextedBookKey].author;
          
            assert.equal(expectedBookTitle, bookTitle);
            assert.equal(expectedBookAuthor, bookAuthor);
            assert.equal(editButton, 'Edit');
            assert.equal(deleteButton, 'Delete');
        }
    });

    it('when create new book with invalid parameters should display dialog with all field are requred!', async () => {
        let message = null;

        page.on('dialog', dialog => {
            message = dialog.message();
            dialog.accept();
        });

        await page.goto('http://localhost:5500/Exercise/02.Book-Library/index.html');
        await page.click('#createForm button');
        await page.waitForTimeout(600);

        assert.equal(message, 'All fields are required!');
    });

    it('when click edit should load data from server to edit form', async () => {
        await page.goto('http://localhost:5500/Exercise/02.Book-Library/index.html');
        await page.click('#loadBooks');
        await page.waitForTimeout(600);

        await page.click('.editBtn');

        let expectedData = {
                author: "J.K.Rowling",
                title: "Harry Potter and the Philosopher's Stone",
                id: "d953e5fb-a585-4d6b-92d3-ee90697398a0"
            };

        let bookId = await (await page.$('#editForm input[name="id"]')).inputValue();
        let bookTitle = await (await page.$('#editForm input[name="title"]')).inputValue();
        let bookAuthor = await (await page.$('#editForm input[name="author"]')).inputValue();

        assert.equal(bookId, expectedData.id);
        assert.equal(bookTitle, expectedData.title);
        assert.equal(bookAuthor, expectedData.author);  
    });

    it('when click edit should send put request to api service to edit current book', async () => {
        await page.goto('http://localhost:5500/Exercise/02.Book-Library/index.html');
        await page.click('#loadBooks');
        await page.waitForTimeout(600);

        await page.click('.editBtn');

        await page.fill('#editForm input[name="title"]', 'C# Advanced');
        await page.fill('#editForm input[name="author"]', 'Svetlin Nakov');
        await page.click('#editForm button');

        await page.click('#loadBooks');
        await page.waitForTimeout(600);

        let expectedBooks = {
            "d953e5fb-a585-4d6b-92d3-ee90697398a0": {
                "author": "Svetlin Nakov",
                "title": "C# Advanced"
            },
            "d953e5fb-a585-4d6b-92d3-ee90697398a1": {
                "author": "Svetlin Nakov",
                "title": "C# Fundamentals"
            }
        }

        let dataKeys = Object.keys(expectedBooks);

        let rowsOfBook = await page.$$('body table tbody tr');

        for (let index = 0; index < rowsOfBook.length; index++) {
            
            let bookId = await rowsOfBook[index].getAttribute('data-id');
            let bookTitle = await (await rowsOfBook[index].$(`td:nth-child(1)`)).textContent();
            let bookAuthor = await (await rowsOfBook[index].$(`td:nth-child(2)`)).textContent();

            let editButton = await (await rowsOfBook[index].$('.editBtn')).textContent();
            let deleteButton = await (await rowsOfBook[index].$('.deleteBtn')).textContent();

            let expextedBookKey = dataKeys[index];
            let expectedBookTitle = expectedBooks[expextedBookKey].title;
            let expectedBookAuthor = expectedBooks[expextedBookKey].author;

            assert.equal(bookId, expextedBookKey);
            assert.equal(expectedBookTitle, bookTitle);
            assert.equal(expectedBookAuthor, bookAuthor);
            assert.equal(editButton, 'Edit');
            assert.equal(deleteButton, 'Delete');
        }
    });

    it('when click delete button should delete a book from api service', async () => {
        page.on('dialog', dialog => dialog.accept());

        await page.goto('http://localhost:5500/Exercise/02.Book-Library/index.html');

        await page.click('#loadBooks');
        await page.waitForTimeout(600);

        await page.click('.deleteBtn');
        await page.waitForTimeout(600);

       await page.click('#loadBooks');
       await page.waitForTimeout(600);

        let expectedData = {
            "d953e5fb-a585-4d6b-92d3-ee90697398a1": {
                "author": "Svetlin Nakov",
                "title": "C# Fundamentals"
            }
        }

        let dataKeys = Object.keys(expectedData);

        let rowsOfBook = await page.$$('body table tbody tr');

        for (let index = 0; index < rowsOfBook.length; index++) {
            
            let bookId = await rowsOfBook[index].getAttribute('data-id');
            let bookTitle = await (await rowsOfBook[index].$(`td:nth-child(1)`)).textContent();
            let bookAuthor = await (await rowsOfBook[index].$(`td:nth-child(2)`)).textContent();

            let editButton = await (await rowsOfBook[index].$('.editBtn')).textContent();
            let deleteButton = await (await rowsOfBook[index].$('.deleteBtn')).textContent();

            let expextedBookKey = dataKeys[index];
            let expectedBookTitle = expectedData[expextedBookKey].title;
            let expectedBookAuthor = expectedData[expextedBookKey].author;

            assert.equal(bookId, expextedBookKey);
            assert.equal(expectedBookTitle, bookTitle);
            assert.equal(expectedBookAuthor, bookAuthor);
            assert.equal(editButton, 'Edit');
            assert.equal(deleteButton, 'Delete');
        }
    });
});