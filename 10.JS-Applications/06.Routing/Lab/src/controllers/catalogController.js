import { getRecipes, getRecipeCount } from '../api/data.js';

import { catalogTemplate } from '../views/catalog/catalogView.js';

async function showCatalog(context) {
    let page = context.params.page == undefined ? 1 : context.params.page;

    const recipes = await getRecipes(page);
    const count = await getRecipeCount();
    const pages = Math.ceil(count / 5);

    context.renderTemplate(catalogTemplate(recipes, context.redirect, page, pages));
}

export {
    showCatalog
}