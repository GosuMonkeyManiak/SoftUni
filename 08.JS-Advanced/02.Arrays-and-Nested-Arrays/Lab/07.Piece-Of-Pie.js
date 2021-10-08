function solve(pies, startPie, endPie) {

    let startIndex = pies.indexOf(startPie);
    let endIndex = pies.indexOf(endPie);

    let result = pies
        .slice(startIndex, endIndex + 1);

    return result;
}

console.log(solve(['Pumpkin Pie','Key Lime Pie','Cherry Pie','Lemon Meringue Pie','Sugar Cream Pie'],
'Key Lime Pie','Lemon Meringue Pie'));