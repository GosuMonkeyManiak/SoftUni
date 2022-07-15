import { post } from '../api.js';
import { addFormHandler, clearAllInputFields, showView } from '../utilities.js';

const createView = document.querySelector('#createView');
createView.remove();

addFormHandler(createView, 'form', create)

let context = null;

function showCreate(innerContext) {
    context = innerContext;
    showView(createView);
}

async function create({ title, description, imageURL }) {
    if (title.length <= 5) {
        alert('Title should be a least 6 characters long!');
        return;
    }

    if (description.length <= 9) {
        alert('Description should be a least 10 characters long!');
        return;
    }

    if (imageURL.length <= 4) {
        alert('Image url should be a least 5 characters long!');
        return;
    }
    
    let newIdea = {
        title,
        description,
        img: imageURL
    }

    try {
        await post('/data/ideas', newIdea);   
    } catch (error) {
        alert(error.message);
        //goTo
        return;
    }

    clearAllInputFields();
    context.goTo('dashboard');
}

export {
    showCreate
}