import { register as apiRegister } from '../services/authentication.js';
import { createIntialSubmitFunction, setUserData } from '../utilities.js';

import { html } from '../../node_modules/lit-html/lit-html.js';

const registerTemplate = (registerFunc) => html`
<section id="register-page" class="auth">
    <form @submit=${registerFunc} id="register">
        <h1 class="title">Register</h1>

        <article class="input-group">
            <label for="register-email">Email: </label>
            <input type="email" id="register-email" name="email">
        </article>

        <article class="input-group">
            <label for="register-password">Password: </label>
            <input type="password" id="register-password" name="password">
        </article>

        <article class="input-group">
            <label for="repeat-password">Repeat Password: </label>
            <input type="password" id="repeat-password" name="repeatPassword">
        </article>

        <input type="submit" class="btn submit-btn" value="Register">
    </form>
</section>`;

const intialSubmitRegisterFunc = createIntialSubmitFunction(register);

let ctx = null;

function showRegister(innerCtx) {
    ctx = innerCtx;
    ctx.renderTemplate(registerTemplate(intialSubmitRegisterFunc));
}

async function register(data) {

    if (data.email == '' || data.password == '') {
        alert('Email and Password field are required!');
        return;
    }

    if (data.password != data.repeatPassword) {
        alert('Passwords don\'t match.');
        return;
    }

    let userData = await apiRegister(data.email, data.password);

    setUserData(userData);

    this.reset();

    ctx.redirect('/');
}

export {
    showRegister
}