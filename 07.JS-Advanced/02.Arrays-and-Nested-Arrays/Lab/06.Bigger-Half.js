function biggerHalf(numbers) {

    let sortedNumbers = numbers
        .sort((a, b) => a - b);

    let needElements = Math.ceil(numbers.length / 2);

    sortedNumbers = sortedNumbers.slice(numbers.length - needElements);
    
    return sortedNumbers;
}

console.log(biggerHalf([4, 7, 2, 5]));
console.log(biggerHalf([3, 19, 14, 7, 2, 19, 6]));