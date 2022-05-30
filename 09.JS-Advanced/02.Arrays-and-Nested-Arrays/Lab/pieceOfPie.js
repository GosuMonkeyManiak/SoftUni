function pieceOfPie(pieFlavors, ...flavors) {

    let firstIndex = 0;
    let lastIndex = 0;

    for (let i = 0; i < flavors.length; i++) {
        
        if (pieFlavors.includes(flavors[i])) {
            firstIndex = pieFlavors.indexOf(flavors[i]);
            break;
        }
    }

    for (let i = flavors.length - 1; i >= 0; i--) {
        
        if (pieFlavors.includes(flavors[i])) {
            lastIndex = pieFlavors.indexOf(flavors[i]);
            break;
        }
    }

    let result = pieFlavors.slice(firstIndex, lastIndex + 1);

    return result;
}

console.log(pieceOfPie(['Apple Crisp',
 'Mississippi Mud Pie',
 'Pot Pie',
 'Steak and Cheese Pie',
 'Butter Chicken Pie',
 'Smoked Fish Pie'],
'Pot Pie',
'Smoked Fish Pie'
));

console.log(pieceOfPie(['Pumpkin Pie',
 'Key Lime Pie',
 'Cherry Pie',
 'Lemon Meringue Pie',
 'Sugar Cream Pie'],
'Key Lime Pie',
'Lemon Meringue Pie'
));