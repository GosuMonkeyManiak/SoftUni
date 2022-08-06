import { getUserData } from '../utilities.js';

import { html } from '../../node_modules/lit-html/lit-html.js';

const navigationTemplate = (isHaveUser, logoutFunc) => html`
<a class="logotype" href="/">
    <i class="fas fa-question-circle"></i>
    <i class="merge fas fa-check-circle"></i>
    <span>Quiz Fever</span>
</a>

<div class="navigation">
    <a class="nav-link" href="/browse">Browse</a>

    ${isHaveUser
        ? html`
            <div id="user-nav">
                <a class="nav-link" href="/createQuiz">Create</a>
                <a class="nav-link profile-link" href="/profile">
                    <i class="fas fa-user-circle"></i>
                </a>
                <a id="logoutBtn" class="nav-link" @click=${logoutFunc} >Logout</a>
            </div>`
        : html`
            <div id="guest-nav">
                <a class="nav-link" href="/login">Sign in</a>
            </div>`}
</div>`;

function navigationView(ctx, next) {
    let isHaveUser = getUserData() != null;
    
    ctx.renderNavTemplate(navigationTemplate(isHaveUser, ctx.logout));
    next();
}

export {
    navigationView
}