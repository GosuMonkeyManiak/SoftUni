function cooking(number, ...operations) {

    let numberToCook = Number(number);

    for (let index = 0; index < operations.length; index++) {

        switch (operations[index]) {
            case 'chop': numberToCook /= 2;
                break;

            case 'dice': numberToCook = Math.sqrt(numberToCook);
                break;
            
            case 'spice': numberToCook += 1;
                break;
            
            case 'bake': numberToCook *= 3;
                break;

            case 'fillet': numberToCook -= numberToCook * 0.2;
                break;
        }

        console.log(numberToCook);
    }
}

cooking('32', 'chop', 'chop', 'chop', 'chop', 'chop');
cooking('9', 'dice', 'spice', 'chop', 'bake', 'fillet');