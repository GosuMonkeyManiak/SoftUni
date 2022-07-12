function showView(HTMLFragment) {
    document.querySelector('body').replaceChildren(HTMLFragment);
}

export {
    showView
}