const host = 'http://localhost:3030';

async function request(method, url, data) {
    let options = {
        method,
        headers: {}
    };
    
    let token = sessionStorage.getItem('authToken');

    if (token != null) {
        options.headers['X-Authorization'] = token;
    }

    if (data != undefined) {
        options.headers['Content-Type'] = 'application/json';
        options.body = JSON.stringify(data);
    }

    let response = await fetch(host + url, options);

    if (response.status == 204) {
        return;
    }

    if (response.status != 200) {
        let error = await response.json();
        throw Error(error.message);
    }

    return await response.json();
}

async function get(url) {
    return await request('get', url);
}

async function post(url, data) {
    return await request('post', url, data);
}

async function put(url, data) {
    return await request('put', url, data);
}

async function del(url) {
    return await request('delete', url);
}

export {
    get,
    post,
    put,
    del
}