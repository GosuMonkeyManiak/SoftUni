import { create as apiCreate } from '../services/jobOffers.js';
import { createIntialSubmitFunction } from '../utilities.js';

import { html } from '../../node_modules/lit-html/lit-html.js';

const createTemplate = (registerFunc) => html`
<section id="create">
    <div class="form">
        <h2>Create Offer</h2>

        <form @submit=${registerFunc} class="create-form">
            <input type="text" name="title" id="job-title" placeholder="Title" />
            <input type="text" name="imageUrl" id="job-logo" placeholder="Company logo url" />
            <input type="text" name="category" id="job-category" placeholder="Category" />
            <textarea id="job-description" name="description" placeholder="Description" rows="4" cols="50"></textarea>
            <textarea id="job-requirements" name="requirements" placeholder="Requirements" rows="4" cols="50"></textarea>
            <input type="text" name="salary" id="job-salary" placeholder="Salary" />

            <button type="submit">post</button>
        </form>
    </div>
</section>`;

const intialSubmitCreateFunc = createIntialSubmitFunction(create);

let ctx = null;

function createView(innerCtx) {
    ctx = innerCtx;
    ctx.renderTemplate(createTemplate(intialSubmitCreateFunc));
}

async function create({ title, imageUrl, category, description, requirements, salary }) {
    if (title == '' ||
        imageUrl == '' || 
        category == '' ||
        description == '' ||
        requirements == '') {
        alert('All field are required!');
        return;
    }

    if (isNaN(salary)) {
        alert('Salary must be a number!');
        return;
    }

    await apiCreate(title, imageUrl, category, description, requirements, salary);

    this.reset();

    ctx.redirect('/dashboard');
}

export {
    createView
}