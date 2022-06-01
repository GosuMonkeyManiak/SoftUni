function janNotation(input) {

    let numbers = [];
    let operators = []; //+ - * /
    let notEnoughNumbers = false;

    for (let i = 0; i < input.length; i++) {
        
        if (Number.isInteger(input[i])) {
            numbers.push(Number(input[i]));
            continue;
        }

        if (numbers.length < 2) {
            notEnoughNumbers = true;
            break;
        }

        let secondNumber = numbers.pop();
        let firsNumber = numbers.pop();
        let operator = input[i];

        let result;

        if (operator == '+') {
            result = firsNumber + secondNumber;
        } else if (operator == '-') {
            result = firsNumber - secondNumber;
        } else if (operator == '*') {
            result = firsNumber * secondNumber;
        } else if (operator == '/') {
            result = firsNumber / secondNumber;
        }

        numbers.push(result);
    }
    
    if (notEnoughNumbers) {
        console.log('Error: not enough operands!');
    } else if (numbers.length > 1) {
        console.log('Error: too many operands!');
    } else {
        console.log(numbers[0]);
    }
}

janNotation([7, 33, 8, '-']);