function createIntialSubmitFunction(actualEventCallBack) {
    return event => {
        event.preventDefault();
        let formData = new FormData(event.currentTarget);
        actualEventCallBack.call(null, [...formData.entries()].reduce((p, [k, v]) => Object.assign(p, { [k]: v }), {}));
    };
}

function setUserNav(context, next) {
    if (sessionStorage.getItem('userToken') != null) {
        document.getElementById('user').style.display = 'inline-block';
        document.getElementById('guest').style.display = 'none';
    } else {
        document.getElementById('user').style.display = 'none';
        document.getElementById('guest').style.display = 'inline-block';
    }

    next();
}

export {
    createIntialSubmitFunction,
    setUserNav
}