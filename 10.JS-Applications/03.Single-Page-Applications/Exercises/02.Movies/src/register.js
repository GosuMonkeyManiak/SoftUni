import { showView, addFormHandler, clearAllInputs } from './utilities.js';
import { showHome } from './home.js';
import { post } from './api.js';

const registerView = document.querySelector('#container #form-sign-up');
registerView.remove();

addFormHandler(registerView, '#register-form', register);

function showRegister() {
    showView(registerView);
}

async function register(formData) {
    let email = formData.get('email');
    let password = formData.get('password');
    let rePass = formData.get('repeatPassword');

    if (email == '' || password == '' || rePass == '') {
        alert('All fields are required!');
        return;
    }

    if (password.length <= 5) {
        alert('Password must be at least 6 characters long.');
        return;
    }

    if (password != rePass) {
        alert('Passwords don\'t match!');
        return;
    }

    let newUser = {
        email,
        password
    }

    let userData;

    try {
        userData = await post('/users/register', newUser);
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
    showRegister
}