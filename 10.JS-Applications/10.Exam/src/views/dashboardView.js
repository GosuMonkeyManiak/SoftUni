import { getAll } from '../services/jobOffers.js';

import { html } from '../../node_modules/lit-html/lit-html.js';

const dashboardTemplate = (allJobOffers) => html`
<section id="dashboard">
    <h2>Job Offers</h2>

    ${allJobOffers.length == 0
        ? html`<h2>No offers yet.</h2>`
        : allJobOffers.map(jobOfferTemplate)}
</section>`;

const jobOfferTemplate = (jobOffer) => html`
<div class="offer">
    <img .src=${jobOffer.imageUrl.slice(2)} alt="image" />
    <p>
        <strong>Title: </strong>
        <span class="title">${jobOffer.title}</span>
    </p>
    <p>
        <strong>Salary:</strong>
        <span class="salary">${jobOffer.salary}</span>
    </p>
    <a class="details-btn" href="/details/${jobOffer._id}">Details</a>
</div>`;

async function dashboardView(ctx) {
    let allJobOffers = await getAll();

    ctx.renderTemplate(dashboardTemplate(allJobOffers));
}

export {
    dashboardView
}