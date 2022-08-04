import {  add as apiAdd } from '../services/books.js';
import { createIntialSubmitFunction } from '../utilities.js';

import { html } from '../../node_modules/lit-html/lit-html.js';

const addTemplate = (addFunc) => html`
<section id="create-page" class="create">
    <form @submit=${addFunc} id="create-form">
        <fieldset>
            <legend>Add new Book</legend>
            <p class="field">
                <label for="title">Title</label>
                <span class="input">
                    <input type="text" name="title" id="title" placeholder="Title">
                </span>
            </p>
            <p class="field">
                <label for="description">Description</label>
                <span class="input">
                    <textarea name="description" id="description" placeholder="Description"></textarea>
                </span>
            </p>
            <p class="field">
                <label for="image">Image</label>
                <span class="input">
                    <input type="text" name="imageUrl" id="image" placeholder="Image">
                </span>
            </p>
            <p class="field">
                <label for="type">Type</label>
                <span class="input">
                    <select id="type" name="type">
                        <option value="Fiction">Fiction</option>
                        <option value="Romance">Romance</option>
                        <option value="Mistery">Mistery</option>
                        <option value="Classic">Clasic</option>
                        <option value="Other">Other</option>
                    </select>
                </span>
            </p>
            <input class="button submit" type="submit" value="Add Book">
        </fieldset>
    </form>
</section>`;

const intialSubmitAddFunc = createIntialSubmitFunction(add);

let ctx = null;

function addView(innerCtx) {
    ctx = innerCtx;

    ctx.renderTemplate(addTemplate(intialSubmitAddFunc));
}

async function add({ title, description, imageUrl, type}) {
    if (title == '' ||
        description == '' || 
        imageUrl == '' || 
        type == '') {
        alert('All field are required!');
        return;
    }

    await apiAdd(title, description, imageUrl, type);

    this.reset();

    ctx.redirect('/dashboard');
}

export {
    addView
}