window.addEventListener('load', onLoad);

function onLoad() {
    document.querySelector('#register').addEventListener('submit', register);
    document.querySelector('#login').addEventListener('submit', login);
}

async function login(event) {
    event.preventDefault();

    let formData = new FormData(this);

    let email = formData.get('email');
    let password = formData.get('password');

    let userCredentials = {
        email,
        password
    };

    let response = await fetch('http://localhost:3030/users/login', {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(userCredentials)
    });

    if (!response.ok) {
        let error = await response.json();
        alert(error.message);
        return;
    }

    let userData = await response.json();

    sessionStorage.setItem('authToken', userData.accessToken);

    location.href = 'index.html';
}

async function register(event) {
    event.preventDefault();

    let formData = new FormData(this);

    let email = formData.get('email');
    let password = formData.get('password');
    let rePassword = formData.get('rePass');

    if (email == '' || password == '' || rePassword == '') {
        alert('All field are required!');
        return;
    }

    if (password != rePassword) {
        alert('Passwords don\'t match!');
        return;
    }

    let newUser = {
        email,
        password
    };

    let response = await fetch('http://localhost:3030/users/register', {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(newUser)
    });

    if (!response.ok) {
        let error = await response.json();
        alert(error.message);
        return;
    }

    let userData = await response.json();

    sessionStorage.setItem('authToken', userData.accessToken);

    location.href = 'index.html';
}