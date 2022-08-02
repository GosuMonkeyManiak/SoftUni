import * as api from './api.js';

async function login(email, password) {
    return api.post('/users/login', { email, password });
}

async function register(email, password) {
    return api.post('/users/register', { email, password });
}

async function logout() {
    return api.get('/users/logout');
}

export {
    login,
    register,
    logout
}