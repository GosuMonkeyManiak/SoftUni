import page from '../node_modules/page/page.mjs';
import { render } from '../node_modules/lit-html/lit-html.js';

import { authorization } from './middlewares/authorization.js';
import { ownerShipForQuiz } from './middlewares/ownership.js';

import { navigationView } from './views/navigationView.js';
import { homeView } from './views/homeView.js';
import { loginView } from './views/loginView.js';
import { registerView } from './views/registerView.js';
import { logout } from './views/logout.js';
import { createQuizView } from './views/createQuizView.js';
import { getUserData } from './utilities.js';
import { editorView } from './views/edittorView.js';
import { profileView } from './views/profileView.js';

page(decorateContext);
page(navigationView);

page('/index.html', '/');
page('/home', '/');

page('/', homeView);
page('/login', loginView);
page('/register', registerView);
page('/createQuiz', authorization, createQuizView);
page('/editor/:id', authorization, ownerShipForQuiz, editorView);
page('/profile', authorization, profileView);

page.start();

function decorateContext(ctx, next) {
    ctx.renderNavTemplate = renderNavTemplate;
    ctx.renderTemplate = renderTemplate;
    ctx.redirect = page.redirect;
    ctx.logout = logout.bind(null, ctx);
    ctx.render = render;
    ctx.getUserData = getUserData;
    next();
}

function renderNavTemplate(template) {
    render(template, document.querySelector('#titlebar nav'));
}

function renderTemplate(template) {
    render(template, document.querySelector('#content'));
}