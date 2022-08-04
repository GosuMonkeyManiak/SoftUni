import page from '../node_modules/page/page.mjs';
import { render } from '../node_modules/lit-html/lit-html.js';

import { navigationView } from './views/navigationView.js';
import { loginView } from './views/loginView.js';
import { registerView } from './views/registerView.js';
import { logout } from './views/logout.js';
import { addView } from './views/addView.js';
import { dashboardView } from './views/dashboardView.js';
import { detailsView } from './views/detailsView.js';
import { editView } from './views/editView.js';
import { myBooksView } from './views/mybooksView.js';

page(decorateContext);
page(navigationView);

page('/index.html', '/dashboard');
page('/', '/dashboard');
page('/home', '/dashboard');

page('/login', loginView);
page('/register', registerView);
page('/add', addView);
page('/dashboard', dashboardView);
page('/details/:id', detailsView);
page('/edit/:id', editView);
page('/mybooks', myBooksView);

page.start();


function decorateContext(ctx, next) {
    ctx.renderNav = renderNavTemplate;
    ctx.renderTemplate = renderTemplate;
    ctx.redirect = page.redirect;
    ctx.logout = logout.bind(null, ctx);
    next();
}

function renderNavTemplate(template) {
    render(template, document.querySelector('#site-header nav'));
}

function renderTemplate(template) {
    render(template, document.querySelector('#site-content'));
}