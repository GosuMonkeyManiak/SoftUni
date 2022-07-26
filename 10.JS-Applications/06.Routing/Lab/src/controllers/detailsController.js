import { getRecipeById, deleteRecipeById } from '../api/data.js';

import { detailsTemplate } from '../views/details/detailsView.js';
import { deleteTemplate } from '../views/delete/deleteView.js';

let context = null;

async function showDetails(innerContext) {
    context = innerContext;
    let id = context.params.id;

    const recipe = await getRecipeById(id);

    const userId = sessionStorage.getItem('userId');
    const isOwner = userId != null && recipe._ownerId == userId;

    context.renderTemplate(detailsTemplate(recipe, isOwner, context, () => onDelete(recipe)));
}

 async function onDelete(recipe) {
    const confirmed = confirm(`Are you sure you want to delete ${recipe.name}?`);

    if (confirmed) {
        try {
            await deleteRecipeById(recipe._id);
            context.renderTemplate(deleteTemplate());
        } catch (err) {
            alert(err.message);
        }
    }
}

export {
    showDetails
}