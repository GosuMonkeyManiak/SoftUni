function validate() {
    document.getElementById('email').addEventListener('change', onChange)

    function onChange(event) {
        const regex = /^[a-z]+@[a-z]+\.[a-z]+$/g;

        if (!regex.test(this.value)) {
            this.classList.add('error');
        } else {
            this.classList.remove('error');
        }
    }
}