import { showHome } from './home.js';
import { showLogin } from './login.js';
import { showRegister } from './register.js';
import { logout } from './logout.js';

document.querySelector('header nav').addEventListener('click', executeView);
document.querySelector('header nav #logout').addEventListener('click', logout);

showHome();

const views = {
    'home': showHome,
    'login': showLogin,
    'register': showRegister
}

function executeView(event) {
    if (event.target.tagName == 'A') {
        let view = views[event.target.id];

        if (typeof view == 'function') {
            event.preventDefault();
            view();   
        }
    }
}