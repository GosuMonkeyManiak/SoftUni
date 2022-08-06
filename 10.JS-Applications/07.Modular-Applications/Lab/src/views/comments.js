import { getCommentsByRecipeId, createComment, deleteComment,  } from '../api/data.js';
import { getUserData } from '../utilities.js';

import { render, html, until, nothing } from '../dom.js';

const commentsTemplate = (recipe, commentForm, comments, currentUserId, delFunc) => html`
<div class="section-title">
    Comments for ${recipe.name}
</div>
${commentForm}
<div class="comments">
    ${until((async () => commentsList(await comments, currentUserId, delFunc))(), 'Loading comments...')}
</div>`;

const commentFormTemplate = (active, toggleForm, onSubmit) => html`
<article class="new-comment">
    ${active
        ? html`
    <h2>New comment</h2>
    <form id="commentForm" @submit=${onSubmit}>
        <textarea name="content" placeholder="Type comment"></textarea>
        <input type="submit" value="Add comment">
    </form>`
        : html`<form><button class="button" @click=${toggleForm}>Add comment</button></form>`}
</article>`;

const commentsList = (comments, currentUserId, delFunc) => html`
<ul>
    ${comments.map(currentComment => comment(currentComment, currentUserId, delFunc))}
</ul>`;

const comment = (data, currentUserId, delFunc) => html`
<li class="comment">
    <header>${data.author.email}</header>
    <p>${data.content}</p>
    
    ${data._ownerId == currentUserId
        ? html`
            <div class="controls">
                <a @click=${() => delFunc(data._id)} class="actionLink" href="javascript:void(0)">\u2716 Delete</a>
            </div>`
        : nothing}
</li>`;

function showComments(recipe) {
    let currentUserId = getUserData()?.id;

    const recipeId = recipe._id;
    let formActive = false;
    const commentsPromise = getCommentsByRecipeId(recipeId);
    const result = document.createElement('div');
    renderTemplate(commentsPromise);

    return result;

    function renderTemplate(comments) {
        render(
            commentsTemplate(recipe, createForm(formActive, toggleForm, onSubmit, currentUserId), comments, currentUserId, onDelete), 
            result);
    }

    function toggleForm() {
        formActive = !formActive;
        renderTemplate(commentsPromise);
    }

    async function onSubmit(event) {
        event.preventDefault();
        const data = new FormData(event.target);

        toggleForm();
        const comments = await commentsPromise;

        const comment = {
            content: data.get('content'),
            recipeId
        };
        console.log(comment);

        const result = await createComment(comment);

        comments.unshift(result);
        renderTemplate(comments);
    }

    async function onDelete(commnetId) {
        await deleteCommentById(commnetId);

        const comments = await commentsPromise;
        comments
    }
}

function createForm(formActive, toggleForm, onSubmit, userId) {
    if (userId == null) {
        return '';
    } else {
        return commentFormTemplate(formActive, toggleForm, onSubmit);
    }
}



export {
    showComments
}