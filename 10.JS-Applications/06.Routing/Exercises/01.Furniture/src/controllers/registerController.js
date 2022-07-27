import { register as apiRegister } from '../infrastructure/authentication.js';
import { createInitialSubmitFunction } from '../utilities.js';

import { registerTemplate } from '../views/register/registerView.js';

let initialSubmitFunction = createInitialSubmitFunction(register);

let context = null;

function showRegister(innerContext) {
    context = innerContext;
    context.renderTemplate(registerTemplate(initialSubmitFunction));
}

async function register(formData) {
    if (formData.email == '' || formData.password == '') {
        alert('All fields are required!');
        return;
    }

    if (formData.password != formData.rePass) {
        alert('Passwords don\'t match!');
        return;
    }

    let userData = {
        email: formData.email,
        password: formData.password
    };

    try {
        let data = await apiRegister(userData);

        sessionStorage.setItem('authToken', data.accessToken);
        sessionStorage.setItem('userId', data._id);
        context.redirect('/dashboard');
    } catch (error) {
        alert(error.message);
    }
}

export {
    showRegister
}