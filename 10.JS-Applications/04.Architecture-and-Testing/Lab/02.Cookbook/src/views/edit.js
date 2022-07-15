import { get, put } from '../api.js';
import { getElementBySelector, showView } from '../dom.js';
import { addFormHandler } from '../utilities.js';

const editView = getElementBySelector('#edit');
editView.remove();

addFormHandler(editView, 'form', update);

let ctx = null;
let recipeId = null;

function setupEdit(innerCtx) {
    ctx = innerCtx;
}

async function showEdit(innerRecipeId) {
    recipeId = innerRecipeId;
    const recipe = await getRecipeById(recipeId);
    populateEditFields(recipe);
    showView(editView);
}

async function update(data) {
    const body = {
        name: data.name,
        img: data.img,
        ingredients: data.ingredients.split('\n').map(l => l.trim()).filter(l => l != ''),
        steps: data.steps.split('\n').map(l => l.trim()).filter(l => l != '')
    };

    let responseData;

    try {
        responseData = await put(`/data/recipes/${recipeId}`, body);
    } catch (err) {
        alert(err.message);
        return;
    }

    ctx.getViewFunction('detailsLink').call(null, responseData._id);
}

async function getRecipeById(id) {
    return await get('/data/recipes/' + id);
}

function populateEditFields(recipe) {
    editView.querySelector('input[name="name"]').value = recipe.name;
    editView.querySelector('input[name="img"]').value = recipe.img;
    editView.querySelector('textarea[name="ingredients"]').value = recipe.ingredients.join('\n');
    editView.querySelector('textarea[name="steps"]').value = recipe.steps.join('\n');
}

export {
    showEdit,
    setupEdit
}