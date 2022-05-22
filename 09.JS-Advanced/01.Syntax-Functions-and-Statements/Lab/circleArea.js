function solve(circleRadius) {
    let typeOfArgument = typeof circleRadius;

    if (typeOfArgument == "number") {
        console.log((Math.PI * circleRadius ** 2).toFixed(2));
    } else {
        console.log(
            `We can not calculate the circle area, because we receive a ${typeOfArgument}.`
        );
    }
}

solve(5);
solve("name");
