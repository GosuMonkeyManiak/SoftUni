function solve(number, ...operations) {

    number = Number(number);

    for (let i = 0; i < operations.length; i++) {

        if (operations[i] == 'chop') {

            number = number / 2;

        } else if (operations[i] == 'dice') {

            number = Math.sqrt(number);

        } else if (operations[i] == 'spice') {

            number++;
            
        } else if (operations[i] == 'bake') {

            number = number * 3;
            
        } else if (operations[i] == 'fillet') {

            let twentyProcent = number * 0.2;
            number = number - twentyProcent;
        }

        console.log(number);
    }
}

solve(32, 'chop', 'chop', 'chop', 'chop', 'chop');
solve('9', 'dice', 'spice', 'chop', 'bake', 'fillet');