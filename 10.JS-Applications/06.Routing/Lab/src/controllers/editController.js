import { getRecipeById, editRecipe } from '../api/data.js';
import { createIntialSubmitFunction } from '../utilities.js';

import { editTemplate } from '../views/edit/editView.js';

async function showEdit(context) {
    let recipeId = context.params.id;

    const recipe = await getRecipeById(recipeId);

    let initialSubmitFunction = createIntialSubmitFunction(edit)
    context.renderTemplate(editTemplate(recipe, initialSubmitFunction))

    async function edit(data) {
        const body = {
            name: data.name,
            img: data.img,
            ingredients: data.ingredients.split('\n').map(l => l.trim()).filter(l => l != ''),
            steps: data.steps.split('\n').map(l => l.trim()).filter(l => l != '')
        };

        try {
            await editRecipe(recipeId, body);
            context.redirect(`/details/${recipeId}`);
        } catch (err) {
            alert(err.message);
        }
    }
}

export {
    showEdit
}