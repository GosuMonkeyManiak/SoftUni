import { getById, del as apiDel, donate as apiDonate, getDonations, getDonationsForSpecificUser } from '../services/pets.js';
import { getUserData } from '../utilities.js';

import { html, nothing } from '../../node_modules/lit-html/lit-html.js';

const detailsTemplate = (pet, isHaveUser, isOwner, petDonations, canDonate, deleteFunc, donateFunc) => html`
<section id="detailsPage">
    <div class="details">
        <div class="animalPic">
            <img src=${pet.image.slice(2)}>
        </div>
        <div>
            <div class="animalInfo">
                <h1>Name: ${pet.name}</h1>
                <h3>Breed: ${pet.breed}</h3>
                <h4>Age: ${pet.age}</h4>
                <h4>Weight: ${pet.weight}</h4>
                <h4 class="donation">Donation: ${petDonations * 100}$</h4>
            </div>

            ${isOwner 
                ? html`
                    <div class="actionBtn">
                        <a href="/edit/${pet._id}" class="edit">Edit</a>
                        <a @click=${deleteFunc.bind(null, pet._id)} class="remove">Delete</a>
                    </div>`
                : isHaveUser && canDonate
                    ? html`
                        <div class="actionBtn">
                            <a @click=${donateFunc.bind(null, pet._id)} class="donate">Donate</a>
                        </div>`
                    : nothing}
        </div>
    </div>
</section>`;

let ctx = null;

async function detailsView(innerCtx) {
    ctx = innerCtx;

    let petId = ctx.params.id;
    let pet = await getById(petId);

    let petDonations = await getDonations(petId);
    
    let isHaveUser = false;
    let isOwner = false;
    let canDonate = true;
    
    let userData = getUserData();
    
    if (userData != undefined) {
        isHaveUser = true;
        
        if (userData.id == pet._ownerId) {
            isOwner = true;
        }

        let petDonationsFromCurrentUser = await getDonationsForSpecificUser(petId, userData.id);

        if (petDonationsFromCurrentUser == 1) {
            canDonate = false;
        }
    }

    ctx.renderTemplate(detailsTemplate(pet, isHaveUser, isOwner, petDonations, canDonate, deletePet, donate));
}

async function deletePet(petId) {
    let confirmation = confirm('Are you sure want to delete this pet?');

    if (confirmation) {
        await apiDel(petId);

        ctx.redirect('/');
    }
}

async function donate(petId) {
    await apiDonate(petId)

    ctx.redirect('/details/' + petId);
}

export {
    detailsView
}