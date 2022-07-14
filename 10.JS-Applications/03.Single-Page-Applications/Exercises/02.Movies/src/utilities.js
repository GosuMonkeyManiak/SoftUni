function showView(view) {
    document.querySelector('main').replaceChildren(view);
}

function showCorrectNavBar() {
    let userSession = JSON.parse(sessionStorage.getItem('userData'));

    if (userSession != null) {
        changeDisplayOfElements('body nav ul li.guest', 'none');
        changeDisplayOfElements('body nav ul li.user', 'inline-block');

        document.querySelector('body nav ul #welcome-msg').textContent = `Welcome, ${userSession.email}`;
    } else {
        changeDisplayOfElements('body nav ul li.guest', 'inline-block');
        changeDisplayOfElements('body nav ul li.user', 'none');
    }
}

function addFormHandler(htmlElement, cssSelector, callback) {
    let form = htmlElement.querySelector(cssSelector);

    form.addEventListener('submit', event => {
        event.preventDefault();
        let formData = new FormData(form);
        callback.call(form, formData);
    });
}

function clearAllInputs() {
    document.querySelectorAll('input, textarea').forEach(e => {
       e.value = ''; 
    });
}

function changeDisplayOfElements(cssSelector, displayPropertyValue) {
    document.querySelectorAll(cssSelector).forEach(element => {
        element.style.display = displayPropertyValue;
    });
}

export {
    showView,
    showCorrectNavBar,
    addFormHandler,
    clearAllInputs,
    changeDisplayOfElements
}