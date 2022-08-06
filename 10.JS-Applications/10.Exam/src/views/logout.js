import { logout as apiLogout } from '../services/authentication.js';

async function logout(ctx) {
    await apiLogout();
    ctx.redirect('/dashboard');
}

export {
    logout
}