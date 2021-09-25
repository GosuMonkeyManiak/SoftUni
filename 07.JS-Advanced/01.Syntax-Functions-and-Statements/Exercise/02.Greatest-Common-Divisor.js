function greatestCommonDevisor(firstNumber, secondNumber) {

    firstNumber = Math.abs(firstNumber);
    secondNumber = Math.abs(secondNumber);
    
    while (secondNumber) {
        var t = secondNumber;
        secondNumber = firstNumber % secondNumber;
        firstNumber = t;
    }

    console.log(firstNumber);
}


greatestCommonDevisor(15, 5);