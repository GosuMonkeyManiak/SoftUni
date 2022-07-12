import { showCreateRecipe } from './create.js';
import { showHome } from './home.js';
import { showLogin } from './login.js';
import { logout } from './logout.js';
import { showRegister } from './register.js';

document.querySelector('header nav').addEventListener('click', onNavigate);

showHome();

const views = {
    'login': showLogin,
    'register': showRegister,
    'createRecipe': showCreateRecipe,
    'home': showHome,
    'logout': logout
};

function onNavigate(event) {
    if (event.target.tagName == 'A') {
        let view = views[event.target.id];

        if (typeof view == 'function') {
            event.preventDefault();
            view();
        }
    }
}