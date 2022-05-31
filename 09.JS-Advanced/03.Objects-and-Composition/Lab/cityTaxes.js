function cityTaxes(name, population, treasury) {

    let city = {
        name,
        population,
        treasury,
        taxRate : 10,
        collectTaxes() {
            this.treasury += this.population * this.taxRate;
            Math.floor(this.treasury);
        },
        applyGrowth(percentage) {
            this.population *= 1 + (percentage / 100); 
            Math.floor(this.population);
        },
        applyRecession(percentage){
            this.treasury *= 1 - (percentage / 100); 
            Math.floor(this.treasury);
        }
    };

    return city;
}

const city = 
  cityTaxes('Tortuga',
  7000,
  15000);
console.log(city);

const city1 =
  cityTaxes('Tortuga',
  7000,
  15000);
city1.collectTaxes();
console.log(city1.treasury);
city1.applyGrowth(5);
console.log(city1.population);

