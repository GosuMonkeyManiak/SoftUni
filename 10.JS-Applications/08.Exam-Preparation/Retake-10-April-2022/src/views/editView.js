import { editPost, getPostById } from '../services/posts.js';
import { createIntialSubmitFunction } from '../utilities.js';

import { html } from '../../node_modules/lit-html/lit-html.js';

const editTemplate = (post, editFunc) => html`
<section id="edit-page" class="auth">
    <form @submit=${editFunc} name="id" id="edit">
        <h1 class="title">Edit Post</h1>

        <article class="input-group">
            <label for="title">Post Title</label>
            <input type="title" name="title" id="title" .value=${post.title}>
        </article>

        <article class="input-group">
            <label for="description">Description of the needs </label>
            <input type="text" name="description" id="description" .value=${post.description}>
        </article>

        <article class="input-group">
            <label for="imageUrl"> Needed materials image </label>
            <input type="text" name="imageUrl" id="imageUrl" .value=${post.imageUrl}>
        </article>

        <article class="input-group">
            <label for="address">Address of the orphanage</label>
            <input type="text" name="address" id="address" .value=${post.address}>
        </article>

        <article class="input-group">
            <label for="phone">Phone number of orphanage employee</label>
            <input type="text" name="phone" id="phone" .value=${post.phone}>
        </article>

        <input type="submit" class="btn submit" value="Edit Post">

        <input type="hidden" name="id" .value=${post._id}/>
    </form>
</section>`;

const intialSubmitEditFunc = createIntialSubmitFunction(edit);

let ctx = null;

async function showEdit(innerCtx) {
    ctx = innerCtx;

    let postId = ctx.params.id;
    let post = await getPostById(postId);

    ctx.renderTemplate(editTemplate(post, intialSubmitEditFunc));
}

async function edit(data) {

    if (data.title == '' || 
        data.description == '' || 
        data.imageUrl == '' || 
        data.address == '' || 
        data.phone == '') {
        alert('All field are required!');
        return;
    }

    await editPost(data.id, data.title, data.description, data.imageUrl, data.address, data.phone);

    ctx.redirect(`/details/${data.id}`);
}

export {
    showEdit
}