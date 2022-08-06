import * as api from '../infrastructure/back4appApi.js';
import { clearUserData, setUserData } from '../utilities.js';

async function login(username, password) {
    let userData = await api.get('/login', {
        username,
        password
    });

    setUserData({
        id: userData.objectId,
        sessionToken: userData.sessionToken
    });
}

async function register(username, password) {
    let userData = await api.post('/users', {
        username,
        password
    });

    setUserData({
        id: userData.objectId,
        sessionToken: userData.sessionToken
    });
}

async function logout() {
    api.post('/logout');
    clearUserData();
}

export {
    login,
    register,
    logout
}