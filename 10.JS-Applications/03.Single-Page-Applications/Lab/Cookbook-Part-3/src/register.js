import { showHome } from './home.js';
import { showView, clearInputs } from './utilities.js';

const registerView = document.querySelector('#views #registerView');
registerView.remove();

registerView.querySelector('form').addEventListener('submit', ev => {
    ev.preventDefault();
    const formData = new FormData(ev.target);
    onSubmit([...formData.entries()].reduce((p, [k, v]) => Object.assign(p, { [k]: v }), {}));
});

function showRegister() {
    showView(registerView);
}

async function onSubmit(data) {
    if (data.password != data.rePass) {
        return console.error('Passwords don\'t match');
    }

    const body = JSON.stringify({
        email: data.email,
        password: data.password,
    });

    try {
        const response = await fetch('http://localhost:3030/users/register', {
            method: 'post',
            headers: {
                'Content-Type': 'application/json'
            },
            body: body
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
    showRegister
}