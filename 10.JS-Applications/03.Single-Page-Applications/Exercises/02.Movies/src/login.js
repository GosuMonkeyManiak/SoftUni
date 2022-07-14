import { showHome } from './home.js';
import { showView, addFormHandler, clearAllInputs } from './utilities.js';
import { post } from './api.js';

const loginView = document.querySelector('#container #form-login');
loginView.remove();

addFormHandler(loginView, '#login-form', login);

function showLogin() {
    showView(loginView);
}

async function login(formData) {
    let email = formData.get('email');
    let password = formData.get('password');

    let user = {
        email,
        password
    };

    let userData;

    try {
        userData = await post('/users/login', user);
    } catch (error) {
        alert(error.message);
        return;
    }

    sessionStorage.setItem('userData', JSON.stringify({
        email: userData.email,
        accessToken: userData.accessToken,
        id: userData._id
    }));

    clearAllInputs();
    showHome();
}

export {
    showLogin
}