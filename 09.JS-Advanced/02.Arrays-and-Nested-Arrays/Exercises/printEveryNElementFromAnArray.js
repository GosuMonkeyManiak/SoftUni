function printEveryNElementFromAnArray(array, step) {

    let result = [];

    for (let i = 0; i < array.length; i+= step) {
        result.push(array[i]);
    }

    return result;
}

console.log(printEveryNElementFromAnArray(['5', '20', '31', '4', '20'], 2));
console.log(printEveryNElementFromAnArray(['dsa','asd','test', 'tset'], 2));
console.log(printEveryNElementFromAnArray(['1', '2','3', '4', '5'], 6));