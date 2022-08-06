import { getUserData } from '../utilities.js';

const host = 'https://parseapi.back4app.com';

const classBaseEndPoint = '/classes';

const applicationId = 'DOqszR3fAJ8QIdpuA9PrLvjL25P9Ah5JYTAA473D';
const javaScriptKey = 'PNkPgpJ23tj8RM4k4N6RGfLvJ0aBFwL2aC8a9pLk';

async function request(method, url, data, queryParameters) {
    const options = {
        method,
        headers: {
            'X-Parse-Application-Id': applicationId,
            'X-Parse-REST-API-Key': javaScriptKey
        }
    };

    let userData = getUserData();

    if (userData != null) {
        options.headers['X-Parse-Session-Token'] = userData.sessionToken;
    }

    if (queryParameters != undefined) {
        url = setQueryParameters(url, queryParameters);
    }

    if (data != undefined) {
        options.headers['Content-Type'] = 'application/json';
        options.body = JSON.stringify(data);
    }

    try {
        let response = await fetch(host + url, options);

        if (response.ok == false) {
            let errorMessage = await response.json();
            throw new Error(errorMessage.error);
        }
        
        if (response.status != 204) {
            return response.json();
        }

    } catch (error) {
        alert(error.message);
        throw error;
    }
}

function fullEncodeURIComponent(str) {
    return encodeURIComponent(str).replace(/[!'()*]/g, function (c) {
        return '%' + c.charCodeAt(0).toString(16).toUpperCase();
    });
}

function setQueryParameters(url, queryParameters) {
    let encodedQueryParameters = [];

    for (const [key, value] of Object.entries(queryParameters)) {
        encodedQueryParameters.push(`${key}=${fullEncodeURIComponent(value)}`);
    }

    return `${url}?${encodedQueryParameters.join('&')}`;
}

async function get(url, queryParameters) {
    return request('get', url, undefined, queryParameters);
}

async function post(url, data) {
    return request('post', url, data);
}

async function put(url, data) {
    return request('put', url, data);
}

async function del(url, queryParameters) {
    return request('delete', url, undefined, queryParameters);
}

export {
    get,
    post,
    put,
    del,
    classBaseEndPoint
}