function subtract() {
    let firstInput = document.getElementById('firstNumber')
    let secondInput = document.getElementById('secondNumber');

    let firstNumber = Number(firstInput.value);
    let secondNumber = Number(secondInput.value);

    let result = document.getElementById('result');
    result.textContent = firstNumber - secondNumber;

    firstInput.disabled = false;
    secondInput.disabled = false;
}