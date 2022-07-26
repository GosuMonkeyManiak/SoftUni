import { html } from '../../../node_modules/lit-html/lit-html.js';

const loginTemplate = (loginFunction) => html`
<section id="login">
    <article>
        <h2>Login</h2>
        <form @submit=${loginFunction} id="loginForm">
            <label>E-mail: <input type="text" name="email"></label>
            <label>Password: <input type="password" name="password"></label>
            <input type="submit" value="Login">
        </form>
    </article>
</section>`;


export {
    loginTemplate
}