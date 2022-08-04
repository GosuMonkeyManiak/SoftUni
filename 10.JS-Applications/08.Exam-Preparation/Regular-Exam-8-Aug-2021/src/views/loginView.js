import { login as apiLogin } from '../services/authentication.js';
import { createIntialSubmitFunction } from '../utilities.js';

import { html } from '../../node_modules/lit-html/lit-html.js';

const loginTemplate = (loginFunc) => html`
<section id="login-page" class="login">
    <form @submit=${loginFunc} id="login-form">
        <fieldset>
            <legend>Login Form</legend>
            <p class="field">
                <label for="email">Email</label>
                <span class="input">
                    <input type="text" name="email" id="email" placeholder="Email">
                </span>
            </p>
            <p class="field">
                <label for="password">Password</label>
                <span class="input">
                    <input type="password" name="password" id="password" placeholder="Password">
                </span>
            </p>
            <input class="button submit" type="submit" value="Login">
        </fieldset>
    </form>
</section>`;

const intialSubmitLoginFunc = createIntialSubmitFunction(login);

let ctx = null;

function loginView(innerCtx) {
    ctx = innerCtx;

    ctx.renderTemplate(loginTemplate(intialSubmitLoginFunc));
}

async function login({ email, password }) {
    if (email == '' || password == '') {
        alert('All field are required!');
        return;
    }

    await apiLogin(email, password);

    this.reset();

    ctx.redirect('/dashboard');
}

export {
    loginView
}