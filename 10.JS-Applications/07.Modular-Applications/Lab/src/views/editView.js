import { getRecipeById, editRecipe } from '../api/data.js';
import { createIntialSubmitFunction } from '../utilities.js';

import { html } from '../dom.js';

const editTemplate = (recipe, editFunc) => html`
<section id="create">
    <article>
        <h2>Edit Recipe</h2>
        <form @submit=${editFunc} id="editForm">
            <input type="hidden" name="_id" value=${recipe._id}>
            
            <label>
                Name: <input type="text" name="name" placeholder="Recipe name" .value=${recipe.name}>
            </label>
            <label>
                Image: <input type="text" name="img" placeholder="Image URL" .value=${recipe.img}>
            </label>
            <label class="ml">
                Ingredients: <textarea name="ingredients" placeholder="Enter ingredients on separate lines"
                .value=${recipe.ingredients.join('\n')}></textarea>
            </label>
            <label class="ml">
                Preparation: <textarea name="steps" placeholder="Enter preparation steps on separate lines" 
                    .value=${recipe.steps.join('\n')}></textarea>
            </label>

            <input type="submit" value="Save Changes">
        </form>
    </article>
</section>`;

const intialEditSubmitFunc = createIntialSubmitFunction(onEdit);

let context = null;

async function editView(innerContext) {
    context = innerContext;

    const recipeId = context.params.id;
    const recipe = await getRecipeById(recipeId);

    context.renderTemplate(editTemplate(recipe, intialEditSubmitFunc));
}

async function onEdit(data) {
    const recipeId = data._id;
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

export {
    editView
}