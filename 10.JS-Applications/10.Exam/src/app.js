import page from '../node_modules/page/page.mjs';

import { render } from '../node_modules/lit-html/lit-html.js';

import { navigationView } from './views/navigationView.js';
import { homeView } from './views/homeView.js';
import { loginView } from './views/loginView.js';
import { registerView } from './views/registerView.js';
import { logout } from './views/logout.js';
import { dashboardView } from './views/dashboardView.js';
import { createView } from './views/createView.js';
import { detailsView } from './views/detailsView.js';
import { editView } from './views/editView.js';

page(decorateContext);
page(navigationView);

page('/index.html', '/');
page('/home', '/');

page('/', homeView);
page('/login', loginView);
page('/register', registerView);
page('/dashboard', dashboardView);
page('/create', createView);
page('/details/:id', detailsView);
page('/edit/:id', editView);

page.start();

function decorateContext(ctx, next) {
    ctx.renderNav = renderNavTemplate;
    ctx.renderTemplate = renderTemplate;
    ctx.redirect = page.redirect;
    ctx.logout = logout.bind(null, ctx);
    next();
}

function renderNavTemplate(template) {
    render(template, document.querySelector('#wrapper header nav'));
}

function renderTemplate(template) {
    render(template, document.querySelector('#wrapper main'));
}