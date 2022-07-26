import { html } from '../../../node_modules/lit-html/lit-html.js';
import { until } from '../../../node_modules/lit-html/directives/until.js';


const commentsTemplate = (recipe, commentForm, comments) => html`
<div class="section-title">
    Comments for ${recipe.name}
</div>
${commentForm}
<div class="comments">
    ${until((async () => commentsList(await comments))(), 'Loading comments...')}
</div>`;

const commentFormTemplate = (active, toggleForm, createFunction) => html`
<article class="new-comment">
    ${active
        ? html`
    <h2>New comment</h2>
    <form @submit=${createFunction} id="commentForm">
        <textarea name="content" placeholder="Type comment"></textarea>
        <input type="submit" value="Add comment">
    </form>`
        : html`<form>
                <button class="button" @click=${toggleForm}>Add comment</button>
            </form>`}
</article>`;

const commentsList = (comments) => html`
<ul>
    ${comments.map(comment)}
</ul>`;

const comment = (data) => html`
<li class="comment">
    <header>${data.author.email}</header>
    <p>${data.content}</p>
</li>`;

export {
    commentsTemplate,
    commentFormTemplate
}