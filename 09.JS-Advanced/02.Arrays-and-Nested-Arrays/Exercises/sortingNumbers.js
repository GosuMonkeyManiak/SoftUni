function sortNumbers(numbers) {

    numbers = numbers.map(Number);

    let ascendingSort = [...numbers];
    let decendingSort = [...numbers];

    ascendingSort.sort((a, b) => a - b);
    decendingSort.sort((a, b) => b - a);

    let reuslt = [];
    let lastIndex = Math.floor(numbers.length / 2);

    for (let i = 0; i <= lastIndex; i++) {
        
        if (numbers.length % 2 != 0 && i == lastIndex) {
            reuslt.push(ascendingSort[i]);
            break;
        } else if (numbers.length % 2 == 0 && i == lastIndex) {
            break;
        }

        reuslt.push(ascendingSort[i]);
        reuslt.push(decendingSort[i]);
    }

    return reuslt;
}

console.log(sortNumbers([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));
console.log(sortNumbers([1, 2, 4, 5, 6, 7, 8, 9, 10, 11, 12]));