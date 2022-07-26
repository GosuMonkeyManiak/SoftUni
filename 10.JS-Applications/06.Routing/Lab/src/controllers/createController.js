import { createRecipe } from '../api/data.js';
import { createIntialSubmitFunction } from '../utilities.js';

import { createTemplate } from '../views/create/createView.js';

let context = null;

function showCreate(innerContext) {
    context = innerContext;

    let initialSubmitFunction = createIntialSubmitFunction(create);
    context.renderTemplate(createTemplate(initialSubmitFunction));
}

async function create(data) {
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
    showCreate
}