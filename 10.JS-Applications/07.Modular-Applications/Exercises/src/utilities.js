function getUserData() {
    return JSON.parse(sessionStorage.getItem('userData'));
}

function setUserData(userData) {
    sessionStorage.setItem('userData', JSON.stringify(userData));
}

function clearUserData() {
    sessionStorage.removeItem('userData');
}

function createIntialSubmitFunction(actualEventCallBack, cssSelectorForErrors) {
    return async event => {
        event.preventDefault();

        let formData = new FormData(event.currentTarget);
        let data = Object.fromEntries(formData.entries());

        for (const key in data) {
            data[key] = data[key].trim();
        }

        try {
            let result = await actualEventCallBack.call(event.currentTarget, data);
            
            if (cssSelectorForErrors != undefined) {
                let containerForErrors = document.querySelector(cssSelectorForErrors);
                
                if (typeof result == 'string') {
                    containerForErrors.textContent = result;
                } else {
                    containerForErrors.textContent = '';
                }
            }

        } catch (error) {
            
            if (cssSelectorForErrors != undefined) {
                document.querySelector(cssSelectorForErrors).textContent = error.message;
            }
            
            throw error;
        }
        
    };
}

export {
    getUserData,
    setUserData,
    clearUserData,
    createIntialSubmitFunction
}