import { register as apiRegister } from '../services/authentication.js';
import { createIntialSubmitFunction } from '../utilities.js';

import { html } from '../../node_modules/lit-html/lit-html.js';

const registerTemplate = (registerFunc) => html`
<section id="register">
    <div class="form">
        <h2>Register</h2>

        <form @submit=${registerFunc} class="login-form">
            <input type="text" name="email" id="register-email" placeholder="email" />
            <input type="password" name="password" id="register-password" placeholder="password" />
            <input type="password" name="re-password" id="repeat-password" placeholder="repeat password" />
            <button type="submit">register</button>

            <p class="message">Already registered? <a href="/login">Login</a></p>
        </form>
    </div>
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

    if (data.password != data['re-password']) {
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