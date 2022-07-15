import { post } from '../api.js';
import { addFormHandler, clearAllInputFields, setCorrectNav, showView } from '../utilities.js';

const registerView = document.querySelector('#registerView');
registerView.remove();

registerView.querySelector('form').addEventListener('click', onNavigate);
addFormHandler(registerView, 'form', register);

let context = null;

function showRegister(innerContext) {
    context = innerContext;
    showView(registerView);
}

async function register({ email, password, repeatPassword }) {
    if (email.length <= 2) {
        alert('Email must be a least 3 characters long!');
        return;
    }

    if (password.length <= 2) {
        alert('Password must be a least 3 characters long!');
        return;
    }

    if (password != repeatPassword) {
        alert('Passwords don\'t match!');
        return;
    }

    let newUser = {
        email,
        password
    }

    let responseData;

    try {
        responseData = await post('/users/register', newUser);
    } catch (error) {
        alert(error.message);
        return;
    }

    sessionStorage.setItem('authToken', responseData.accessToken);
    sessionStorage.setItem('id', responseData._id);

    clearAllInputFields();

    setCorrectNav();
    context.goTo('home');
}

function onNavigate(event) {
    if (event.target.tagName == 'A') {
        event.preventDefault();
        context.goTo(event.target.href.substring(event.target.href.lastIndexOf('/') + 1));
    }
}

export {
    showRegister
}