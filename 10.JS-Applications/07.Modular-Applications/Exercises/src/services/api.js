import { getUserData } from '../utilities.js';

const host = 'http://localhost:3030';

async function request(method, url, data) {
    const options = {
        method,
        headers: {}
    };

    let userData = getUserData();

    if (userData != null) {
        options.headers['X-Authorization'] = userData.accessToken;
    }

    if (data != undefined) {
        options.headers['Content-Type'] = 'application/json';
        options.body = JSON.stringify(data);
    }

    try {
        let response = await fetch(host + url, options);

        if (!response.ok) {
            let error = await response.json();
            throw new Error(error.message);
        }

        if (response.status == 200) {
            return await response.json();
        }
    } catch (error) {
        console.error(error);
        throw error;
    }
}

async function get(url) {
    return request('get', url);
}

async function post(url, data) {
    return request('post', url, data);
}

async function put(url, data) {
    return request('put', url, data);
}

async function del(url) {
    return request('delete', url);
}

export {
    get,
    post,
    put,
    del
}