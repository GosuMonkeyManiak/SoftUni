import { logout as apiLogout } from '../api/authentication.js';

async function logout(context) {
    try {
        await apiLogout();
        context.redirect('/catalog');
    } catch (err) {
        alert(err.message);
    }
}

export {
    logout
}