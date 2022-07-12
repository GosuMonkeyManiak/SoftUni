import { showView, displayCorrectUserButtons } from './utilities.js';
import { loadRecipe } from './create.js';

async function showHome() {
    let homeView = document.createDocumentFragment();

    const recipes = await getRecipes();
    const cards = recipes.map(createRecipePreview);

    cards.forEach(c => homeView.appendChild(c));

    displayCorrectUserButtons();
    showView(homeView);
}

async function getRecipes() {
    const response = await fetch('http://localhost:3030/data/recipes');
    const recipes = await response.json();

    return recipes;
}

async function getRecipeById(id) {
    const response = await fetch('http://localhost:3030/data/recipes/' + id);
    const recipe = await response.json();

    return recipe;
}

function createRecipePreview(recipe) {
    const result = e('article', { className: 'preview', onClick: toggleCard },
        e('div', { className: 'title' }, e('h2', {}, recipe.name)),
        e('div', { className: 'small' }, e('img', { src: recipe.img }))
    );

    return result;

    async function toggleCard() {
        const fullRecipe = await getRecipeById(recipe._id);
        showView(createRecipeCard(fullRecipe));
    }
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
        e('div', { className: 'controls'}, 
            e('button', { id: recipe._id, onClick: loadRecipe.bind(null, recipe)}, e('i', { className: 'fa-solid fa-pen' }), '  Edit'),
            e('button', { id: recipe._id, onClick: deleteRecipe }, e('i', { className: 'fa-solid fa-trash-can' }), '  Delete'))
    );

    return result;
}

function e(type, attributes, ...content) {
    const result = document.createElement(type);

    for (let [attr, value] of Object.entries(attributes || {})) {
        if (attr.substring(0, 2) == 'on') {
            result.addEventListener(attr.substring(2).toLocaleLowerCase(), value);
        } else {
            result[attr] = value;
        }
    }

    content = content.reduce((a, c) => a.concat(Array.isArray(c) ? c : [c]), []);

    content.forEach(e => {
        if (typeof e == 'string' || typeof e == 'number') {
            const node = document.createTextNode(e);
            result.appendChild(node);
        } else {
            result.appendChild(e);
        }
    });

    return result;
}

async function deleteRecipe(event) {
    let recipeFullInfo = await getRecipeById(event.target.id);

    let userId = sessionStorage.getItem('userId');

    if (userId == null || userId != recipeFullInfo._ownerId) {
        console.log('Error');
        showHome();
        return;
    }

    try {
        let response = await fetch(`http://localhost:3030/data/recipes/${event.target.id}`, {
            method: 'delete',
            headers: {
                'X-Authorization': sessionStorage.getItem('authToken')
            }
        });

        if (response.status != 200) {
            let error = await response.json();
            throw Error(error);
        }
    } catch (error) {
        console.log(error.message);
    }

    showHome();
}

export {
    showHome
}