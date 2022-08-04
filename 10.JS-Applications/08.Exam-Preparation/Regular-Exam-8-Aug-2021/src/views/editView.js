import { getById, edit as apiEdit } from '../services/books.js';
import { createIntialSubmitFunction } from '../utilities.js';

import { html } from '../../node_modules/lit-html/lit-html.js';

const editTemplate = (editFunc, book) => html`
<section id="edit-page" class="edit">
    <form @submit=${editFunc} id="edit-form">
        <fieldset>
            <legend>Edit my Book</legend>
            <p class="field">
                <label for="title">Title</label>
                <span class="input">
                    <input type="text" name="title" id="title" .value=${book.title}>
                </span>
            </p>
            <p class="field">
                <label for="description">Description</label>
                <span class="input">
                    <textarea name="description"
                        id="description">${book.description}</textarea>
                </span>
            </p>
            <p class="field">
                <label for="image">Image</label>
                <span class="input">
                    <input type="text" name="imageUrl" id="image" .value=${book.imageUrl}>
                </span>
            </p>
            <p class="field">
                <label for="type">Type</label>
                <span class="input">
                    <select id="type" name="type" .value=${book.type}>
                        <option value="Fiction" selected>Fiction</option>
                        <option value="Romance">Romance</option>
                        <option value="Mistery">Mistery</option>
                        <option value="Classic">Clasic</option>
                        <option value="Other">Other</option>
                    </select>
                </span>
            </p>
            <input class="button submit" type="submit" value="Save">

            <input type="hidden" name="id" .value=${book._id} />
        </fieldset>
    </form>
</section>`;

const intialSubmitEditFunc = createIntialSubmitFunction(edit);

let ctx = null;

async function editView(innerCtx) {
    ctx = innerCtx;

    let bookId = ctx.params.id;
    let book = await getById(bookId);

    ctx.renderTemplate(editTemplate(intialSubmitEditFunc, book));
}

async function edit({ title, description, imageUrl, type, id }) {
    if (title == '' ||
        description == '' ||
        imageUrl == '' ||
        type == '') {
        alert('All field are required!');
        return;
    }

    await apiEdit(id, title, description, imageUrl, type);

    this.reset();

    ctx.redirect('/details/' + id);
}

export {
    editView
}