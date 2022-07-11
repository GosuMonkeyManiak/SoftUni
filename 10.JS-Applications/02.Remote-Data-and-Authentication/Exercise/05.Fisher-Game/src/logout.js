import { showHome } from './home.js';

async function logout() {
    let token = JSON.parse(sessionStorage.getItem('authToken')).accessToken;

    let response = await fetch('http://localhost:3030/users/logout', {
        method: 'get',
        headers: { 'X-Authorization': token }
    });

    if (response.status != 204) {
        alert('Something went wrong!');
        return;
    }

    sessionStorage.clear();
    showHome();
}

export {
    logout
}