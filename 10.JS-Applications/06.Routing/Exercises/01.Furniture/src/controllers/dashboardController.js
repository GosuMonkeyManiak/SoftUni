import { getAllFurnitures } from '../infrastructure/data.js';

import { dashboardTemplate } from '../views/dashboard/dashboardView.js';

async function showDashboard(context) {
    let furnitures = await getAllFurnitures();

    context.renderTemplate(dashboardTemplate(furnitures));
}

export {
    showDashboard
}