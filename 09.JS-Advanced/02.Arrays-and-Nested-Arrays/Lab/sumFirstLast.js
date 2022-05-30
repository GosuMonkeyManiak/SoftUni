function sumFirstLast(numberAsStrings) {

    let numbers = numberAsStrings.map(Number);

    return numbers[0] + numbers[numbers.length - 1];
}

console.log(sumFirstLast(['20', '30', '40']));
console.log(sumFirstLast(['5', '10']))