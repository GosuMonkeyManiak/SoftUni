const main = document.querySelector('main');

function showView(view) {
    main.replaceChildren(view);
}

function displayCorrectUserButtons() {
    if (sessionStorage.getItem('authToken') != null) {
        document.querySelector('#user').style.display = 'inline-block';
        document.querySelector('#guest').style.display = 'none';
    } else {
        document.querySelector('#user').style.display = 'none';
        document.querySelector('#guest').style.display = 'inline-block';
    }
}

function clearInputs() {
    document.querySelectorAll('input').forEach(input => {
        if (input.type != 'submit') {
            input.value = '';
        }
    });
}

export {
    showView,
    displayCorrectUserButtons,
    clearInputs
}