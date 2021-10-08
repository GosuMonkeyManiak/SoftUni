function sumOfNumbers(start, end) {

    let startNumber = Number(start);
    let endNumber = Number(end);

    let result = 0;

    for (let index = startNumber; index <= endNumber; index++) {
        
        result += index;
    }

    return result;
}

console.log(sumOfNumbers('-8', '20'));