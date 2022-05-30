function negativeAndPositiveNumbers(numbers) {

    let result = [];

    for (let i = 0; i < numbers.length; i++) {
        
        if (numbers[i] < 0) {
            result.unshift(numbers[i]);
        } else {
            result.push(numbers[i]);
        }
    }

    result.forEach(x => console.log(x));
}

negativeAndPositiveNumbers([7, -2, 8, 9]);
negativeAndPositiveNumbers([3, -2, 0, -1]);