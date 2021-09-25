function mathOperation(firstNumber, secondNumber, operator) {

    let result;

    switch (operator) {

        case '+': result = firstNumber + secondNumber;
            break;

        case '-': result = firstNumber - secondNumber;
            break;
    
        case '*': result = firstNumber * secondNumber;
            break;

        case '/': result = firstNumber / secondNumber;
            break;
        
        case '%': result = firstNumber % secondNumber;
            break;

        case '**': result = firstNumber ** secondNumber;
            break;
    }

    console.log(result);
}

mathOperation(5, 6, '+');
mathOperation(3, 5.5, '*');