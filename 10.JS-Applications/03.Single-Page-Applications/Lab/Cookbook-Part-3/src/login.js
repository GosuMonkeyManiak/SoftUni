import { showHome } from './home.js';
import { showView, clearInputs } from './utilities.js';

const loginView = document.querySelector('#views #loginView');
loginView.remove();

loginView.querySelector('form').addEventListener('submit', ev => {
    ev.preventDefault();
    const formData = new FormData(ev.target);
    onSubmit([...formData.entries()].reduce((p, [k, v]) => Object.assign(p, { [k]: v }), {}));
});

function showLogin() {
    showView(loginView);
}

async function onSubmit(data) {
    const body = JSON.stringify({
        email: data.email,
        password: data.password,
    });

    try {
        const response = await fetch('http://localhost:3030/users/login', {
            method: 'post',
            headers: {
                'Content-Type': 'application/json'
            },
            body
        });

        const data = await response.json();

        if (response.status == 200) {
            sessionStorage.setItem('authToken', data.accessToken);
            sessionStorage.setItem('userId', data._id);
            clearInputs();
            showHome();
        } else {
            throw new Error(data.message);
        }
    } catch (err) {
        console.error(err.message);
    }
}

export {
    showLogin
}