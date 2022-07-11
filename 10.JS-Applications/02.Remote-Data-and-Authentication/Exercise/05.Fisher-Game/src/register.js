import { showView, clearAllInputs } from './utility.js';
import { showHome } from './home.js';

const registerView = document.querySelector('#register-view');
registerView.remove();

function showRegister() {
    showView(registerView);

    document.querySelector('#register-view #register').addEventListener('submit', register);
}

async function register(event) {
    event.preventDefault();

    let formData = new FormData(this);

    let notificationErrors = document.querySelector('#register .notification');

    let email = formData.get('email');
    let password = formData.get('password');
    let rePassword = formData.get('rePass');

    if (email == '' || password == '' || rePassword == '') {
        notificationErrors.textContent = 'All fields are required!';
        return;
    }

    if (password != rePassword) {
        notificationErrors.textContent = 'Passwords don\'t match!';
        return;
    }

    let newUser = {
        email,
        password
    }

    let response = await fetch('http://localhost:3030/users/register', {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(newUser)
    });

    if (!response.ok) {
        let error = await response.json();
        notificationErrors.textContent = error.message;
        return;
    }

    let userData = await response.json();

    sessionStorage.setItem('authToken', JSON.stringify({
        email,
        accessToken: userData.accessToken,
        id: userData._id
    }));

    notificationErrors.textContent = '';
    clearAllInputs();

    showHome();
}

export {
    showRegister
}