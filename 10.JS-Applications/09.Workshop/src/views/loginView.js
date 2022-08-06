import { login as apiLogin } from '../services/authentication.js';

import { html } from '../../node_modules/lit-html/lit-html.js';
import { createIntialSubmitFunction } from '../utilities.js';

const loginTemplate = (loginFunc) => html`
<section id="login">
    <div class="pad-large">
        <div class="glass narrow">
            <header class="tab layout">
                <h1 class="tab-item active">Login</h1>
                <a class="tab-item" href="/register">Register</a>
            </header>

            <form @submit=${loginFunc} class="pad-med centered">
                <label class="block centered">Username: <input class="auth-input input" type="text" name="username" /></label>
                <label class="block centered">Password: <input class="auth-input input" type="password" name="password" /></label>
                <input class="block action cta" type="submit" value="Sign In" />
            </form>

            <footer class="tab-footer">
                Don't have an account? <a class="invert" href="/register">Create one here</a>.
            </footer>
        </div>
    </div>
</section>`;

const intialSubmitLoginFunc = createIntialSubmitFunction(login);

let ctx = null;

function loginView(innerCtx) {
    ctx = innerCtx;

    ctx.renderTemplate(loginTemplate(intialSubmitLoginFunc));
}

async function login({ username, password }) {
    if (username == '' || password == '') {
        alert('All fields are required!');
        return;
    }

    await apiLogin(username, password);

    this.reset();

    ctx.redirect('/browse');
}

export {
    loginView
}