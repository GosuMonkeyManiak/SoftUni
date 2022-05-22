function solve(firstOperand, secondOperand, operator) {
    if (operator === "+") {
        console.log(firstOperand + secondOperand);
    } else if (operator === "-") {
        console.log(firstOperand - secondOperand);
    } else if (operator === "*") {
        console.log(firstOperand * secondOperand);
    } else if (operator === "/") {
        console.log(firstOperand / secondOperand);
    } else if (operator === "%") {
        console.log(firstOperand % secondOperand);
    } else if (operator === "**") {
        console.log(firstOperand ** secondOperand);
    }
}

solve(5, 6, "+");
solve(3, 5.5, "*");
