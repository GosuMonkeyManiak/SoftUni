import { login as apiLogin } from '../services/authentication.js';
import { createIntialSubmitFunction, setUserData } from '../utilities.js';

import { html } from '../../node_modules/lit-html/lit-html.js';

const loginTemplate = (loginFunc) => html`
<section id="login-page" class="auth">
    <form @submit=${loginFunc} id="login">
        <h1 class="title">Login</h1>

        <article class="input-group">
            <label for="login-email">Email: </label>
            <input type="email" id="login-email" name="email">
        </article>

        <article class="input-group">
            <label for="password">Password: </label>
            <input type="password" id="password" name="password">
        </article>

        <input type="submit" class="btn submit-btn" value="Log In">
    </form>
</section>`;

const intialSubmitLoginFunc = createIntialSubmitFunction(login);

let ctx = null;

function showLogin(innerCtx) {
    ctx = innerCtx;
    ctx.renderTemplate(loginTemplate(intialSubmitLoginFunc));
}

async function login(data) {

    if (data.email == '' || data.password == '') {
        alert('All field are required!');
        return;
    }

    let userData = await apiLogin(data.email, data.password);

    setUserData(userData);

    this.reset();

    ctx.redirect('/');
}

export {
    showLogin
}