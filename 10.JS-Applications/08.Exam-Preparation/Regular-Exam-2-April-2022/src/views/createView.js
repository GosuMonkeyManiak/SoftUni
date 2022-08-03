import { create as apiCreate } from '../services/pets.js';
import { createIntialSubmitFunction } from '../utilities.js';

import { html } from '../../node_modules/lit-html/lit-html.js';

const createTemplate = (createFunc) => html`
<section id="createPage">
    <form @submit=${createFunc} class="createForm">
        <img src="/images/cat-create.jpg">
        <div>
            <h2>Create PetPal</h2>
            <div class="name">
                <label for="name">Name:</label>
                <input name="name" id="name" type="text" placeholder="Max">
            </div>
            <div class="breed">
                <label for="breed">Breed:</label>
                <input name="breed" id="breed" type="text" placeholder="Shiba Inu">
            </div>
            <div class="Age">
                <label for="age">Age:</label>
                <input name="age" id="age" type="text" placeholder="2 years">
            </div>
            <div class="weight">
                <label for="weight">Weight:</label>
                <input name="weight" id="weight" type="text" placeholder="5kg">
            </div>
            <div class="image">
                <label for="image">Image:</label>
                <input name="image" id="image" type="text" placeholder="../image/dog.jpeg">
            </div>
            <button class="btn" type="submit">Create Pet</button>
        </div>
    </form>
</section>`

const initialSubmitCreateFunc = createIntialSubmitFunction(create);

let ctx = null;

function createView(innerCtx) {
    ctx = innerCtx;

    ctx.renderTemplate(createTemplate(initialSubmitCreateFunc));
}

async function create({ name, breed, age, weight, image }) {

    if (name == '' ||
        breed == '' ||
        age == '' ||
        weight == '' ||
        image == '') {
        alert('All field are required!');
        return;
    }

    await apiCreate(name, breed, age, weight, image);

    ctx.redirect('/');
}

export {
    createView
}