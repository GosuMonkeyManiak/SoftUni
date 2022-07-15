import { post } from '../api.js';
import { addFormHandler } from '../utilities.js';
import { getElementBySelector, setUserNav, showView } from '../dom.js';

const loginView = getElementBySelector('#login');
loginView.remove();

addFormHandler(loginView, 'form', login);

let ctx = null;

function showLogin(innerCtx) {
    ctx = innerCtx;
    showView(loginView);
}

async function login( { email, password} ) {
    const body = {
        email,
        password
    };

    let responseData;

    try {
        responseData = await post('/users/login', body);
    } catch (error) {
        alert(error.message);
        return;
    }
    
    sessionStorage.setItem('authToken', responseData.accessToken);
    sessionStorage.setItem('userId', responseData._id);

    setUserNav();
    
    ctx.goTo('catalogLink');
}

export {
    showLogin
}