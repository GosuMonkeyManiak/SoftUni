import { getById, del as apiDel, getAllLikes, getAllLikeByUser, like as apiLike } from '../services/books.js';
import { getUserData } from '../utilities.js';

import { html, nothing } from '../../node_modules/lit-html/lit-html.js';

const detailsTemplate = (book, isOwner, isHaveUser, canLike, allLikes, deleteFunc, likeFunc) => html`
<section id="details-page" class="details">
    <div class="book-information">
        <h3>${book.title}</h3>
        <p class="type">Type: ${book.type}</p>
        <p class="img">
            <img .src=${book.imageUrl}>
        </p>
        <div class="actions">

            ${isOwner 
                ? html`
                    <a class="button" href="/edit/${book._id}">Edit</a>
                    <a class="button" @click=${deleteFunc.bind(null, book._id)}>Delete</a>`
                : isHaveUser && canLike
                    ? html`<a class="button" @click=${likeFunc.bind(null, book._id)}>Like</a>`
                    : nothing}
            
            <div class="likes">
                <img class="hearts" src="/images/heart.png">
                <span id="total-likes">Likes: ${allLikes}</span>
            </div>
        </div>
    </div>
    <div class="book-description">
        <h3>Description:</h3>
        <p>${book.description}</p>
    </div>
</section>`;

let ctx = null;

async function detailsView(innerCtx) {
    ctx = innerCtx;

    let bookId = ctx.params.id;
    let book = await getById(bookId);

    let bookLikes = await getAllLikes(bookId);

    let isOwner = false;
    let isHaveUser = false;
    let canLike = true;

    let userData = getUserData();

    if (userData != null) {
        isHaveUser = true;

        if (userData.id == book._ownerId) {
            isOwner = true;
        }

        let currentUserLikes = await getAllLikeByUser(bookId, userData.id);

        if (currentUserLikes == 1) {
            canLike = false;
        }
    }

    ctx.renderTemplate(detailsTemplate(book, isOwner, isHaveUser, canLike, bookLikes, del, like));
}

async function del(bookId) {
    let confirmation = confirm('Are you sure want to delete this book?');

    if (confirmation) {
        await apiDel(bookId);

        ctx.redirect('/dashboard');
    }
}

async function like(bookId) {
    await apiLike(bookId);

    ctx.redirect('/details/' + bookId);
}

export {
    detailsView
}