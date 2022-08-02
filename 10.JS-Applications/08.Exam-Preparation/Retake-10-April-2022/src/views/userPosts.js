import { getUserPostsById } from '../services/posts.js';
import { getUserData } from '../utilities.js';

import { html } from '../../node_modules/lit-html/lit-html.js';

const userPostsTemplate = (allPosts) => html`
<section id="my-posts-page">
    <h1 class="title">My Posts</h1>

    ${allPosts.length == 0 
        ? html`<h1 class="title no-posts-title">You have no posts yet!</h1>`
        : allPostsTemplate(allPosts)}
</section>`;

const allPostsTemplate = (allPosts) => html`
<div class="my-posts">
    ${allPosts.map(postTemplate)}
</div>`;

const postTemplate = (post) => html`
<div class="post">
    <h2 class="post-title">${post.title}</h2>
    <img class="post-image" .src=${post.imageUrl} alt="Material Image">
    <div class="btn-wrapper">
        <a href="/details/${post._id}" class="details-btn btn">Details</a>
    </div>
</div>`;

async function showUserPosts(ctx) {
    let userData = getUserData();

    let userPosts = await getUserPostsById(userData.id);

    ctx.renderTemplate(userPostsTemplate(userPosts));
}

export {
    showUserPosts
}