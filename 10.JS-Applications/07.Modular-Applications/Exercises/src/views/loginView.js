import { login as apiLogin } from '../services/authentication.js';
import { createIntialSubmitFunction } from '../utilities.js';

import { html } from '../../node_modules/lit-html/lit-html.js';

const loginTemplate = (loginFunc) => html`
<section id="login">
    <article class="narrow">
        <header class="pad-med">
            <h1>Login</h1>
        </header>

        <form @submit=${loginFunc} id="login-form" class="main-form pad-large">
            <div class="error"></div>
            <label>E-mail: <input type="text" name="email"></label>
            <label>Password: <input type="password" name="password"></label>
            <input class="action cta" type="submit" value="Sign In">
        </form>

        <footer class="pad-small">Don't have an account? <a href="/register" class="invert">Sign up here</a>
        </footer>
    </article>
</section>`;

const intialLoginFunc = createIntialSubmitFunction(onLogin, '#login-form div');
let context = null;

function loginView(innerContext) {
    context = innerContext;

    context.renderTemplate(loginTemplate(intialLoginFunc));
}

async function onLogin({ email, password }) {
    if (email == '' || password == '') {
        return 'All field are required!';
    }

    this.reset();

    await apiLogin(email, password);
    context.redirect('/myteams');
}

export {
    loginView
}