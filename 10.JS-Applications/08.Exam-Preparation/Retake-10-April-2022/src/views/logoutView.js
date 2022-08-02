import { logout as apiLogout } from '../services/authentication.js';
import { clearUserData } from '../utilities.js';

async function logout(ctx) {
    await apiLogout();

    clearUserData();

    ctx.redirect('/');
}

export {
    logout
}