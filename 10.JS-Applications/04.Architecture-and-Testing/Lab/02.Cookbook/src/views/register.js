import { post } from '../api.js';
import { getElementBySelector, setUserNav, showView } from '../dom.js';
import { addFormHandler } from '../utilities.js';

const registerView = getElementBySelector('#register');
registerView.remove();

addFormHandler(registerView, 'form', register);

let ctx = null;

function showRegister(innerCtx) {
    ctx = innerCtx;
    showView(registerView);
}

async function register({ email, password, rePass}) {
    if (password != rePass) {
        return alert('Passwords don\'t match');
    }

    const body = {
        email,
        password
    };

    let responseData;

    try {
        responseData = await post('/users/register', body);
    } catch (err) {
        alert(err.message);
        return;
    }

    sessionStorage.setItem('authToken', responseData.accessToken);
    sessionStorage.setItem('userId', responseData._id);

    setUserNav();
    
    ctx.goTo('catalogLink');
}

export {
    showRegister
}