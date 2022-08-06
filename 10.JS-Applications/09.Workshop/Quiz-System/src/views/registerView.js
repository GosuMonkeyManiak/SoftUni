import { register as apiRegister } from '../services/authentication.js';
import { createIntialSubmitFunction } from '../utilities.js';

import { html } from '../../node_modules/lit-html/lit-html.js';

const registerTemplate = (registerFunc) => html`
<section id="register">
    <div class="pad-large">
        <div class="glass narrow">
            <header class="tab layout">
                <a class="tab-item" href="/login">Login</a>
                <h1 class="tab-item active">Register</h1>
            </header>

            <form @submit=${registerFunc} class="pad-med centered">
                <label class="block centered">Username: <input class="auth-input input" type="text" name="username" /></label>
                <!-- <label class="block centered">Email: <input class="auth-input input" type="text" name="email" /></label> -->
                <label class="block centered">Password: <input class="auth-input input" type="password" name="password" /></label>
                <label class="block centered">Repeat: <input class="auth-input input" type="password" name="repass" /></label>
                <input class="block action cta" type="submit" value="Create Account" />
            </form>

            <footer class="tab-footer">
                Already have an account? <a class="invert" href="/login">Sign in here</a>.
            </footer>
        </div>
    </div>
</section>`;

const intialSubmitRegisterFunc = createIntialSubmitFunction(register);

let ctx = null;

function registerView(innerCtx) {
    ctx = innerCtx;
    ctx.renderTemplate(registerTemplate(intialSubmitRegisterFunc));
}

async function register({ username, password, repass}) {
    if (username == '') {
        alert('Username is required!');
        return;
    }

    if (password == '') {
        alert('Password is required!');
        return;
    }

    if (password != repass) {
        alert('Passwords don\'t match!');
        return;
    }

    await apiRegister(username, password);

    this.reset();

    ctx.redirect('/browse');
}

export {
    registerView
}