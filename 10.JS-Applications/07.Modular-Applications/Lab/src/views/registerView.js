import { register } from '../api/authentication.js';
import { createIntialSubmitFunction } from '../utilities.js';

import { html } from '../dom.js';

const registerTemplate = (registerFunc) => html`
<section id="register">
    <article>
        <h2>Register</h2>
        <form @submit=${registerFunc} id="registerForm">
            <label>E-mail: <input type="text" name="email"></label>
            <label>Password: <input type="password" name="password"></label>
            <label>Repeat: <input type="password" name="rePass"></label>
            <input type="submit" value="Register">
        </form>
    </article>
</section>`;

const intialRegisterSubmitFunc = createIntialSubmitFunction(onRegister);

let context = null;

function registerView(innerContext) {
    context = innerContext;

    context.renderTemplate(registerTemplate(intialRegisterSubmitFunc));
}

async function onRegister(data) {
    if (data.password != data.rePass) {
        return alert('Passwords don\'t match');
    }

    try {
        await register(data.email, data.password);
        context.redirect('/');
    } catch (err) {
        alert(err.message);
    }
}

export {
    registerView
}