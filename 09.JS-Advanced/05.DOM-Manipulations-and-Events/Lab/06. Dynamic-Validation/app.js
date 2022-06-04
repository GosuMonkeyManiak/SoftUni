function validate() {
    document.getElementById('email').addEventListener('change', onChange)

    function onChange(event) {
        const regex = /^[a-z]+@[a-z]+\.[a-z]+$/g;

        let match = regex.exec(this.value);

        if (match == null) {
            this.classList.add('error');
        } else {
            this.classList.remove('error');
        }
    }
}