import { logout as apiLogout } from '../services/authentication.js';

async function logout(ctx) {
    apiLogout();

    ctx.redirect('/');
}

export {
    logout
}