function solve(numbers) {
    let sum = 0;
    let sumOfInverseValues = 0;
    let concatNumbers = '';

    for (let index = 0; index < numbers.length; index++) {
        sum += numbers[index];
    }

    for (let index = 0; index < numbers.length; index++) {
        sumOfInverseValues += 1 / numbers[index];
    }

    for (let index = 0; index < numbers.length; index++) {
        concatNumbers += numbers[index];
    }

    console.log(sum);
    console.log(sumOfInverseValues);
    console.log(concatNumbers);
}

solve([1, 2, 3]);
solve([2, 4, 8, 16]);
