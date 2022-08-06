import { getById, edit as apiEdit } from '../services/jobOffers.js'
import { createIntialSubmitFunction } from '../utilities.js';

import { html } from '../../node_modules/lit-html/lit-html.js';

const editTemplate = (jobOffer, editFunc) => html`
<section id="edit">
    <div class="form">
        <h2>Edit Offer</h2>

        <form @submit=${editFunc} class="edit-form">
            <input type="text" name="title" id="job-title" placeholder="Title" .value=${jobOffer.title} />
            <input type="text" name="imageUrl" id="job-logo" placeholder="Company logo url" .value=${jobOffer.imageUrl} />
            <input type="text" name="category" id="job-category" placeholder="Category" .value=${jobOffer.category} />
            <textarea id="job-description" name="description" placeholder="Description" rows="4" cols="50">${jobOffer.description}</textarea>
            <textarea id="job-requirements" name="requirements" placeholder="Requirements" rows="4" cols="50">${jobOffer.requirements}</textarea>
            <input type="text" name="salary" id="job-salary" placeholder="Salary" .value=${jobOffer.salary} />

            <input type="hidden" name="id" .value=${jobOffer._id} />

            <button type="submit">post</button>
        </form>
    </div>
</section>`;

const intialSubmitEditFunc = createIntialSubmitFunction(edit);

let ctx = null;

async function editView(innerCtx) {
    ctx = innerCtx;
    
    let jobOfferId = ctx.params.id;
    let jobOffer = await getById(jobOfferId);

    ctx.renderTemplate(editTemplate(jobOffer, intialSubmitEditFunc));
}

async function edit({ title, imageUrl, category, description, requirements, salary, id }) {
    if (title == '' ||
        imageUrl == '' ||
        category == '' ||
        description == '' ||
        requirements == '' || 
        salary == '') {
        alert('All field are required!');
        return;
    }

    await apiEdit(id, title, imageUrl, category, description, requirements, salary);

    this.reset();

    ctx.redirect('/details/' + id);
}

export {
    editView
}