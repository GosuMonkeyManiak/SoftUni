import { showView } from './utilities.js';

const homeView = document.querySelector('#years');
homeView.remove();

function showHome() {
    showView(homeView);
}

export {
    showHome
}