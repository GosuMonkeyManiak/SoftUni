import { getUserData } from '../utilities.js';

import { html } from '../../node_modules/lit-html/lit-html.js';

const navTemplate = (userData) => html`
<a href="/">Dashboard</a>

${userData 
    ? html`
    <div id="user">
        <a href="/myposts">My Posts</a>
        <a href="/create">Create Post</a>
        <a href="/logout">Logout</a>
    </div>`
    : html`
    <div id="guest">
        <a href="/login">Login</a>
        <a href="/register">Register</a>
    </div>`}
`;

function showCorrectNav(ctx, next) {
    let userData = getUserData();

    ctx.renderNav(navTemplate(userData));
    next();
}

export {
    showCorrectNav
}