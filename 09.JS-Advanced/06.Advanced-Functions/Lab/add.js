function solution(number) {
    
    let sum = number;

    let func = function result(numberToAdd) {
        return sum + numberToAdd;
    }

    return func;
}

let add5 = solution(5);
console.log(add5(2));
console.log(add5(3));