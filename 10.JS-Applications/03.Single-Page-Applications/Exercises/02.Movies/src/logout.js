import { showLogin } from './login.js';
import { showCorrectNavBar } from './utilities.js';
import { get } from './api.js';


async function logout() {

    try {
        await get('/users/logout')
    } catch (error) {
        alert(error.message);
        return;
    }

    sessionStorage.clear();

    showCorrectNavBar();
    showLogin();
}

export {
    logout
}