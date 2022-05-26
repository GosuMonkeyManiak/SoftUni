function solve(number) {

    let numbers = Array.from(String(number), x => Number(x));
    let sum = 0;
    let isAllSame = true;

    for (let i = 0; i < numbers.length - 1; i++) {

        if (numbers[i] != numbers[i + 1]) {
            isAllSame = false;
            break;
        }
    }

    for (let i = 0; i < numbers.length; i++) {

        sum += numbers[i];
    }

    console.log(isAllSame);
    console.log(sum);
}

solve(2222222);
solve(1234);