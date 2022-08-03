import { getUserData } from '../utilities.js';

import { html } from '../../node_modules/lit-html/lit-html.js';

const navigationTemplate = (isHaveUser) => html`
<section class="logo">
    <img src="/images/logo.png" alt="logo">
</section>

<ul>
    <li>
        <a href="/">Home</a>
    </li>
    <li>
        <a href="/dashboard">Dashboard</a>
    </li>

    ${isHaveUser 
        ? html`
            <li>
                <a href="/create">Create Postcard</a>
            </li>
            <li>
                <a href="/logout" >Logout</a>
            </li>`
        : html `
            <li>
                <a href="/login">Login</a>
            </li>
            <li>
                <a href="/register">Register</a>
            </li>`}
</ul>`;

function navigationView(ctx, next) {
    ctx.renderNav(navigationTemplate(getUserData()));
    next();
}

export {
    navigationView
}