import { getRecent } from '../api/data.js';

import { homeTemplate } from '../views/home/homeView.js';

async function showHome(context) {
    const recipes = await getRecent();
    context.renderTemplate(homeTemplate(recipes, context.redirect));
}

export {
    showHome
}