function solve(numbers) {

    let sortedNumbers = numbers.sort((a, b) => a - b);
    let result = [];

    let left = 0;
    let right = sortedNumbers.length - 1;

    while (left <= right) {

        if (left == right) {
            result.push(sortedNumbers[left]);
            break;
        }

        result.push(sortedNumbers[left]);
        result.push(sortedNumbers[right]);
        left++;
        right--;
    }

    return result;
}

console.log(solve([1, 3, 52, 48, 63, 31, -3, 18, 56]));