const host = 'http://localhost:3030';
const authorizationHeader = 'X-Authorization';

const methods = {
    GET: 'get',
    POST: 'post',
    PUT: 'put',
    DEL: 'delete'
};

async function request(method, url, data) {
    const options = {
        method,
        headers: {}
    };

    const userToken = sessionStorage.getItem('authToken');

    if (userToken != null) {
        options.headers[authorizationHeader] = userToken;
    }

    if (data != undefined) {
        options.headers['Content-Type'] = 'application/json';
        options.body = JSON.stringify(data);
    }

    try {
        let response = await fetch(host + url, options);

        if (response.status != 204 && response.status != 200) {
            let error = await response.json();
            throw new Error(error.message);
        }

        if (response.status == 200) {
            let data = await response.json();
            return data
        }
        
    } catch (error) {
        console.error(error);
        throw error;
    }
}

async function get(url) {
    return request(methods.GET, url);
}

async function post(url, data) {
    return request(methods.POST, url, data);
}

async function put(url, data) {
    return request(methods.PUT, url, data);
}

async function del(url) {
    return request(methods.DEL, url);
}

export {
    get,
    post,
    put,
    del
}