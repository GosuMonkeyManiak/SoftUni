function greaterNumber(firstNumber, secondNumber) {

    firstNumber = Number(firstNumber);
    secondNumber = Number(secondNumber);
    
    if (firstNumber > secondNumber) {
        console.log(firstNumber);
    } else {
        console.log(secondNumber);
    }
}

greaterNumber("5", "3");