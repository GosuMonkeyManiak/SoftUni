class Garden {

    constructor(spaceAvailable) {
        this.spaceAvailable = Number(spaceAvailable);
        this.plants = [];
        this.storage = [];
    }

    addPlant(plantName, spaceRequired) {

        if (spaceRequired > this.spaceAvailable) {
            throw new Error('Not enough space in the garden.');
        }

        let plant = {
            plantName,
            spaceRequired,
            ripe: false,
            quantity: 0
        };

        this.plants.push(plant);

        this.spaceAvailable -= spaceRequired;

        return `The ${plantName} has been successfully planted in the garden.`;
    }

    ripenPlant(plantName, quantity) {

        let plant = this.plants.find(x => x.plantName == plantName);

        if (plant == undefined) {
            throw new Error(`There is no ${plantName} in the garden.`);
        }

        if (plant.ripe) {
            throw new Error(`The ${plantName} is already ripe.`);
        }

        if (quantity <= 0) {
            throw new Error(`The quantity cannot be zero or negative.`);
        }

        plant.ripe = true;
        plant.quantity = quantity;

        if (quantity == 1) {
            return `${quantity} ${plantName} has successfully ripened.`;
        } else {
            return `${quantity} ${plantName}s have successfully ripened.`;
        }
    }

    harvestPlant(plantName) {

        let plant = this.plants.find(x => x.plantName == plantName);
        let plantIndex = this.plants.findIndex(x => x.plantName == plantName);

        if (plant == undefined) {
            throw new Error(`There is no ${plantName} in the garden.`);
        }

        if (!plant.ripe) {
            throw new Error(`The ${plantName} cannot be harvested before it is ripe.`);
        }

        this.plants.splice(plantIndex, 1);

        let plantForStorage = {
            plantName,
            quantity: plant.quantity
        };

        this.storage.push(plantForStorage);

        this.spaceAvailable += plant.spaceRequired;

        return `The ${plantName} has been successfully harvested.`;
    }

    generateReport() {
        this.plants.sort((a, b) => a.plantName.localeCompare(b.plantName));

        let result = `The garden has ${this.spaceAvailable} free space left.\n`;
        result += `Plants in the garden: ${this.plants.map(x => x.plantName).join(', ')}\n`;

        if (this.storage.length == 0) {
            result += 'Plants in storage: The storage is empty.'
        } else {
            let storagePlants = this.storage.map(x => `${x.plantName} (${x.quantity})`);

            result += `Plants in storage: ${storagePlants.join(', ')}`;
        }

        return result;
    }
}

const myGarden = new Garden(250)
console.log(myGarden.addPlant('apple', 20));
console.log(myGarden.addPlant('orange', 200));
console.log(myGarden.addPlant('raspberry', 10));
console.log(myGarden.ripenPlant('apple', 10));
console.log(myGarden.ripenPlant('orange', 1));
console.log(myGarden.harvestPlant('orange'));
console.log(myGarden.generateReport());
