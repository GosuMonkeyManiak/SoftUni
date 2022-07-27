import * as api from './api.js';

const paths = {
    REGISTER: '/users/register',
    LOGIN: '/users/login',
    LOGOUT: '/users/logout'
}

async function register(userData) {
    return api.post(paths.REGISTER, userData);
}

async function login(userData) {
    return api.post(paths.LOGIN, userData);
}

async function logout() {
    return api.get(paths.LOGOUT);
}

export {
    register,
    login,
    logout
}