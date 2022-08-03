function getUserData() {
    return JSON.parse(sessionStorage.getItem('userData'));
}

function setUserData(userData) {
    sessionStorage.setItem('userData', JSON.stringify({
        id: userData._id,
        accessToken: userData.accessToken
    }));
}

function clearUserData() {
    sessionStorage.removeItem('userData');
}

function createIntialSubmitFunction(actualEventCallBack) {
    return event => {
        event.preventDefault();

        let formData = new FormData(event.currentTarget);
        let data = Object.fromEntries(formData.entries());

        for (const key in data) {
            data[key].trim();
        }

        actualEventCallBack.call(event.currentTarget, data);
    };
}

export {
    getUserData,
    setUserData,
    clearUserData,
    createIntialSubmitFunction
}