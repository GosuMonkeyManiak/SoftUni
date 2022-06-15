function solve(arrayOfCars) {

    let brands = new Map();

    for (const car of arrayOfCars) {
        
        let carParts = car.split(' | ');
        let carBrand = carParts[0];
        let carModel = carParts[1];

        let carProduced = Number(carParts[2]);

        if (brands.has(carBrand)) {
            let models = brands.get(carBrand);

            if (models.has(carModel)) {
                let newProduced = models.get(carModel) + carProduced;
                models.set(carModel, newProduced);
            } else {
                models.set(carModel, carProduced);
            }
            
        } else {
            let models = new Map();
            models.set(carModel, carProduced);

            brands.set(carBrand, models);
        }
    }

    for (const [brandKey, brandValue] of brands) {
        
        console.log(brandKey);

        for (const [key, value] of brandValue) {
            console.log(`###${key} -> ${value}`);
        }
    }
}

console.log(solve(['Audi | Q7 | 1000',
'Audi | Q6 | 100',
'BMW | X5 | 1000',
'BMW | X6 | 100',
'Citroen | C4 | 123',
'Volga | GAZ-24 | 1000000',
'Lada | Niva | 1000000',
'Lada | Jigula | 1000000',
'Citroen | C4 | 22',
'Citroen | C5 | 10']
));