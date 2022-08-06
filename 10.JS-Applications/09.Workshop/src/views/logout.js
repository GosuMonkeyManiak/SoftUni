import { logout as apiLogout } from '../services/authentication.js';

function logout(ctx) {
    apiLogout();
    ctx.redirect('/browse');
}

export {
    logout
}