import { getFurnitureById, deleteFurnitureById } from '../infrastructure/data.js';

import { detailsTemplate } from '../views/details/detailsView.js';

let context = null;

async function showDetails(innerContext) {
    context = innerContext;

    let id = context.params.id;
    let furniture = await getFurnitureById(id);
    let isOwner = sessionStorage.getItem('userId') == furniture._ownerId ? true : false;

    context.renderTemplate(detailsTemplate(furniture, isOwner, del));
}

async function del(furniture) {
    const confirmed = confirm(`Are you sure you want to delete ${furniture.make}?`);

    if (confirmed) {
        try {
            await deleteFurnitureById(furniture._id);

            context.redirect('/dashboard');
        } catch (err) {
            alert(err.message);
        }
    }
}

export {
    showDetails
}