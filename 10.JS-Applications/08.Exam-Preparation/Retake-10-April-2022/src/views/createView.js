import { createPost } from '../services/posts.js';
import { createIntialSubmitFunction } from '../utilities.js';

import { html } from '../../node_modules/lit-html/lit-html.js';

const createTemplate = (createFunc) => html`
<section id="create-page" class="auth">
    <form @submit=${createFunc} id="create">
        <h1 class="title">Create Post</h1>

        <article class="input-group">
            <label for="title">Post Title</label>
            <input type="title" name="title" id="title">
        </article>

        <article class="input-group">
            <label for="description">Description of the needs </label>
            <input type="text" name="description" id="description">
        </article>

        <article class="input-group">
            <label for="imageUrl"> Needed materials image </label>
            <input type="text" name="imageUrl" id="imageUrl">
        </article>

        <article class="input-group">
            <label for="address">Address of the orphanage</label>
            <input type="text" name="address" id="address">
        </article>

        <article class="input-group">
            <label for="phone">Phone number of orphanage employee</label>
            <input type="text" name="phone" id="phone">
        </article>

        <input type="submit" class="btn submit" value="Create Post">
    </form>
</section>`;

const intialSubmitCreateFunc = createIntialSubmitFunction(create);

let ctx = null;

function showCreate(innerCtx) {
    ctx = innerCtx;
    ctx.renderTemplate(createTemplate(intialSubmitCreateFunc));
}

async function create(data) {

    if (data.title == '' || 
        data.description == '' || 
        data.imageUrl == '' || 
        data.address == '' || 
        data.phone == '') {
        alert('All field are required!');
        return;
    }

    await createPost(data.title, data.description, data.imageUrl, data.address, data.phone);

    this.reset();

    ctx.redirect('/');
}

export {
    showCreate
}