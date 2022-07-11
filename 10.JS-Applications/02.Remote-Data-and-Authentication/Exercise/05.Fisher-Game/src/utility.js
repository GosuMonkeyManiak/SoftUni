const main = document.querySelector('main');

function showView(viewElement) {
    showCorrectButtons();
    
    main.replaceChildren(viewElement);
}

function clearAllInputs() {
    document.querySelectorAll('input').forEach(x => {
        x.value = '';
    });
}

function showCorrectButtons() {
    hideUserAndGuestButtons();
    
    if (sessionStorage.getItem('authToken') == null) {
        showGuestButtons();
        showGuest();
    } else {
        showUserButtons();
        showUsernameOfUser(JSON.parse(sessionStorage.getItem('authToken')).email);
    }
}

function showUserButtons() {
    document.querySelector('header nav #user').style.display = 'inline-block';
}

function showGuestButtons() {
    document.querySelector('header nav #guest').style.display = 'inline-block';
}

function hideUserAndGuestButtons() {
    document.querySelector('header nav #user').style.display = 'none';
    document.querySelector('header nav #guest').style.display = 'none';
}

function showGuest() {
    document.querySelector('header nav p span').textContent = 'guest';
}

function showUsernameOfUser(username) {
    document.querySelector('header nav p span').textContent = username;
}

function disableInputs(htmlFragment) {
    disabledElements(htmlFragment, 'input');
}

function disableButtons(htmlFragment) {
    disabledElements(htmlFragment, 'button');
}

function disabledElements(htmlFragment, cssSelector) {
    htmlFragment.querySelectorAll(cssSelector).forEach(x => {
        x.disabled = true;
    });
}

export {
    showView,
    clearAllInputs,
    disableInputs,
    disableButtons
}