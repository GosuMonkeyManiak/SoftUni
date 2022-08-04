import { getUserData } from '../utilities.js';

import { html } from '../../node_modules/lit-html/lit-html.js';

const navigationTemplate = (userData, logoutFunc) => html`
<section class="navbar-dashboard">
    <a href="/dashboard">Dashboard</a>

    ${userData != null
        ? html`
            <div id="user">
                <span>Welcome, ${userData.email}</span>
                <a class="button" href="/mybooks">My Books</a>
                <a class="button" href="/add">Add Book</a>
                <a class="button" @click=${logoutFunc}>Logout</a>
            </div>`
        : html`
            <div id="guest">
                <a class="button" href="/login">Login</a>
                <a class="button" href="/register">Register</a>
            </div>`}
</section>`;

function navigationView(ctx, next) {
    let userData = getUserData();

    ctx.renderNav(navigationTemplate(userData, ctx.logout));
    next();
}

export {
    navigationView
}