function clearAllInputs() {
    document.querySelectorAll('form input, textarea').forEach(x => x.value = '');
}

export {
    clearAllInputs
}