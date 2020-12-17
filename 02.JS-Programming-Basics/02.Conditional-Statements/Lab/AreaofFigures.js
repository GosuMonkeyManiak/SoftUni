function solve(typeFigure, firstArgument, secondArgument) {

    let area = 0;

    if (typeFigure == "square") {
        
        firstArgument = Number(firstArgument);
        area = firstArgument * firstArgument;

    } else if (typeFigure == "rectangle") {
        
        firstArgument = Number(firstArgument);
        secondArgument = Number(secondArgument);

        area = firstArgument * secondArgument;

    } else if (typeFigure == "circle") {
        
        firstArgument = Number(firstArgument);

        area = Math.PI * Math.pow(firstArgument, 2);

    } else {

        firstArgument = Number(firstArgument);
        secondArgument = Number(secondArgument);

        area = firstArgument * secondArgument / 2;
    }

    console.log(area.toFixed(3));
}

solve("circle", "6");
