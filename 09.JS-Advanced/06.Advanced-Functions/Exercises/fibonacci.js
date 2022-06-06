function getFibonator() {

    let fibonaci = [0];

    return function fib() {
        let result;

        if (fibonaci.length == 1) {
            result = 1;
        } else {
            result = fibonaci[fibonaci.length - 1] + fibonaci[fibonaci.length - 2];
        }

        fibonaci.push(result);

        return result;
    }
}

let fib = getFibonator();
console.log(fib()); // 1
console.log(fib()); // 1
console.log(fib()); // 2
console.log(fib()); // 3
console.log(fib()); // 5
console.log(fib()); // 8
console.log(fib()); // 13
