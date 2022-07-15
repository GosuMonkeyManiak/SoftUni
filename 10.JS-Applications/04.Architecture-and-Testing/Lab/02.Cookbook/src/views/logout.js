import { get } from '../api.js';
import { setUserNav } from '../dom.js';

async function logout(ctx) {
    try {
        await get('/users/logout');
    } catch (error) {
        alert(error.message);
        return;
    }

    sessionStorage.removeItem('authToken');
    
    setUserNav();

    ctx.goTo('catalogLink');
}

export {
    logout
}