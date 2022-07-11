import { showView, clearAllInputs } from './utility.js';
import { showHome } from './home.js';

const loginView = document.querySelector('#login-view');
loginView.remove();

function showLogin() {
    showView(loginView);

    document.querySelector('#login-view #login').addEventListener('submit', login);
}

async function login(event) {
    event.preventDefault();

    let formData = new FormData(this);

    let notificationErrors = document.querySelector('#login-view #login .notification');

    let email = formData.get('email');
    let password = formData.get('password');

    let userData = {
        email,
        password
    }

    let response = await fetch('http://localhost:3030/users/login', {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(userData)
    });

    if (!response.ok) {
        let error = await response.json();
        notificationErrors.textContent = error.message;
        return;
    }

    let serverData = await response.json();

    sessionStorage.setItem('authToken', JSON.stringify({
        email,
        accessToken: serverData.accessToken,
        id: serverData._id
    }));

    notificationErrors.textContent = '';
    clearAllInputs();

    showHome();
}

export {
    showLogin
}