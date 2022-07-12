import { showHome } from "./home.js";

async function logout() {
    const response = await fetch('http://localhost:3030/users/logout', {
        method: 'get',
        headers: {
            'X-Authorization': sessionStorage.getItem('authToken')
        },
    });
    
    if (response.status == 204) {
        sessionStorage.removeItem('authToken');
        sessionStorage.removeItem('userId');
        showHome();
    } else {
        console.error(await response.json());
    }
}

export {
    logout
}