function showView(view) {
    document.querySelector('main').replaceChildren(view);
}

function addFormHandler(htmlElement, cssSelector, callback) {
    let form = htmlElement.querySelector(cssSelector);

    form.addEventListener('submit', event => {
        event.preventDefault();
        let formData = new FormData(form);
        callback.call(form, [...formData.entries()].reduce((p, [k, v]) => Object.assign(p, { [k]: v }), {}));
    });
}

function clearAllInputFields() {
    document.querySelectorAll('textarea, input').forEach(x => x.value = '');
}

function setCorrectNav() {
    let userSession = sessionStorage.getItem('authToken');

    if (userSession != null) {
        document.querySelectorAll('.user').forEach(x => x.style.display = 'inline-block');
        document.querySelectorAll('.guest').forEach(x => x.style.display = 'none');
    } else {
    document.querySelectorAll('.user').forEach(x => x.style.display = 'none');
        document.querySelectorAll('.guest').forEach(x => x.style.display = 'inline-block');
    }
}

export {
    showView,
    addFormHandler,
    clearAllInputFields,
    setCorrectNav
}