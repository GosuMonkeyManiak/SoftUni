function largestNumber(firstNumber, secondNumber, thirdNumber) {

    let first = parseInt(firstNumber);
    let second =  parseInt(secondNumber);
    let third = parseInt(thirdNumber);

    console.log(`The largest number is ${Math.max(first, second, third)}.`);
}

largestNumber(5, -3, 16);