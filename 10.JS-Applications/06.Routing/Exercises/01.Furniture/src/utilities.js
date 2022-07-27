const userNav = document.querySelector('#user');
const guestNav = document.querySelector('#guest');

function setCorrentUserNav(context, next) {
    if (isHaveUserSession()) {
        userNav.style.display = 'inline-block';
        guestNav.style.display = 'none';
    } else {
        userNav.style.display = 'none';
        guestNav.style.display = 'inline-block';
    }

    next();
}

function createInitialSubmitFunction(actualCallBack) {
    return event => {
        event.preventDefault();
        let formData = new FormData(event.currentTarget);
        actualCallBack.call(null, [...formData.entries()].reduce((p, [k, v]) => Object.assign(p, { [k]: v }), {}));
    }
}

function activateClickedAnchor(context, next) {
    let path = context.path;

    if (path != undefined) {
        let anchor = document.querySelector(`body header nav a[href="${path}"]`);

        if (anchor != undefined) {
            Array.from(document.querySelectorAll('body header nav a')).forEach(a => a.classList.remove('active'));
            anchor.classList.add('active');
        }
    }
    
    next();
}

function isHaveUserSession() {
    return sessionStorage.getItem('authToken') != null;
}

export {
    setCorrentUserNav,
    createInitialSubmitFunction,
    activateClickedAnchor,
}