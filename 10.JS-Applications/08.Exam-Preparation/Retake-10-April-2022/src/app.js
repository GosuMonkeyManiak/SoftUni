import page from '../node_modules/page/page.mjs';

import { render } from '../node_modules/lit-html/lit-html.js';

import { showCorrectNav } from './views/navView.js';
import { showDashboard } from './views/dashboardView.js';
import { showLogin } from './views/loginView.js';
import { showRegister } from './views/registerView.js';
import { logout } from './views/logoutView.js';
import { showCreate } from './views/createView.js';
import { showDetails } from './views/detailsView.js';
import { showEdit } from './views/editView.js';
import { showUserPosts } from './views/userPosts.js';

page(decorateContext);
page(showCorrectNav);

page('/', showDashboard);
page('/login', showLogin);
page('/register', showRegister);
page('/logout', logout);
page('/create', showCreate);
page('/details/:id', showDetails);
page('/edit/:id', showEdit);
page('/myposts', showUserPosts);

page.start();

function decorateContext(ctx, next) {
    ctx.renderNav = renderNavTemplate;
    ctx.renderTemplate = renderTemplate;
    ctx.redirect = page.redirect;
    next();
}

function renderNavTemplate(template) {
    render(template, document.querySelector('nav'));
}

function renderTemplate(template) {
    render(template, document.querySelector('main'));
}