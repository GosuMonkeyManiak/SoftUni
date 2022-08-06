import { html } from '../../node_modules/lit-html/lit-html.js';

const navigationTemplate = (isHaveUser, logoutFunc) => html`
<a href="/browse" class="action">Browse Teams</a>

${isHaveUser
    ? html`
        <a href="/myteams" class="action">My Teams</a>
        <a @click=${logoutFunc} href="javascript:void(0)" class="action">Logout</a>`
    : html`
        <a href="/login" class="action">Login</a>
        <a href="/register" class="action">Register</a>`}
`;

function navigationView(context, next) {
    context.renderNavTemplate(navigationTemplate(context.isHaveUser, context.logout));
    next();
}

export {
    navigationView
}