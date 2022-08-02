import { getAllPosts} from '../services/posts.js';

import { html } from '../../node_modules/lit-html/lit-html.js';

const dashboardTemplate = (allPosts) => html`
<section id="dashboard-page">
    <h1 class="title">All Posts</h1>

    ${allPosts.length == 0 
        ? html`<h1 class="title no-posts-title">No posts yet!</h1>`
        : allPostsTemplate(allPosts)}

</section>`;

const allPostsTemplate = (allPosts) => html`
<div class="all-posts">
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

async function showDashboard(ctx) {
    let allPosts = await getAllPosts();

    ctx.renderTemplate(dashboardTemplate(allPosts));
}

export {
    showDashboard
}