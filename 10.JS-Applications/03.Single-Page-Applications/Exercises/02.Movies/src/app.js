import { showHome } from './home.js';
import { showLogin } from './login.js';
import { showRegister } from './register.js';
import { logout } from './logout.js';

import {} from './editMovie.js';
import {} from './movieDetails.js';


document.querySelector('nav').addEventListener('click', onNavigate);

showHome();

const views = {
    'home': showHome,
    'login': showLogin,
    'register': showRegister,
    'logout': logout
}

function onNavigate(event) {
    if (event.target.tagName == 'A') {
        const view = views[event.target.id];

        if (typeof view == 'function') {
            event.preventDefault();
            view();
        }
    }
}