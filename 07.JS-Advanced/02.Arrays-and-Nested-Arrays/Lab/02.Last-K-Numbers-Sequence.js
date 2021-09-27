function sequence(n, k) {

    let result = [1];

    for (let i = 0; i < n - 1; i++) {

        if (result.length < k) {
            result.push(result.reduce((a, c) => a + c, 0));
        } else {

            let startIndex = result.length - k;
            let sliceArray = result.slice(startIndex, result.length);
            let sum = sliceArray.reduce((a, c) => a + c, 0);
            result.push(sum);
        }
    }

    return result;
}

console.log(sequence(8, 2));