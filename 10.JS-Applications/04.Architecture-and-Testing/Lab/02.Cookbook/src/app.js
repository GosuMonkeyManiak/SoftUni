import { showCatalog } from './views/catalog.js';
import { showCreate } from './views/create.js';
import { showLogin } from './views/login.js';
import { showRegister } from './views/register.js';
import { setupDetails, showDetails } from './views/details.js';
import { setupEdit, showEdit } from './views/edit.js';
import { getElementBySelector, setUserNav } from './dom.js';
import { logout } from './views/logout.js';


window.addEventListener('load', async () => {
    const context = {
        goTo,
        getViewFunction
    }

    setupDetails(context);
    setupEdit(context);
    getElementBySelector('#views').remove();
    
    const views = {
        'catalogLink': showCatalog,
        'createLink': showCreate,
        'loginLink': showLogin,
        'registerLink': showRegister,
        'logoutBtn': logout,
        'detailsLink': showDetails,
        'editLink': showEdit
    };
    getElementBySelector('header nav').addEventListener('click', onNavigation);
    
    setUserNav();
    showCatalog(context);

    function onNavigation(event) {
        if (event.target.tagName == 'A') {
            event.preventDefault();
            goTo(event.target.id);
        }
    }

    function goTo(viewName) {
        const view = views[viewName];

        if (typeof view == 'function') {
            view(context);
        }
    }

    function getViewFunction(viewName) {
        return views[viewName];
    }

    // function setActiveNav(targetId) {
    //     [...nav.querySelectorAll('a')].forEach(a => a.id == targetId ? a.classList.add('active') : a.classList.remove('active'));
    // }
});
