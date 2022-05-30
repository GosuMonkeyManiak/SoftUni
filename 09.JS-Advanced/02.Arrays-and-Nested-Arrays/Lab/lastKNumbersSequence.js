function lastKNumbers(n, k) {

    let result = [1];

    for (let i = 1; i < n; i++) {

        if (result.length < k) {

            result[i] = result.reduce((a , c) => a + c, 0);
        } else {

            let elementsToAddition = result.slice(i - k, i);
            result[i] = elementsToAddition.reduce((a, c) => a + c, 0);
        }
    }

    return result;
}

console.log(lastKNumbers(6, 3));
console.log(lastKNumbers(8, 2));