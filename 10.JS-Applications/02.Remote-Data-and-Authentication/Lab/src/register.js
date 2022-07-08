document.querySelector('form').addEventListener('submit', register);

async function register(event) {
    event.preventDefault();

    let formData = new FormData(this);

    if (formData.get('email') == '') {
        alert('Email is required!');
        return;
    }

    if (formData.get('password') != formData.get('rePass')) {
        alert('Password and Repeat don\'t match!');
        return;
    }

    let data = {
        email: formData.get('email'),
        password: formData.get('password')
    }

    try {

        let response = await fetch('http://localhost:3030/users/register', {
            method: 'post',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify(data)
        });

        let responseData = await response.json();

        if (response.status != 200) {
            throw new Error(responseData.message);
        }

        sessionStorage.setItem('authToken', responseData.accessToken);

        location.href = 'index.html';
    } catch (error) {
        alert(error.message);
        return;
    }
}