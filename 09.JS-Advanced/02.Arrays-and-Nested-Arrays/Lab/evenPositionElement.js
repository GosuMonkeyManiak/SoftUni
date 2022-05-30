function evenPositions(array) {

    let elementsOnEvenPosition = [];

    for (let i = 0; i < array.length; i++) {
        
        if (i % 2 == 0) {
            elementsOnEvenPosition.push(array[i]);
        }
    }

    console.log(elementsOnEvenPosition.join(' '));
}

evenPositions(['20', '30', '40', '50', '60']);
evenPositions(['5', '10']);