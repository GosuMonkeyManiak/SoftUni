function processingOddNumbers(numbers) {

    let result = numbers
        .filter((x, i) => i % 2 != 0)
        .map(x => x * 2)
        .reverse();
    
    return result;
}

console.log(processingOddNumbers([10, 15, 20, 25]));
console.log(processingOddNumbers([3, 0, 10, 4, 7, 3]));