import { register as apiRegister } from '../api/data.js';
import { createIntialSubmitFunction } from '../utilities.js';

import { registerTemplate } from '../views/register/registerView.js';

let context = null;

function showRegister(innerContext) {
    context = innerContext;

    let initialSubmitFunction = createIntialSubmitFunction(register);
    context.renderTemplate(registerTemplate(initialSubmitFunction));
}

async function register(data) {
    if (data.email == '') {
        return alert('Email is required!');
    }

    if (data.password == '') {
        return alert('Password is required!');
    }

    if (data.password != data.rePass) {
        return alert('Passwords don\'t match');
    }

    try {
        await apiRegister(data.email, data.password);
        context.redirect('/catalog');
    } catch (err) {
        alert(err.message);
    }
}

export {
    showRegister
}