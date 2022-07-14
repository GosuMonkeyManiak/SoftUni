import { showHome } from "./home.js";

document.querySelector('header nav ul li a').addEventListener('click', onNavigate);

showHome();

const views = {
    'home': showHome
}

function onNavigate(event) {
    let view = views[event.target.id];

    if (typeof view == 'function') {
        event.preventDefault();
        view();
    }
}