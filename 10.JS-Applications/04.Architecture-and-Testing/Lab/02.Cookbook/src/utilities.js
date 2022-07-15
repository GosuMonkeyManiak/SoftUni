function addFormHandler(htmlElement, cssSelector, callback) {
    let form = htmlElement.querySelector(cssSelector);

    form.addEventListener('submit', event => {
        event.preventDefault();
        let formData = new FormData(form);
        callback.call(form, [...formData.entries()].reduce((p, [k, v]) => Object.assign(p, { [k]: v }), {}));
    });
}

export {
    addFormHandler
}