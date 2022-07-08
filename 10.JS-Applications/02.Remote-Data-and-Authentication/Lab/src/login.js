document.querySelector('form').addEventListener('submit', login);

async function login(event) {
    event.preventDefault();

    let formData = new FormData(this);

    try {

        let data = {
            email: formData.get('email'),
            password: formData.get('password')
        }

        let response = await fetch('http://localhost:3030/users/login', {
            method: 'post',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(data)
        });

        if (response.status != 200) {
            throw new Error('Invalid credentials!');
        }

        let responseData = await response.json();
        
        sessionStorage.setItem('authToken', responseData.accessToken);

        location.href = 'index.html';
    } catch (error) {
        alert(error.message);
    }
}