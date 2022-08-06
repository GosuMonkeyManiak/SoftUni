import { getUserData } from '../utilities.js';

function authenticationMiddleware(context, next) {
    let userData = getUserData();
    context.isHaveUser = userData != undefined;
    next();
}

export {
    authenticationMiddleware
}