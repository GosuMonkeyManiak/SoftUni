import { getPostById, deletePost as apiDeletePost, getTotalDonationsForPostById, getTotalUserDonationsForPostById, donate as apiDonate } from '../services/posts.js';
import { getUserData } from '../utilities.js';

import { html, nothing } from '../../node_modules/lit-html/lit-html.js';

const detailsTemplate = (post, isOwner, isLoggedIn, deletePost, canDonate, donateFunc) => html`
<section id="details-page">
    <h1 class="title">Post Details</h1>

    <div id="container">
        <div id="details">
            <div class="image-wrapper">
                <img .src=${post.imageUrl} alt="Material Image" class="post-image">
            </div>
            <div class="info">
                <h2 class="title post-title">${post.title}</h2>
                <p class="post-description">Description: ${post.description}</p>
                <p class="post-address">Address: ${post.address}</p>
                <p class="post-number">Phone number: ${post.phone}</p>
                <p class="donate-Item">Donate Materials: ${post.postDonations}</p>
                
                ${isOwner 
                    ? html`
                        <div class="btns">
                            <a href="/edit/${post._id}" class="edit-btn btn">Edit</a>
                            <a @click=${deletePost.bind(null, post._id)} class="delete-btn btn">Delete</a>
                        </div>`
                    : isLoggedIn && canDonate
                        ? html`
                        <div class="btns">
                            <a @click=${donate.bind(null, post._id)} class="donate-btn btn">Donate</a>
                        </div>`
                        : nothing}
            </div>
        </div>
    </div>
</section>`;

let ctx = null;

async function showDetails(innerCtx) {
    ctx = innerCtx;

    //get post information
    let postId = ctx.params.id;
    let postDetails = await getPostById(postId);

    //get post donations
    let postDonations = await getTotalDonationsForPostById(postId);
    postDetails.postDonations= postDonations;

    //get user data
    let userData = getUserData();
    let isOwner = userData?.id == postDetails._ownerId;

    //can use donate
    let canDonate = true;

    //get current user donations
    if (userData != undefined) {
        let userDonations = await getTotalUserDonationsForPostById(postId, userData.id);

        if (userDonations >= 1) {
            canDonate = false;
        }
    }

    ctx.renderTemplate(detailsTemplate(postDetails, isOwner, userData, deletePost, canDonate, donate));
}

async function deletePost(id) {
    let confirmention = confirm('Are you sure you want to delete this post?');

    if (confirmention) {
        await apiDeletePost(id);

        ctx.redirect('/');
    }
}

async function donate(postId) {
    await apiDonate(postId);

    ctx.redirect(`/details/${postId}`);
}

export {
    showDetails
}