import { getAll } from '../services/pets.js';

import { html } from '../../node_modules/lit-html/lit-html.js';

const dashboardTemplate = (allPets) => html`
<section id="dashboard">
    <h2 class="dashboard-title">Services for every animal</h2>

    <div class="animals-dashboard">

        ${allPets.length == 0 
            ? html`
            <div>
                <p class="no-pets">No pets in dashboard</p>
            </div>`
            : allPets.map(petTemplate)}
    </div>
</section>`;

const petTemplate = (pet) => html`
<div class="animals-board">
    <article class="service-img">
        <img class="animal-image-cover" .src=${pet.image.slice(2)}>
    </article>
    <h2 class="name">${pet.name}</h2>
    <h3 class="breed">${pet.breed}</h3>
    <div class="action">
        <a class="btn" href="/details/${pet._id}">Details</a>
    </div>
</div>`

async function dashboardView(ctx) {
    let allPets = await getAll();

    ctx.renderTemplate(dashboardTemplate(allPets));
}

export {
    dashboardView
}