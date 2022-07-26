import { showRegister } from './controllers/registerController.js';
import { showLogin } from './controllers/loginController.js';
import { showHome } from './controllers/homeController.js';
import { showCatalog } from './controllers/catalogController.js';
import { logout } from './controllers/logoutController.js';
import { showCreate } from './controllers/createController.js';
import { showDetails } from './controllers/detailsController.js';
import { showEdit } from './controllers/editController.js';

import { render } from '../node_modules/lit-html/lit-html.js';
import page from '../node_modules/page/page.mjs';

import { setUserNav } from './utilities.js';

page(decorateContext);
page(setUserNav);

page('/index.html', '/');
page('/home', '/');

page('/', showHome);
page('/login', showLogin);
page('/register', showRegister);
page('/logout', logout);
page('/create', showCreate)
page('/catalog/:page?', showCatalog);
page('/details/:id', showDetails);
page('/edit/:id', showEdit);

page.start();

function decorateContext(context, next) {
    context.redirect = page.redirect;
    context.renderTemplate = renderTemplate;
    context.render = render;
    next();
}

function renderTemplate(template) {
    render(template, document.querySelector('main'));
}