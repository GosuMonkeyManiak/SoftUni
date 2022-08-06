import { getById, del as apiDelete, getAllApplications, getUserApplies, apply as apiApply } from '../services/jobOffers.js';

import { html, nothing } from '../../node_modules/lit-html/lit-html.js';
import { getUserData } from '../utilities.js';

const detailsTemplate = (jobOffer, allApplications, isOwner, isHaveUser, canApply, del, applyFunc) => html`
<section id="details">
    <div id="details-wrapper">
        <img id="details-img" .src=${jobOffer.imageUrl.slice(2)} alt="example1" />

        <p id="details-title">${jobOffer.title}</p>
        <p id="details-category">
            Category: <span id="categories">${jobOffer.category}</span>
        </p>
        <p id="details-salary">
            Salary: <span id="salary-number">${jobOffer.salary}</span>
        </p>
        <div id="info-wrapper">
            <div id="details-description">
                <h4>Description</h4>
                <span>${jobOffer.description}</span>
            </div>
            <div id="details-requirements">
                <h4>Requirements</h4>
                <span>${jobOffer.requirements}</span>
            </div>
        </div>
        <p>Applications: <strong id="applications">${allApplications}</strong></p>

        ${isOwner 
            ? html`
                <div id="action-buttons">
                    <a href="/edit/${jobOffer._id}" id="edit-btn">Edit</a>
                    <a @click=${() => del(jobOffer._id)} id="delete-btn">Delete</a>
                </div>`
            : isHaveUser && canApply
                ? html`
                    <div id="action-buttons">
                        <a @click=${() => applyFunc(jobOffer._id)} id="apply-btn">Apply</a>
                    </div>`
                : nothing}
    </div>
</section>`;

let ctx = null;
 
async function detailsView(innerCtx) {
    ctx = innerCtx;

    let jobOfferId = ctx.params.id;
    let jobOffer = await getById(jobOfferId);
    let allJobOfferApplications = await getAllApplications(jobOfferId);

    let isHaveUser = false;
    let canApply = false;
    let isOwner = false;
    
    let userData = getUserData();

    if (userData != undefined) {
        isOwner = jobOffer._ownerId == userData.id;
        isHaveUser = true;

        let currentUserApplies = await getUserApplies(jobOfferId, userData.id);

        if (currentUserApplies == 0) {
            canApply = true;
        }
    }

    ctx.renderTemplate(detailsTemplate(jobOffer, allJobOfferApplications, isOwner, isHaveUser, canApply, del, apply));
}

async function del(jobOfferId) {
    let confirmation = confirm('Are you sure you want to delete this job offer?');

    if (confirmation) {
        await apiDelete(jobOfferId);
        ctx.redirect('/dashboard');
    }
}

async function apply(jobOfferId) {
    await apiApply(jobOfferId);
    ctx.redirect('/details/' + jobOfferId);
}

export {
    detailsView
}