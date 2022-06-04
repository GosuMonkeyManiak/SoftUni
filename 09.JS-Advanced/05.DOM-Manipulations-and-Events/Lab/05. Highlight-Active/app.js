function focused() {
    Array.from(document.querySelectorAll('input'))
        .forEach(x => {
            x.addEventListener('focus', onFocus);
            x.addEventListener('blur', onBlur);
        });

    function onFocus(event) {
        this.parentElement.classList.add('focused');
    }

    function onBlur(event) {
        this.parentElement.classList.remove('focused');
    }
}