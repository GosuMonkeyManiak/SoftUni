import { html } from '../../../node_modules/lit-html/lit-html.js';

const detailsTemplate = (furniture, isOwner, deleteFunction) => html`
<div class="container">
    <div class="row space-top">
        <div class="col-md-12">
            <h1>Furniture Details</h1>
        </div>
    </div>
    <div class="row space-top">
        <div class="col-md-4">
            <div class="card text-white bg-primary">
                <div class="card-body">
                    <img src=${furniture.img.startsWith('.') ? furniture.img.slice(1) : furniture.img} />
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <p>Make: <span>${furniture.make}</span></p>
            <p>Model: <span>${furniture.model}l</span></p>
            <p>Year: <span>${furniture.year}</span></p>
            <p>Description: <span>${furniture.description}</span></p>
            <p>Price: <span>${furniture.price} $</span></p>
            <p>Material: <span>${furniture.material.split('; ').join(', ')}</span></p>
            
            ${isOwner ? html`
                <div>
                    <a href=${`/edit/${furniture._id}`} class="btn btn-info" style="text-decoration: none">Edit</a>
                    <a @click=${() => deleteFunction(furniture)} class="btn btn-red">Delete</a>
                </div>` : ''
            }
        </div>
    </div>
</div>`;

export {
    detailsTemplate
}