function solve(typeOfFruit, weight, price) {
    let neededMoney = (weight / 1000) * price;

    console.log(`I need $${neededMoney.toFixed(2)} to buy ${(weight / 1000).toFixed(2)} kilograms ${typeOfFruit}.`);
}

solve('orange', 2500, 1.8);
solve('apple', 1563, 2.35);
