function requestValidation(request) {

    const keys = Object.keys(request);
    
    const validMethods = ['GET', 'POST', 'DELETE', 'CONNECT'];
    const validVersions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0']
    const regexForSpecialCharacters = /[<>\\&'"]/g;
    const regexForURI = /^[a-zA-Z0-9.]+$/g;
    const propertiesAndOrder = ['Method', 'URI', 'Version', 'Message'];

    for (let i = 0; i < propertiesAndOrder.length; i++) {

        if (keys[i] !== propertiesAndOrder[i].toLowerCase()) {
            throw new Error(`Invalid request header: Invalid ${propertiesAndOrder[i]}`);
        }
    }
    
    for (let i = 0; i < keys.length; i++) {
        
        if (keys[i] == 'method' && !validMethods.includes(request[keys[i]])) {
            throw new Error('Invalid request header: Invalid Method');
        } else if (keys[i] == 'uri' && !regexForURI.test(request[keys[i]])) {

            if (request[keys[i]] != '*') {
                throw new Error('Invalid request header: Invalid URI');   
            }
        } else if (keys[i] == 'version' && !validVersions.includes(request[keys[i]])) {
            throw new Error('Invalid request header: Invalid Version');
        } else if (keys[i] == 'message' && regexForSpecialCharacters.test(request[keys[i]])) {
            throw new Error('Invalid request header: Invalid Message');
        }
    }

    return request;
}

console.log(requestValidation({
  method: 'GET',
  uri: 'git.master',
  version: 'HTTP/1.1',
  message: '\r\n'
}));