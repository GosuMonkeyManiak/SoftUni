function increasingSubSetFromArray(array) {

    let increasingSetSet = [];

    let currentElement = array[0];

    for (let i = 1; i < array.length; i++) {
        
        if (array[i] >= currentElement) {
            
            increasingSetSet.push(currentElement);
            currentElement = array[i];
        }
    }

    increasingSetSet.push(currentElement);

    return increasingSetSet;
}

console.log(increasingSubSetFromArray([1, 3, 8, 4, 10, 12, 3, 2, 24]));
console.log(increasingSubSetFromArray([1, 2, 3,4]));
console.log(increasingSubSetFromArray([20, 3, 2, 15,6, 1]));