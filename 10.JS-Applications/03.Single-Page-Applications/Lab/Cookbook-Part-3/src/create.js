import { showHome } from './home.js';
import { showView, clearInputs } from './utilities.js';


const createRecipeView = document.querySelector('#views #createRecipeView');
createRecipeView.remove();

createRecipeView.querySelector('form').addEventListener('submit', ev => {
    ev.preventDefault();
    const formData = new FormData(ev.target);
    onSubmit([...formData.entries()].reduce((p, [k, v]) => Object.assign(p, { [k]: v }), {}));
});

function showCreateRecipe() {
    showView(createRecipeView);
}

async function onSubmit(data) {
    const body = JSON.stringify({
        name: data.name,
        img: data.img,
        ingredients: data.ingredients.split('\n').map(l => l.trim()).filter(l => l != ''),
        steps: data.steps.split('\n').map(l => l.trim()).filter(l => l != '')
    });

    const token = sessionStorage.getItem('authToken');

    if (token == null) {
        showHome();
        return;
    }

    try {
        const response = await fetch('http://localhost:3030/data/recipes', {
            method: 'post',
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': token
            },
            body
        });
        
        if (response.status == 200) {
            clearInputs();
            showHome();
        } else {
            throw new Error(await response.json());
        }
    } catch (err) {
        console.error(err.message);
    }
}

function loadRecipe(recipe) {
    createRecipeView.querySelector('h2').textContent = 'Edit Recipe';
    createRecipeView.querySelector('input[name="name"]').value = recipe.name;
    createRecipeView.querySelector('input[name="img"]').value = recipe.img;
    createRecipeView.querySelector('textarea[name="ingredients"]').textContent = recipe.ingredients.join('\n');
    createRecipeView.querySelector('textarea[name="steps"]').textContent = recipe.steps.join('\n');
    createRecipeView.querySelector('input[type="submit"]').value = 'Update Recipe';

    showView(createRecipeView);
}

export {
    showCreateRecipe,
    loadRecipe
}