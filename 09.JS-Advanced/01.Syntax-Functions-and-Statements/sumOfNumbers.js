function solve(n, m) {
    let firstNumber = Number(n);
    let secondNumber = Number(m);
    let sum = 0;

    for (let i = firstNumber; i <= secondNumber; i++) {
        sum += i;
    }

    return sum;
}

console.log(solve("1", "5"));
console.log(solve("-8", "20"));
