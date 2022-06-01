function lowestPricesInCities(townsWithProducts) {

    let lowsetPricesForProducts = [];

    for (let i = 0; i < townsWithProducts.length; i++) {
        
        let townParts = townsWithProducts[i].split(' | ');

        let currentTown = {
            townName: townParts[0],
            productName: townParts[1],
            productLowestPrice: Number(townParts[2])
        };

        if (lowsetPricesForProducts.some(x => x.townName == currentTown.townName && x.productName == currentTown.productName)) {

            let index = lowsetPricesForProducts.findIndex(x => x.townName == currentTown.townName);
            let town = lowsetPricesForProducts[index];

            if (town.productLowestPrice > currentTown.productLowestPrice) {
                lowsetPricesForProducts[index] = currentTown;
            }
        } else if (lowsetPricesForProducts.some(x => x.townName == currentTown.townName)) {

            let index = lowsetPricesForProducts.findIndex(x => x.productName == currentTown.productName);

            if (index == -1) {
                lowsetPricesForProducts.push(currentTown);
                continue;
            }

            let town = lowsetPricesForProducts[index];

            if (town.productLowestPrice > currentTown.productLowestPrice) {
                lowsetPricesForProducts[index] = currentTown;
            }

        } else if (lowsetPricesForProducts.some(x => x.productName == currentTown.productName)) {

            let index = lowsetPricesForProducts.findIndex(x => x.productName == currentTown.productName);
            let town = lowsetPricesForProducts[index];

            if (town.productLowestPrice > currentTown.productLowestPrice) {
                lowsetPricesForProducts[index] = currentTown;
            }
            
        } else {
            lowsetPricesForProducts.push(currentTown);
        }
    }

    for (let i = 0; i < lowsetPricesForProducts.length; i++) {
        
        console.log(`${lowsetPricesForProducts[i].productName} -> ${lowsetPricesForProducts[i].productLowestPrice} (${lowsetPricesForProducts[i].townName})`);
    }
}

lowestPricesInCities(
    ['Sample Town | Sample Product | 1000',
    'Sample Town | Orange | 2',
    'Sample Town | Peach | 1',
    'Sofia | Orange | 3',
    'Sofia | Peach | 2',
    'New York | Sample Product | 1000.1',
    'New York | Burger | 10']);