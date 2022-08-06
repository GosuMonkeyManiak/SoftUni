import { register as apiRegister } from '../services/authentication.js';
import { createIntialSubmitFunction } from '../utilities.js';

import { html } from '../../node_modules/lit-html/lit-html.js';

const registerTemplate = (registerFunc) => html`
<section id="register">
    <article class="narrow">
        <header class="pad-med">
            <h1>Register</h1>
        </header>

        <form @submit=${registerFunc} id="register-form" class="main-form pad-large">
            <div class="error"></div>
            <label>E-mail: <input type="text" name="email"></label>
            <label>Username: <input type="text" name="username"></label>
            <label>Password: <input type="password" name="password"></label>
            <label>Repeat: <input type="password" name="repass"></label>
            <input class="action cta" type="submit" value="Create Account">
        </form>

        <footer class="pad-small">Already have an account? <a href="/login" class="invert">Sign in here</a>
        </footer>
    </article>
</section>`;

const intialRegisterFunc = createIntialSubmitFunction(onRegister, '#register-form div');
let context = null;

function registerView(innerContext) {
    context = innerContext;

    context.renderTemplate(registerTemplate(intialRegisterFunc));
}

async function onRegister({ email, username, password, repass }) {
    if (email == '') {
        return 'Email is required!';
    }

    if (username.length < 3) {
        return 'Username must have at least 3 characters!';
    }

    if (password.length < 3) {
        return 'Password must have at least 3 characters!';
    }

    if (password != repass) {
        return 'Passwords don\'t match!';
    }

    this.reset();

    await apiRegister(email, username, password);
    context.redirect('/myteams');
}

export {
    registerView
}