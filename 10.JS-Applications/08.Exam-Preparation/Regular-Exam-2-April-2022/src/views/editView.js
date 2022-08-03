import { getById, edit as apiEdit } from '../services/pets.js';

import { html } from '../../node_modules/lit-html/lit-html.js';
import { createIntialSubmitFunction } from '../utilities.js';

const editTemplate = (pet, editFunc) => html`
<section id="editPage">
    <form @submit=${editFunc} class="editForm">
        <img .src=${pet.image.slice(2)}>
        <div>
            <h2>Edit PetPal</h2>
            <div class="name">
                <label for="name">Name:</label>
                <input name="name" id="name" type="text" .value=${pet.name}>
            </div>
            <div class="breed">
                <label for="breed">Breed:</label>
                <input name="breed" id="breed" type="text" .value=${pet.breed}>
            </div>
            <div class="Age">
                <label for="age">Age:</label>
                <input name="age" id="age" type="text" .value=${pet.age}>
            </div>
            <div class="weight">
                <label for="weight">Weight:</label>
                <input name="weight" id="weight" type="text" .value=${pet.weight}>
            </div>
            <div class="image">
                <label for="image">Image:</label>
                <input name="image" id="image" type="text" .value=${pet.image}>
            </div>
            <button class="btn" type="submit">Edit Pet</button>

            <input type="hidden" name="id" .value=${pet._id} />
        </div>
    </form>
</section>`;

const intialSubmitEditFunc = createIntialSubmitFunction(edit);

let ctx = null;

async function editView(innerCtx) {
    ctx = innerCtx;

    let petId = ctx.params.id;
    let pet = await getById(petId);

    ctx.renderTemplate(editTemplate(pet, intialSubmitEditFunc));
}

async function edit({ name, breed, age, weight, image, id }) {

    if (name == '' ||
        breed == '' ||
        age == '' ||
        weight == '' ||
        image == '') {
        alert('All field are required!');
        return;
    }

    await apiEdit(id, name, breed, age, weight, image);

    ctx.redirect('/details/' + id);
}

export {
    editView
}