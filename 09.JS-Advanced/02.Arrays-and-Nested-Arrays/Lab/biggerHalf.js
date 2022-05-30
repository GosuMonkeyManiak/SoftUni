function biggerHalf(numbers) {

    numbers = numbers.sort((a, b) => a - b);

    let middleIndex = Math.floor(numbers.length / 2);

    let result = numbers.slice(middleIndex, numbers.length);

    return result;
}

console.log(biggerHalf([3, 19, 14, 7, 2, 19, 6]));
console.log(biggerHalf([4, 7, 2, 5]));