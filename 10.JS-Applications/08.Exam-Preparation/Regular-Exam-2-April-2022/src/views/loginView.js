import { login as apiLogin } from '../services/authentication.js';
import { createIntialSubmitFunction } from '../utilities.js';

import { html } from '../../node_modules/lit-html/lit-html.js';

const loginTemplate = (loginFunc) => html`
<section id="loginPage">
    <form @submit=${loginFunc} class="loginForm">
        <img src="/images/logo.png" alt="logo" />
        <h2>Login</h2>

        <div>
            <label for="email">Email:</label>
            <input id="email" name="email" type="text" placeholder="steven@abv.bg" value="">
        </div>

        <div>
            <label for="password">Password:</label>
            <input id="password" name="password" type="password" placeholder="********" value="">
        </div>

        <button class="btn" type="submit">Login</button>

        <p class="field">
            <span>If you don't have profile click <a href="/register">here</a></span>
        </p>
    </form>
</section>`;

const initialSubmitLoginFunc = createIntialSubmitFunction(login);

let ctx = null;

function loginView(innerCtx) {
    ctx = innerCtx;

    ctx.renderTemplate(loginTemplate(initialSubmitLoginFunc));
}

async function login({ email, password }) {

    if (email == '' || password == '') {
        alert('All field are required!');
        return;
    }

    await apiLogin(email, password);

    this.reset();

    ctx.redirect('/');
}

export {
    loginView
}