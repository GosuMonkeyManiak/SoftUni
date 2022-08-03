import { clearUserData, setUserData } from '../utilities.js';
import * as api from './api.js';

async function login(email, password) {
    const userData = await api.post('/users/login', { email, password });

    setUserData({
        id: userData._id,
        accessToken: userData.accessToken
    });

    return userData;
}

async function register(email, password) {
    const userData = await api.post('/users/register', { email, password });

    setUserData({
        id: userData._id,
        accessToken: userData.accessToken
    });

    return userData;
}

async function logout() {
    api.get('/users/logout');

    clearUserData();
}

export {
    login,
    register,
    logout
}