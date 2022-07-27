import page from '../node_modules/page/page.mjs';
import { render } from '../node_modules/lit-html/lit-html.js';

import { activateClickedAnchor, setCorrentUserNav } from './utilities.js';

import { showRegister } from './controllers/registerController.js';
import { showLogin } from './controllers/loginController.js';
import { logout } from './controllers/logoutController.js';
import { showDashboard } from './controllers/dashboardController.js';
import { showDetails } from './controllers/detailsController.js';
import { showCreate } from './controllers/createController.js';
import { showMyPublications } from './controllers/myPublicationsController.js';
import { showEdit } from './controllers/editController.js';

page('/index.html', '/dashboard');
page('/home', '/dashboard');
page('/', '/dashboard');

page(decorateContext)
page(setCorrentUserNav);
page(activateClickedAnchor);

page('/register', showRegister);
page('/login', showLogin);
page('/logout', logout);
page('/dashboard', showDashboard);
page('/details/:id', showDetails);
page('/edit/:id', showEdit);
page('/create', showCreate);
page('/mypublications', showMyPublications);

page.start();

function decorateContext(context, next) {
    context.renderTemplate = renderTemplate;
    context.redirect = page.redirect;
    next();
}

function renderTemplate(hydratedTemplate) {
    render(hydratedTemplate, document.querySelector('main'));
}