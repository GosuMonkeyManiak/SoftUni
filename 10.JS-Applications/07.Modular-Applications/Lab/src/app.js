import page from '../node_modules/page/page.mjs';

import { renderNav, renderTemplate } from './dom.js';
import { logout } from './views/logout.js';

import { navigationView } from './views/navigationView.js';
import { homeView } from './views/homeView.js';
import { catalogView } from './views/catalogView.js';
import { detailsView } from './views/detailsView.js';
import { loginView } from './views/loginView.js';
import { registerView } from './views/registerView.js';
import { createView } from './views/createView.js';
import { editView } from './views/editView.js';
import { deletedView } from './views/deletedView.js';

page('/index.html', '/');
page('/home', '/');

page(decorateContext);
page(navigationView);

page('/', homeView);
page('/catalog/:page?', catalogView);
page('/details/:id', detailsView);
page('/login', loginView);
page('/register', registerView);
page('/create', createView);
page('/edit/:id', editView);
page('/deleted/:id', deletedView)

page.start();

function decorateContext(context, next) {
    context.renderNav = renderNav;
    context.renderTemplate = renderTemplate;
    context.redirect = page.redirect;
    context.logout = logout.bind(context);
    next();
}

