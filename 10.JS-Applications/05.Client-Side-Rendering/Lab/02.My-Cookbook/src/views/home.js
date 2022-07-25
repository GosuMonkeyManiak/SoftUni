import { getRecent } from '../api/data.js';

import { html, render } from '../../../node_modules/lit-html/lit-html.js';

let recipeTemplate = (recipe) => html`<article class="recent" @click=${() => nav.goTo('details', recipe._id)}>
        <div class="recent-preview">
            <img src=${recipe.img} alt="">
        </div>
        <div class="recent-title">
            ${recipe.name}
        </div>
    </article>`;

let spacerTemplate = () => html`<div class="recent-space"></div>`;

let homeSection = null
let recipesContainer = null;
let nav = null;

function setupHome(innerHomeSection, innerNav) {
    homeSection = innerHomeSection;
    recipesContainer = innerHomeSection.querySelector('.recent-recipes');
    recipesContainer.innerHTML = '';
    nav = innerNav;
    return showHome;
}

async function showHome() {
    const cards = (await getRecent()).map(recipeTemplate);

    const fragment = [];

    while (cards.length > 0) {
        fragment.push(cards.shift());
        
        if (cards.length > 0) {
            fragment.push(spacerTemplate());
        }
    }
    
    render(fragment, recipesContainer);

    return homeSection;
}

export {
    setupHome
}