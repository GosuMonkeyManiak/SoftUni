function solve(x1, y1, x2, y2) {

    x1 = Number(x1);
    y1 = Number(y1);
    x2 = Number(x2);
    y2 = Number(y2);

    let firstPointToCenter = Math.sqrt(Math.pow(0 - x1, 2) + Math.pow(0 - y1, 2));

    if (Number.isInteger(firstPointToCenter)) {
        
        console.log(`{${x1}, ${y1}} to {0, 0} is valid`);
    } else {

        console.log(`{${x1}, ${y1}} to {0, 0} is invalid`);
    }

    let secondPointToCenter = Math.sqrt(Math.pow(0 - x2, 2) + Math.pow(0 - y2, 2));

    if (Number.isInteger(secondPointToCenter)) {
        
        console.log(`{${x2}, ${y2}} to {0, 0} is valid`);
    } else {

        console.log(`{${x2}, ${y2}} to {0, 0} is invalid`);
    }

    let secondPointToFirstPoint = Math.sqrt(Math.pow(x1 - x2, 2) + Math.pow(y1 - y2, 2));

    if (Number.isInteger(secondPointToFirstPoint)) {
        
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`);
    } else {

        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
    }
}

solve(3, 0, 0, 4);
solve(2, 1, 1, 1);