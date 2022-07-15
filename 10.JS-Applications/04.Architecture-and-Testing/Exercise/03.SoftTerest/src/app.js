import { showLogin } from './views/login.js';
import { showRegister } from './views/register.js'
import { showCreate } from './views/create.js';
import { showDetails, setupDetails } from './views/details.js';
import { showHome } from './views/home.js';
import { showDashborad } from './views/dashboard.js';
import { logout } from './views/logout.js';
import { setCorrectNav } from './utilities.js';

const context = {
    goTo,
    getViewFunction
}

document.querySelector('nav').addEventListener('click', onNavigate);
setupDetails(context);

const views = {
    'home': showHome,
    'login': showLogin,
    'register': showRegister,
    'logout': logout,
    'dashboard': showDashborad,
    'create': showCreate,
    'details': showDetails
}

setCorrectNav();
showHome(context);

function onNavigate(event) {
    let isExecuted;

    if (event.target.tagName == 'A') {
        isExecuted = goTo(event.target.id);
    } else if (event.target.tagName == 'IMG') {
        isExecuted = goTo(event.target.parentElement.id);
    }

    if (isExecuted) {
        event.preventDefault();
    }
}

function goTo(viewName) {
    let view = views[viewName];

    if (typeof view == 'function') {
        view(context);
        return true;
    }

    return false;
}

function getViewFunction(viewName) {
    return views[viewName];
}