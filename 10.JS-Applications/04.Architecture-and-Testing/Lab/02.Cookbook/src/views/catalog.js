import { e, getElementBySelector, showView } from '../dom.js';
import { get } from '../api.js';

const catalogView = getElementBySelector('#catalog');
catalogView.remove();

let ctx = null;

async function showCatalog(innerCtx) {
    ctx = innerCtx;

    const recipes = await getRecipes();
    const cards = recipes.map(createRecipePreview);

    catalogView.innerHTML = '';
    cards.forEach(c => catalogView.appendChild(c));

    showView(catalogView);
}

async function getRecipes() {
    return await get('/data/recipes?select=' + encodeURIComponent('_id,name,img'));
}

function createRecipePreview(recipe) {
    const result = e('article', { className: 'preview', onclick: () => ctx.getViewFunction('detailsLink').call(null, recipe._id) },
        e('div', { className: 'title' }, e('h2', {}, recipe.name)),
        e('div', { className: 'small' }, e('img', { src: recipe.img })),
    );

    return result;
}

export {
    showCatalog
}