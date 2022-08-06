import { login as apiLogin } from '../services/authentication.js';
import { createIntialSubmitFunction } from '../utilities.js';

import { html } from '../../node_modules/lit-html/lit-html.js';

const loginTemplate = (loginFunc) => html`
<section id="login">
    <div class="form">
        <h2>Login</h2>

        <form @submit=${loginFunc} class="login-form">
            <input type="text" name="email" id="email" placeholder="email" />
            <input type="password" name="password" id="password" placeholder="password" />
            <button type="submit">login</button>
            <p class="message">
                Not registered? <a href="/register">Create an account</a>
            </p>
        </form>
    </div>
</section>`;

const intialSubmitLoginFunc = createIntialSubmitFunction(login)

let ctx = null;

function loginView(innerCtx) {
    ctx = innerCtx;
    ctx.renderTemplate(loginTemplate(intialSubmitLoginFunc));
}

async function login({ email, password }) {
    if (email == '' || password == '') {
        alert('All field are required!');
        return;
    }

    await apiLogin(email, password);

    this.reset();

    ctx.redirect('/dashboard');
}

export {
    loginView
}