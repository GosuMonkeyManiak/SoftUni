function solution() {

    let protein = 0;
    let carbohydrate = 0;
    let fat = 0;
    let flavour = 0;

    function manager(wholeCommand) {
        
        let commandParts = wholeCommand.split(' ');
        let command = commandParts[0];

        if (command == 'restock') {
            
            let microElement = commandParts[1];
            let quantity = Number(commandParts[2]);

            if (microElement == 'protein') {
                protein += quantity;
            } else if (microElement == 'carbohydrate') {
                carbohydrate += quantity;
            } else if (microElement == 'fat') {
                fat += quantity;
            } else if (microElement == 'flavour') {
                flavour += quantity;
            }

            return 'Success';

        } else if (command == 'prepare') {

            let recipe = commandParts[1];
            let quantity = Number(commandParts[2]);

            if (recipe == 'apple') {
                
                if (quantity * 1 > carbohydrate) {
                    return `Error: not enough carbohydrate in stock`;
                }

                if (quantity * 2 > flavour) {
                    return 'Error: not enough flavour in stock ';
                }

                carbohydrate -= quantity * 1;
                flavour -= quantity * 2;

            } else if (recipe == 'lemonade') {

                if (quantity * 10 > carbohydrate) {
                    return `Error: not enough carbohydrate in stock`;
                }

                if (quantity * 20 > flavour) {
                    return 'Error: not enough flavour in stock ';
                }

                carbohydrate -= quantity * 10;
                flavour -= quantity * 20;

            } else if (recipe == 'burger') {

                if (quantity * 5 > carbohydrate) {
                    return `Error: not enough carbohydrate in stock`;
                }

                if (quantity * 7 > fat) {
                    return `Error: not enough fat in stock`;
                }

                if (quantity * 3 > flavour) {
                    return 'Error: not enough flavour in stock ';
                }

                carbohydrate -= quantity * 5;
                fat -= quantity * 7;
                flavour -= quantity * 3;

            } else if (recipe == 'eggs') {

                if (quantity * 5 > protein) {
                    return `Error: not enough protein in stock`;
                }

                if (quantity * 1 > fat) {
                    return `Error: not enough fat in stock`;
                }

                if (quantity * 1 > flavour) {
                    return 'Error: not enough flavour in stock ';
                }

                protein -= quantity * 5;
                fat -= quantity * 1;
                flavour -= quantity * 1;

            } else if (recipe == 'turkey') {

                if (quantity * 10 > protein) {
                    return `Error: not enough protein in stock`;
                }

                if (quantity * 10 > carbohydrate) {
                    return `Error: not enough carbohydrate in stock`;
                }

                if (quantity * 10 > fat) {
                    return `Error: not enough fat in stock`;
                }

                if (quantity * 10 > flavour) {
                    return 'Error: not enough flavour in stock ';
                }

                protein -= quantity * 10;
                carbohydrate -= quantity * 10;
                fat -= quantity * 10;
                flavour -= quantity * 10;
            }

            return 'Success';

        } else if (command == 'report') {
            return `protein=${protein} carbohydrate=${carbohydrate} fat=${fat} flavour=${flavour}`;
        }
    }

    return manager;
}


['restock carbohydrate 10', 'Success'],
['restock flavour 10', 'Success'],
['prepare apple 1', 'Success'],
['restock fat 10', 'Success'],
['prepare burger 1', 'Success'],
['report', 'protein=0 carbohydrate=4 fat=3 flavour=5']

let manager = solution ();
console.log (manager ("restock carbohydrate 10")); 
console.log (manager ("restock flavour 10"));
console.log (manager ("prepare apple 1"));
console.log (manager ("restock fat 10"));
console.log (manager ("prepare burger 1"));
console.log (manager ("report"));
