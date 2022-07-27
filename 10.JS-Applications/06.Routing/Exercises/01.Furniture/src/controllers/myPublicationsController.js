import { getUserFurnituresById } from '../infrastructure/data.js';

import { publicationTemplate } from '../views/myPublications/publicationsView.js';


async function showMyPublications(context) {
    try {
        let userFurnitures = await getUserFurnituresById(sessionStorage.getItem('userId'));

        context.renderTemplate(publicationTemplate(userFurnitures));
    } catch (error) {
        alert(error.message);
    }
}

export {
    showMyPublications
}