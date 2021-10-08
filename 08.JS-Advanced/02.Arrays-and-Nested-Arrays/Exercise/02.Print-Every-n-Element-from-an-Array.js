function solve(inputNumbers, increament) {

    let result = [];

    for (let index = 0; index < inputNumbers.length; index+= increament) {

        result.push(inputNumbers[index]);
    }

    return result;
}

console.log(solve(['5', '20', '31', '4', '20'], 2));