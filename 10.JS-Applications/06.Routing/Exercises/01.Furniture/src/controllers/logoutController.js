import { logout as apiLogout } from '../infrastructure/authentication.js';

async function logout(context) {
    try {
        await apiLogout();
        
        sessionStorage.clear();
        context.redirect('/dashboard');
    } catch (error) {
        alert('You are already logout!');
    }
}

export {
    logout
}