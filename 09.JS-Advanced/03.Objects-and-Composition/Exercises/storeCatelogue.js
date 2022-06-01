function storeCatalogue(input) {

    let products = input.map(e => {
        let elementParts = e.split(' : ');
        return { 
            productName: elementParts[0], 
            productPrice: Number(elementParts[1]) 
        };
    });

    products.sort((a, b) => a.productName.localeCompare(b.productName));
    
    let alfaBetCharacter = products[0].productName[0];
    console.log(alfaBetCharacter);

    for (let i = 0; i < products.length; i++) {
        
        if (!products[i].productName.startsWith(alfaBetCharacter)) {
            alfaBetCharacter = products[i].productName[0];
            console.log(alfaBetCharacter);
        }

        console.log(`  ${products[i].productName}: ${products[i].productPrice}`);
    }
}

storeCatalogue(
    ['Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10']);