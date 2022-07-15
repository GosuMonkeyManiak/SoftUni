import { post } from '../api.js';
import { getElementBySelector, showView } from '../dom.js';
import { addFormHandler } from '../utilities.js';

const createView = getElementBySelector('#create');
createView.remove();

addFormHandler(createView, 'form', create);

let ctx = null;

function showCreate(innerCtx) {
    ctx = innerCtx;
    showView(createView);
}

async function create(data) {
    const body = {
        name: data.name,
        img: data.img,
        ingredients: data.ingredients.split('\n').map(l => l.trim()).filter(l => l != ''),
        steps: data.steps.split('\n').map(l => l.trim()).filter(l => l != '')
    };

    let responseData;
    
    try {
        responseData = await post('/data/recipes', body);
    } catch (err) {
        alert(err.message);
        return;
    }

    ctx.getViewFunction('detailsLink').call(null, responseData._id);
}

export {
    showCreate
}