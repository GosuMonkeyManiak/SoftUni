function negativePositiveNumbers(numbers) {

    let result = numbers
        .reduce((a, c) => {
            if (c < 0) {
               a.unshift(c);
            } else {
               a.push(c);
            }

            return a;
        }, []);

    for (const number of result) {
        console.log(number);
    }
}

negativePositiveNumbers([7, -2, 8, 9]);