class CarDealership {

    constructor(name) {
        this.name = name;
        this.availableCars = [];
        this.soldCars = [];
        this.totalIncome = 0;
    }

    addCar(model, horsepower, price, mileage) {

        if (typeof model != 'string' || model == '') {
            throw new Error('Invalid input!');
        }

        if (typeof horsepower != 'number' || horsepower < 0 || !Number.isInteger(horsepower)) {
            throw new Error('Invalid input!');
        }

        if (typeof price != 'number' || price < 0) {
            throw new Error('Invalid input!');
        }

        if (typeof mileage != 'number' || mileage < 0) {
            throw new Error('Invalid input!');
        }

        this.availableCars.push({
            model,
            horsepower,
            price,
            mileage
        });

        return `New car added: ${model} - ${horsepower} HP - ${mileage.toFixed(2)} km - ${price.toFixed(2)}$`;
    }

    sellCar (model, desiredMileage) {

        let car = this.availableCars.find(x => x.model == model);

        if (car == undefined) {
            throw new Error(`${model} was not found!`);
        }

        let finalPrice = 0;

        if (car.mileage <= desiredMileage) {
            finalPrice = car.price;
        }else if (car.mileage - desiredMileage <= 40000) {
            let reduce = car.price * 0.05;
            finalPrice = car.price - reduce;
        } else {
            let reduce = car.price * 0.1;
            finalPrice = car.price - reduce;
        }

        let carIndex = this.availableCars.findIndex(x => x.model == model);

        this.availableCars.splice(carIndex, 1);

        this.soldCars.push({
            model: car.model,
            horsepower: car.horsepower,
            soldPrice: finalPrice
        });

        this.totalIncome += finalPrice;

        return `${model} was sold for ${finalPrice.toFixed(2)}$`;
    }

    currentCar() {

        if (this.availableCars.length == 0) {
            return `There are no available cars`;
        }

        let result = '-Available cars:\n';

        for (const car of this.availableCars) {
            
            result += `---${car.model} - ${car.horsepower} HP - ${car.mileage.toFixed(2)} km - ${car.price.toFixed(2)}$\n`;
        }

        return result.trim();
    }

    salesReport(criteria) {

        if (criteria == 'model') {
            this.soldCars.sort((a, b) => a[criteria].localeCompare(b[criteria]));
        } else if (criteria == 'horsepower') {
             this.soldCars.sort((a, b) => b[criteria] - a[criteria]);
        } else {
            throw new Error('Invalid criteria!');
        }

        let result = `-${this.name} has a total income of ${this.totalIncome.toFixed(2)}$\n-${this.soldCars.length} cars sold:\n`;

        for (const car of this.soldCars) {
            result += `---${car.model} - ${car.horsepower} HP - ${car.soldPrice.toFixed(2)}$\n`
        }
        
        return result.trim();
    }
}

let dealership = new CarDealership('SoftAuto');
dealership.addCar('Toyota Corolla', 100, 3500, 190000);
dealership.addCar('Mercedes C63', 300, 29000, 187000);
dealership.addCar('Audi A3', 120, 4900, 240000);
dealership.sellCar('Toyota Corolla', 230000);
dealership.sellCar('Mercedes C63', 110000);
console.log(dealership.salesReport(''));