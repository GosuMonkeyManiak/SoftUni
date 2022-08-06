import { createRecipe } from '../api/data.js';
import { createIntialSubmitFunction } from '../utilities.js';

import { html } from '../dom.js';

const createTemplate = (createFunc) => html`
<section id="create">
    <article>
        <h2>New Recipe</h2>
        
        <form @submit=${createFunc} id="createForm">
            <label>Name: <input type="text" name="name" placeholder="Recipe name"></label>
            <label>Image: <input type="text" name="img" placeholder="Image URL"></label>
            <label class="ml">
                Ingredients: <textarea name="ingredients" placeholder="Enter ingredients on separate lines"></textarea>
            </label>
            <label class="ml">
                Preparation: <textarea name="steps" placeholder="Enter preparation steps on separate lines"></textarea>
            </label>

            <input type="submit" value="Create Recipe">
        </form>
    </article>
</section>`;

const intialCreateSubmitFunc = createIntialSubmitFunction(onCreate);

let context = null;

function createView(innerContext) {
    context = innerContext;

    context.renderTemplate(createTemplate(intialCreateSubmitFunc));
}

async function onCreate(data) {
    const body = {
        name: data.name,
        img: data.img,
        ingredients: data.ingredients.split('\n').map(l => l.trim()).filter(l => l != ''),
        steps: data.steps.split('\n').map(l => l.trim()).filter(l => l != '')
    };

    try {
        const result = await createRecipe(body);
        context.redirect(`/details/${result._id}`);
    } catch (err) {
        alert(err.message);
    }
}

export {
    createView
}