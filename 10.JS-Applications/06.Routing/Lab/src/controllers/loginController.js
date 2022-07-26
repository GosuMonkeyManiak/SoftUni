import { login as apiLogin } from '../api/data.js';
import { createIntialSubmitFunction } from '../utilities.js';

import { loginTemplate } from '../views/login/loginView.js';

let context = null;

function showLogin(innerContext) {
    context = innerContext;

    let initialSubmitFunction = createIntialSubmitFunction(login);
    context.renderTemplate(loginTemplate(initialSubmitFunction));
}

async function login(data) {
    try {
        await apiLogin(data.email, data.password);
        context.redirect('/catalog');
    } catch (err) {
        alert(err.message);
    }
}

export {
    showLogin
}