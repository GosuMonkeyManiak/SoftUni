import page from '../node_modules/page/page.mjs';

import { render } from '../node_modules/lit-html/lit-html.js';

import { authenticationMiddleware } from './middlewares/authentication.js';

import { logout } from './views/logout.js';

import { navigationView } from './views/navigationView.js';
import { homeView } from './views/homeView.js';
import { loginView } from './views/loginView.js';
import { registerView } from './views/registerView.js';
import { browseView } from './views/browseView.js';

page('/index.html', '/');
page('/home', '/');

page(authenticationMiddleware);
page(decorateContext);
page(navigationView);

page('/', homeView);
page('/login', loginView);
page('/register', registerView);
page('/browse/:page?', browseView);

page.start();

function decorateContext(context, next) {
    context.renderNavTemplate = renderNavTemplate;
    context.renderTemplate = renderTemplate;
    context.redirect = page.redirect;
    context.logout = logout.bind(null, context);
    next();
}

function renderNavTemplate(template) {
    render(template, document.querySelector('#titlebar nav'));
}

function renderTemplate(template) {
    render(template, document.querySelector('#content main'));
}

//fix when invalid token rest service returns