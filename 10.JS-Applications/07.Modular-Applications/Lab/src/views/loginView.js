import { login } from '../api/authentication.js';
import { createIntialSubmitFunction } from '../utilities.js';

import { html } from '../dom.js';

const loginTemplate = (loginFunc) => html`
<section id="login">
    <article>
        <h2>Login</h2>
        <form @submit=${loginFunc} id="loginForm">
            <label>E-mail: <input type="text" name="email"></label>
            <label>Password: <input type="password" name="password"></label>
            <input type="submit" value="Login">
        </form>
    </article>
</section>`;

const intialLoginSubmitFunc = createIntialSubmitFunction(onLogin);

let context = null;

function loginView(innerContext) {
    context = innerContext;
    
    context.renderTemplate(loginTemplate(intialLoginSubmitFunc));
}

async function onLogin(data) {
    try {
        await login(data.email, data.password);
        context.redirect('/');
    } catch (err) {
        alert(err.message);
    }
}

export {
    loginView
}