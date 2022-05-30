function processOddPositions(numbers) {

    let elementsOnOddPositions = [];

    for (let i = 0; i < numbers.length; i++) {
        
        if (i % 2 != 0) {
            elementsOnOddPositions.push(numbers[i] * 2);
        }
    }

    elementsOnOddPositions = elementsOnOddPositions.reverse();

    console.log(elementsOnOddPositions.join(' '));
}

processOddPositions([10, 15, 20, 25]);
processOddPositions([3, 0, 10, 4, 7, 3]);