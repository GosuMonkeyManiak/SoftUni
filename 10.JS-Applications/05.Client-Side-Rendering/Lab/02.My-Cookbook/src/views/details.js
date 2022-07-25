import { getRecipeById, deleteRecipeById } from '../api/data.js';
import { showCommnets } from './comments.js';

import { html, render} from '../../../node_modules/lit-html/lit-html.js';


let recipeDetailsTemplate = (recipe) => {
    let controlsTemplate = null;

    const userId = sessionStorage.getItem('userId');

    if (userId != null && recipe._ownerId == userId) {
        controlsTemplate = html`<div class="controls">
            <button @click=${() => nav.goTo('edit', recipe._id)}>${'\u270E'} Edit</button>
            <button @click=${onDelete.bind(null, recipe)}>${'\u2716'} Delete</button>
        </div>`;
    }

    return html`<article>
        <h2>
            ${recipe.name}
        </h2>
        <div class="band">
            <div class="thumb">
                <img src=${recipe.img} alt="">
            </div>
            <div class="ingredients">
                <h3>
                    Ingredients
                </h3>
                <ul>
                    ${recipe.ingredients.map(i => html`<li>${i}</li>`)}
                </ul>
            </div>
        </div>
        <div class="description">
            <h3>Preparation</h3>
            ${recipe.steps.map(s => html`<p>${s}</p>`)}
        </div>
    </article>
    ${controlsTemplate == null ? '' : controlsTemplate}
    ${showCommnets(recipe)}`;
};

let deletedRecipeTemplate = () => html`<article>
        <h2>Recipe deleted</h2>
    </article>`;

let detailsSection = null;
let nav = null;

function setupDetails(innerDetailsSection, innerNav) {
    innerDetailsSection.innerHTML = '';
    detailsSection = innerDetailsSection;
    nav = innerNav;
    return showDetails;
}

async function showDetails(id) {
    const recipe = await getRecipeById(id);
    //const recipeComments = await getRecipeCommnetsById(id); //empty array or commnet in specific format

    render(recipeDetailsTemplate(recipe), detailsSection);

    return detailsSection;
}

async function onDelete(recipe) {
    const confirmed = confirm(`Are you sure you want to delete ${recipe.name}?`);

    if (confirmed) {
        try {
            await deleteRecipeById(recipe._id);

            render(deletedRecipeTemplate(), detailsSection);
        } catch (err) {
            alert(err.message);
        }
    }
}

export {
    setupDetails
}
