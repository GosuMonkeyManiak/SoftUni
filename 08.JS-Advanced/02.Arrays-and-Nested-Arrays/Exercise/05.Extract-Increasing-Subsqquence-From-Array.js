function solve(elements) {

    elements = elements.reduce((a, c, i) => {
        
        if (i == 0) {
            a.push(c);
            return a;
        }

        if (a[a.length - 1] <= c) {
            a.push(c);
            return a;
        }

        return a;

    }, []);

    return elements;
}

console.log(solve([1, 3, 8, 4, 10, 12, 3, 2, 24]));
console.log(solve([1, 2, 3, 4]));
console.log(solve([20, 3, 2, 15,6, 1]));