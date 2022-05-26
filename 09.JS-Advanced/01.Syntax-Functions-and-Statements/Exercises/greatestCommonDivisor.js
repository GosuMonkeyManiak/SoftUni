function solve(firstNumber, secondNumber) {

    firstNumber = Math.abs(firstNumber);
    secondNumber = Math.abs(secondNumber);
    
    while (secondNumber) {
        var t = secondNumber;
        secondNumber = firstNumber % secondNumber;
        firstNumber = t;
    }

    console.log(firstNumber);
}

solve(15, 5);
solve(2154, 458);