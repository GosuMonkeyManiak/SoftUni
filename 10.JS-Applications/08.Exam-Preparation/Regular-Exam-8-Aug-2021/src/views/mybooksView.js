import { html } from '../../node_modules/lit-html/lit-html.js';
import { getAllByUser } from '../services/books.js';
import { getUserData } from '../utilities.js';

const myBooksTemplate = (userBooks) => html`
<section id="my-books-page" class="my-books">
    <h1>My Books</h1>

    ${userBooks.length == 0
        ? html`
            <p class="no-books">No books in database!</p>`
        : html`
            <ul class="my-books-list">
                ${userBooks.map(bookTemplate)}
            </ul>`}
</section>`;

const bookTemplate = (book) => html`
<li class="otherBooks">
    <h3>${book.title}</h3>
    <p>Type: ${book.type}</p>
    <p class="img">
        <img .src=${book.imageUrl}>
    </p>
    <a class="button" href="/details/${book._id}">Details</a>
</li>`;

async function myBooksView(ctx) {
    let userData = getUserData();

    let userBooks = await getAllByUser(userData.id);

    ctx.renderTemplate(myBooksTemplate(userBooks));
}

export {
    myBooksView
}