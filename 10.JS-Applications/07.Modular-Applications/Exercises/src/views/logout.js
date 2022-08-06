import { logout as apiLogout } from '../services/authentication.js';

async function logout(context) {
    await apiLogout();
    context.redirect('/');
}

export {
    logout
}