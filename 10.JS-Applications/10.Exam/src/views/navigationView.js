import { html } from '../../node_modules/lit-html/lit-html.js';
import { getUserData } from '../utilities.js';

const navigationTemplate = (isHaveUser, logoutFunc) => html`
<div>
    <a href="/dashboard">Dashboard</a>
</div>

${isHaveUser
    ? html`
        <div class="user">
            <a href="/create">Create Offer</a>
            <a @click=${logoutFunc} >Logout</a>
        </div>`
    : html`
        <div class="guest">
            <a href="/login">Login</a>
            <a href="/register">Register</a>
        </div>`}`;

function navigationView(ctx, next) {
    let userData = getUserData();

    ctx.renderNav(navigationTemplate(userData != undefined, ctx.logout));

    next();
}

export {
    navigationView
}