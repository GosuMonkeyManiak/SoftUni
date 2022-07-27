import { login as apiLogin } from '../infrastructure/authentication.js';
import { createInitialSubmitFunction } from '../utilities.js';

import { loginTemplate } from '../views/login/loginView.js';

const initialSubmitLoginFunction = createInitialSubmitFunction(login);

let context = null

function showLogin(innerContext) {
    context = innerContext;
    context.renderTemplate(loginTemplate(initialSubmitLoginFunction));
}

async function login(formData) {
    let userData = {
        email: formData.email,
        password: formData.password
    };

    try {
        let data = await apiLogin(userData);

        sessionStorage.setItem('authToken', data.accessToken);
        sessionStorage.setItem('userId', data._id);
        context.redirect('/dashboard');
    } catch (error) {
        alert(error.message);
    }
}

export {
    showLogin
}