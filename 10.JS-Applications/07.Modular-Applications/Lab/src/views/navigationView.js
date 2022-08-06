import { getUserData } from '../utilities.js';

import { html } from '../dom.js';

const navigationTemplate = (isHaveUser, logout) => html`
<a id="catalogLink" href="/catalog" class="active">Catalog</a>

${isHaveUser
    ? html`
        <div id="user">
            <a id="createLink" href="/create">Create Recipe</a>
            <a id="logoutBtn" href="javascript:void(0)" @click=${logout} >Logout</a>
        </div>`
    : html`
        <div id="guest">
            <a id="loginLink" href="/login">Login</a>
            <a id="registerLink" href="/register">Register</a>
        </div>`}
`;

function navigationView(context, next) {
    let userData = getUserData();

    context.renderNav(navigationTemplate(userData != undefined, context.logout));
    next();
}

export {
    navigationView
}