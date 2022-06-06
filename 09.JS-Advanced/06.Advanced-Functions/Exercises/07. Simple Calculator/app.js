function calculator() {
    let firstNumberRef;
    let secondNumberRef;
    let resultOutputRef;

    function init(firstNumberSelector, secondNumberSelector, resultSelector) {
        firstNumberRef = document.querySelector(firstNumberSelector);
        secondNumberRef = document.querySelector(secondNumberSelector);
        resultOutputRef = document.querySelector(resultSelector);
    }

    function add() {
        let firstNumber = Number(firstNumberRef.value);
        let secondNumber = Number(secondNumberRef.value);

        resultOutputRef.value = firstNumber + secondNumber;
    }

    function subtract() {
        let firstNumber = Number(firstNumberRef.value);
        let secondNumber = Number(secondNumberRef.value);

        resultOutputRef.value = firstNumber - secondNumber;
    }

    return {
        init,
        add,
        subtract
    }
}

const calculate = calculator();
calculate.init('#num1', '#num2', '#result');