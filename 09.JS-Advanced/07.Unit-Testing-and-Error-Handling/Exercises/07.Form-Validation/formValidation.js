function validate() {
    const userNameInputRef = document.querySelector('#username');
    const emailInputRef = document.querySelector('#email');
    const passwordInputRef = document.querySelector('#password');
    const confirmPasswordInputRef = document.querySelector('#confirm-password');
    const isCompanyInputRef = document.querySelector('#company');
    const companyField = document.querySelector('#companyInfo');
    const companyNumberInputRef = document.querySelector('#companyNumber');
    const validDivRef = document.querySelector('#valid');

    const userNameRegex = /^[A-Za-z0-9]{3,20}$/g;
    const passwordRegex = /^[A-Za-z0-9_]{5,15}$/g;
    const confirmPasswordRegex = /^[A-Za-z0-9_]{5,15}$/g;
    const emailRegex = /^[^@.]+@[^@]*\.[^@]*$/g;

    isCompanyInputRef.addEventListener('change', e => {

        if (isCompanyInputRef.checked) {
            companyField.style.display = 'block';
        } else {
            companyField.style.display = 'none';
        }
    });

    document.querySelector('#submit').addEventListener('click', e => {
        e.preventDefault();

        let isAllFieldValid = true;

        if (userNameRegex.exec(userNameInputRef.value) == null) {
            isAllFieldValid = false;
            userNameInputRef.style.borderColor = 'red';
        } else {
            userNameInputRef.style.borderColor = '';
        }

        if (emailRegex.exec(emailInputRef.value) == null) {
            isAllFieldValid = false;
            emailInputRef.style.borderColor = 'red';
        } else {
            emailInputRef.style.borderColor = '';
        }

        if (passwordRegex.exec(passwordInputRef.value) == null || 
            confirmPasswordRegex.exec(confirmPasswordInputRef.value) == null || 
            confirmPasswordInputRef.value != passwordInputRef.value) {

            isAllFieldValid = false;
            passwordInputRef.style.borderColor = 'red';
            confirmPasswordInputRef.style.borderColor = 'red';
        } else {
            passwordInputRef.style.borderColor = '';
            confirmPasswordInputRef.style.borderColor = '';
        }

        if (isCompanyInputRef.checked) {

            let companyNumber = Number(companyNumberInputRef.value);

            if (Number.isInteger(companyNumber) && (companyNumber >= 1000 && companyNumber <= 9999)) {
                companyNumberInputRef.style.borderColor = '';
            } else {
                isAllFieldValid = false;
                companyNumberInputRef.style.borderColor = 'red';
            }
        }

        if (isAllFieldValid) {
            validDivRef.style.display = 'block';
        } else {
            validDivRef.style.display = 'none';
        }
    });
}