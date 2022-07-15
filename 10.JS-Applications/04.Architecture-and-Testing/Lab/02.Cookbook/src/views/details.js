import { del, get } from '../api.js';
import { e, getElementBySelector, showView } from '../dom.js';
import { showEdit } from './edit.js';

const detailsView = getElementBySelector('#details');
detailsView.remove();

let ctx = null;

function setupDetails(innerCtx) {
    ctx = innerCtx;
}

async function showDetails(id) {
    const recipe = await getRecipeById(id);
    detailsView.replaceChildren(createRecipeCard(recipe));

    showView(detailsView);
}

async function getRecipeById(id) {
    return await get('/data/recipes/' + id);
}

async function deleteRecipeById(id) {
    try {
        await del('/data/recipes/' + id);
    } catch (err) {
        alert(err.message);
        return;
    }

    detailsView.replaceChildren(e('article', {}, e('h2', {}, 'Recipe deleted')));
}

function createRecipeCard(recipe) {
    const result = e('article', {},
        e('h2', {}, recipe.name),
        e('div', { className: 'band' },
            e('div', { className: 'thumb' }, e('img', { src: recipe.img })),
            e('div', { className: 'ingredients' },
                e('h3', {}, 'Ingredients:'),
                e('ul', {}, recipe.ingredients.map(i => e('li', {}, i))),
            )
        ),
        e('div', { className: 'description' },
            e('h3', {}, 'Preparation:'),
            recipe.steps.map(s => e('p', {}, s))
        ),
    );

    const userId = sessionStorage.getItem('userId');
    
    if (userId != null && recipe._ownerId == userId) {
        result.appendChild(e('div', { className: 'controls' },
            e('button', { onClick: () => ctx.getViewFunction('editLink').call(null, recipe._id) }, '\u270E Edit'),
            e('button', { onClick: onDelete }, '\u2716 Delete'),
        ));
    }

    return result;

    function onDelete() {
        const confirmed = confirm(`Are you sure you want to delete ${recipe.name}?`);
        if (confirmed) {
            deleteRecipeById(recipe._id);
        }
    }
}

export {
    showDetails,
    setupDetails
}