import { getRecipes, getRecipeCount } from '../api/data.js';

import { html, render } from '../../../node_modules/lit-html/lit-html.js';

let recipePreviewTemplate = (recipe) => html`<article class="preview" @click=${() => nav.goTo('details', recipe._id)}>
        <div class="title">
            <h2>${recipe.name}</h2>
        </div>
        <div class="small">
            <img src=${recipe.img} alt="">
        </div>
    </article>`;

let pagerTemplate = (page, pages, header) => {
    let buttonsSetUp = null;

    if (page > 1) {
        buttonsSetUp = html`<a href="/catalog" class="pager" @click=${(e) => { e.preventDefault(); nav.goTo('catalog', page - 1); }}>
            < Prev
        </a>`;
    }
    if (page < pages) {
        buttonsSetUp = html`<a href="/catalog" class="pager" @click=${(e) => { e.preventDefault(); nav.goTo('catalog', page + 1); }}>
            Next >
        </a>`;
    }

    let result = [];

    if (header) {
        result.push(html`<header class="section-title">
            Page ${page} of ${pages}
        </header>`);
    } else {
        result.push(html`<footer class="section-title">
            Page ${page} of ${pages}
        </footer>`);
    }

    if (buttonsSetUp != null) {
        result.push(buttonsSetUp);
    }
    
    return result;
};

let catalogSection = null;
let nav = null;

function setupCatalog(innerCatalogSection, innerNav) {
    innerCatalogSection.innerHTML = '';
    catalogSection = innerCatalogSection;
    nav = innerNav;
    return showCatalog;
}

async function showCatalog(page = 1) {
    const recipes = await getRecipes(page);
    const count = await getRecipeCount();
    const pages = Math.ceil(count / 5);
    const cards = recipes.map(recipePreviewTemplate);

    const fragment = [];

    fragment.push(...pagerTemplate(page, pages, true));
    cards.forEach(c => fragment.push(c));
    fragment.push(...pagerTemplate(page, pages));
   
    render(fragment, catalogSection);

    return catalogSection;
}

export {
    setupCatalog
}