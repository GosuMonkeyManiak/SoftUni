import { getFurnitureById, updateFurnitureById } from '../infrastructure/data.js';
import { createInitialSubmitFunction } from '../utilities.js';

import { editTemplate } from '../views/edit/editView.js';

const initialSubmitFunction = createInitialSubmitFunction(edit);

let context = null;

async function showEdit(innerContext) {
    context = innerContext;

    let furnitureId = context.params.id;

    try {
        let furniture = await getFurnitureById(furnitureId);

        context.renderTemplate(editTemplate(furniture, initialSubmitFunction))
    } catch (error) {
        alert(error.message);   
    }
}

async function edit(formData) {
    let isInputValid = true;

    let makeInput = document.querySelector('input[name="make"]');
    let modelInput = document.querySelector('input[name="model"]');
    let yearInput = document.querySelector('input[name="year"]');
    let descriptionInput = document.querySelector('input[name="description"]');
    let priceInput = document.querySelector('input[name="price"]');
    let imgInput = document.querySelector('input[name="img"]');
    let materialInput = document.querySelector('input[name="material"]');
    
    if (formData.make.length <= 3) {
        isInputValid = false;
        makeInput.classList.remove('is-valid');
        makeInput.classList.add('is-invalid');
    } else {
        makeInput.classList.remove('is-invalid');
        makeInput.classList.add('is-valid');
    }

    if (formData.model.length <= 3) {
        isInputValid = false;
        modelInput.classList.remove('is-valid');
        modelInput.classList.add('is-invalid');
    } else {
        modelInput.classList.remove('is-invalid');
        modelInput.classList.add('is-valid');
    }

    if (Number(formData.year) < 1950 || Number(formData.year) > 2050) {
        isInputValid = false;
        yearInput.classList.remove('is-valid');
        yearInput.classList.add('is-invalid');
    } else {
        yearInput.classList.remove('is-invalid');
        yearInput.classList.add('is-valid');
    }

    if (formData.description.length <= 10) {
        isInputValid = false;
        descriptionInput.classList.remove('is-valid');
        descriptionInput.classList.add('is-invalid');
    } else {
        descriptionInput.classList.remove('is-invalid');
        descriptionInput.classList.add('is-valid');
    }

    if (Number(formData.price) <= 0) {
        isInputValid = false;
        priceInput.classList.remove('is-valid');
        priceInput.classList.add('is-invalid');
    } else {
        priceInput.classList.remove('is-invalid');
        priceInput.classList.add('is-valid');
    }

    if (formData.img == '') {
        isInputValid = false;
        imgInput.classList.remove('is-valid');
        imgInput.classList.add('is-invalid');
    } else {
        imgInput.classList.remove('is-invalid');
        imgInput.classList.add('is-valid');
    }

    materialInput.classList.add('is-valid');

    if (!isInputValid) {
        return;
    }

    let editedFurniture = {
        make: formData.make,
        model: formData.model,
        year: formData.year,
        description: formData.description,
        price: formData.price,
        img: formData.img,
        material: formData.material
    };

    try {
        await updateFurnitureById(formData.id, editedFurniture);

        context.redirect('/dashboard');
    } catch (error) {
        alert(error.message);
    }
}

export {
    showEdit
}