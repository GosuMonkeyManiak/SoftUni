import { post } from '../api.js';
import { addFormHandler, clearAllInputFields, setCorrectNav, showView } from '../utilities.js';

const loginView = document.querySelector('#loginView');
loginView.remove();

loginView.querySelector('form').addEventListener('click', onNavigate);
addFormHandler(loginView, 'form', login);

let context = null;

function showLogin(innerContext) {
    context = innerContext;
    showView(loginView);
}

async function login({ email, password }) {
    let user = {
        email,
        password
    };

    let responseData;

    try {
        responseData = await post('/users/login', user);
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
    showLogin
}