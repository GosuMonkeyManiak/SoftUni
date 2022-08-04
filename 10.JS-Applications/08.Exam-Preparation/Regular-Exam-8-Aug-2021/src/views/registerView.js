import { register as apiRegister } from '../services/authentication.js';
import { createIntialSubmitFunction } from '../utilities.js';

import { html } from '../../node_modules/lit-html/lit-html.js';

const registerTemplate = (registerFunc) => html`
<section id="register-page" class="register">
    <form @submit=${registerFunc} id="register-form">
        <fieldset>
            <legend>Register Form</legend>
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
            <p class="field">
                <label for="repeat-pass">Repeat Password</label>
                <span class="input">
                    <input type="password" name="confirm-pass" id="repeat-pass" placeholder="Repeat Password">
                </span>
            </p>
            <input class="button submit" type="submit" value="Register">
        </fieldset>
    </form>
</section>`;

const intialSubmitRegisterFunc = createIntialSubmitFunction(register);

let ctx = null;

function registerView(innerCtx) {
    ctx = innerCtx;

    ctx.renderTemplate(registerTemplate(intialSubmitRegisterFunc));
}

async function register(data) {

    if (data.email == '') {
        alert('Email is required!');
        return;
    }

    if (data.password == '') {
        alert('Password is required!');
        return;
    }

    if (data.password != data['confirm-pass']) {
        alert('Passwords don\'t match!');
        return;
    }

    await apiRegister(data.email, data.password);

    this.reset();

    ctx.redirect('/dashboard');
}

export {
    registerView
}