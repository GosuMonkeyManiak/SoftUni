function getUserData() {
    return JSON.parse(sessionStorage.getItem('userData'));
}

function setUserData(userData) {
    sessionStorage.setItem('userData', JSON.stringify(userData));
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
            data[key] = data[key].trim();
        }

        actualEventCallBack.call(event.currentTarget, data);
    };
}

function assignPointer(intialObject, pointerName, toClassName, pointerValue) {
    Object.assign(intialObject, {
        [pointerName]: {
            __type: 'Pointer',
            className: toClassName,
            objectId: pointerValue
        }
    });
}

export {
    getUserData,
    setUserData,
    clearUserData,
    createIntialSubmitFunction,
    assignPointer
}