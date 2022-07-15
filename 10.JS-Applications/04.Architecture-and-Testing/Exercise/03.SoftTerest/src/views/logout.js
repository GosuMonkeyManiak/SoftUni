import { get } from '../api.js';
import { setCorrectNav } from '../utilities.js';

async function logout(context) {
    try {
        await get('/users/logout');
    } catch (error) {
        alert(error.message);
        return;
    }

    sessionStorage.removeItem('authToken');
    sessionStorage.removeItem('id');

    setCorrectNav();
    context.goTo('home');
}

export {
    logout
}