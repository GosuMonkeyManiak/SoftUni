import { html } from '../../../node_modules/lit-html/lit-html.js';

const publicationTemplate = (furnitures) => html`
<div class="container">
    <div class="row space-top">
        <div class="col-md-12">
            <h1>My Furniture</h1>
            <p>This is a list of your publications.</p>
        </div>
    </div>
    <div class="row space-top">
        ${furnitures.map(furnitureTemplate)}
    </div>
</div>`;

const furnitureTemplate = (furniture) => html`
<div class="col-md-4">
    <div class="card text-white bg-primary">
        <div class="card-body">
            <img src=${furniture.img.startsWith('.') ? furniture.img.slice(1) : furniture.img} />
            <p>${furniture.description}</p>
            <footer>
                <p>Price: <span>${furniture.price} $</span></p>
            </footer>
            <div>
                <a href=${`/details/${furniture._id}`} class="btn btn-info">Details</a>
            </div>
        </div>
    </div>
</div>`;

export {
    publicationTemplate
}