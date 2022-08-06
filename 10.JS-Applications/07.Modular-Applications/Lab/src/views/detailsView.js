import { getRecipeById } from '../api/data.js';
import { getUserData } from '../utilities.js';

import { showComments } from './comments.js';
import { onDelete } from './deletedView.js';

import { html } from '../dom.js';

const detailsTemplate = (recipe, isOwner, onDelete) => html`
<section id="details">
    ${recipeCard(recipe, isOwner, onDelete)}
    ${showComments(recipe)}
</section>`;

const recipeCard = (recipe, isOwner, onDelete) => html`
<article>
    <h2>${recipe.name}</h2>
    <div class="band">
        <div class="thumb"><img src=${'/' + recipe.img}></div>
        <div class="ingredients">
            <h3>Ingredients:</h3>
            <ul>
                ${recipe.ingredients.map(i => html`<li>${i}</li>`)}
            </ul>
        </div>
    </div>
    <div class="description">
        <h3>Preparation:</h3>
        ${recipe.steps.map(s => html`<p>${s}</p>`)}
    </div>
    ${isOwner
        ? html`
            <div class="controls">
                <a class="actionLink" href=${'/edit/' + recipe._id}>\u270E Edit</a>
                <a class="actionLink" href="javascript:void(0)" @click=${onDelete}>\u2716 Delete</a>
            </div>`
        : ''}
</article>`;

let context = null;

async function detailsView(innerContext) {
    context = innerContext;

    const id = context.params.id;
    const recipe = await getRecipeById(id);

    const userId = getUserData()?.id;
    const isOwner = userId != null && recipe._ownerId == userId;

    context.renderTemplate(detailsTemplate(recipe, isOwner, () => onDelete(recipe, context)));
}

export {
    detailsView
}