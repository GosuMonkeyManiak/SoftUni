import { showView } from '../utilities.js';

const homeView = document.querySelector('#homeView');
homeView.remove();

let context = null;

function showHome(innerContext) {
    context = innerContext;
    showView(homeView);
}

export {
    showHome
}