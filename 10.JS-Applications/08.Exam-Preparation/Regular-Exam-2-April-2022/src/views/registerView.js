import { register as apiRegister } from '../services/authentication.js';
import { createIntialSubmitFunction } from '../utilities.js';

import { html } from '../../node_modules/lit-html/lit-html.js';

const registerTemplate = (registerFunc) => html`
<section id="registerPage">
    <form @submit=${registerFunc} class="registerForm">
        <img src="/images/logo.png" alt="logo" />
        <h2>Register</h2>
        <div class="on-dark">
            <label for="email">Email:</label>
            <input id="email" name="email" type="text" placeholder="steven@abv.bg" value="">
        </div>

        <div class="on-dark">
            <label for="password">Password:</label>
            <input id="password" name="password" type="password" placeholder="********" value="">
        </div>

        <div class="on-dark">
            <label for="repeatPassword">Repeat Password:</label>
            <input id="repeatPassword" name="repeatPassword" type="password" placeholder="********" value="">
        </div>

        <button class="btn" type="submit">Register</button>

        <p class="field">
            <span>If you have profile click <a href="#">here</a></span>
        </p>
    </form>
</section>`;

const intialSubmitRegisterFunc = createIntialSubmitFunction(register);

let ctx = null;

function registerView(innerCtx) {
    ctx = innerCtx;

    ctx.renderTemplate(registerTemplate(intialSubmitRegisterFunc));
}

async function register({ email, password, repeatPassword }) {

    if (email == '') {
        alert('Email is required!');
        return;
    }

    if (password == '') {
        alert('Password is required!');
        return;
    }

    if (password != repeatPassword) {
        alert('Passwords don\'t match!');
        return;
    }

    await apiRegister(email, password);

    this.reset();

    ctx.redirect('/');
}

export {
    registerView
}