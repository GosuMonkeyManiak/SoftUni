const rentCar = require('./rentCar');
const assert = require('chai').assert;

describe('Rent Car Test', () => {

    describe('searchCar tests', () => {
        
        it('when pass arrya of models and valid model should return message', () => {
            assert.equal(rentCar.searchCar(['BMW', 'Audi', 'Mercedes'], 'Mercedes'), 'There is 1 car of model Mercedes in the catalog!');
            assert.equal(rentCar.searchCar(['Audi', 'Audi', 'Audi'], 'Audi'), 'There is 3 car of model Audi in the catalog!');
            assert.equal(rentCar.searchCar(['BMW', 'BMW', 'Mercedes'], 'BMW'), 'There is 2 car of model BMW in the catalog!');
            assert.equal(rentCar.searchCar(['BMW'], 'BMW'), 'There is 1 car of model BMW in the catalog!');
        });

        it('when pass array of models and model which is not included in array should throw a exception', () => {
            assert.throw(() => rentCar.searchCar(['BMW', 'Audi', 'Mercedes'], 'Skoda'), 'There are no such models in the catalog!');
            assert.throw(() => rentCar.searchCar(['BMW', 'Audi'], 'Skoda'), 'There are no such models in the catalog!');
            assert.throw(() => rentCar.searchCar([], 'BMW'), 'There are no such models in the catalog!');
        });

        it('when pass invalid parameters should trow a exception', () => {
            assert.throw(() => rentCar.searchCar(), 'Invalid input!');
            assert.throw(() => rentCar.searchCar(''), 'Invalid input!');
            assert.throw(() => rentCar.searchCar('', ''), 'Invalid input!');
            assert.throw(() => rentCar.searchCar(1), 'Invalid input!');
            assert.throw(() => rentCar.searchCar(1, 1), 'Invalid input!');
            assert.throw(() => rentCar.searchCar(2.10), 'Invalid input!');
            assert.throw(() => rentCar.searchCar(2.10, 1.10), 'Invalid input!');
            assert.throw(() => rentCar.searchCar([], []), 'Invalid input!');
            assert.throw(() => rentCar.searchCar([], ['sa', 'das', 1]), 'Invalid input!');
            assert.throw(() => rentCar.searchCar({}), 'Invalid input!');
            assert.throw(() => rentCar.searchCar({}, {}), 'Invalid input!');
            assert.throw(() => rentCar.searchCar(function() {}, function() {}), 'Invalid input!');
            assert.throw(() => rentCar.searchCar(true, false), 'Invalid input!');
        });
    });

    describe('calculatePriceOfCar tests', () => {

        it('when pass valid model and days should return message', () => {
            assert.equal(rentCar.calculatePriceOfCar('Volkswagen', 1), `You choose Volkswagen and it will cost $${1 * 20}!`);
            assert.equal(rentCar.calculatePriceOfCar('Audi', 2), `You choose Audi and it will cost $${2 * 36}!`);
            assert.equal(rentCar.calculatePriceOfCar('Toyota', 3), `You choose Toyota and it will cost $${3 * 40}!`);
            assert.equal(rentCar.calculatePriceOfCar('BMW', 4), `You choose BMW and it will cost $${4 * 45}!`);
            assert.equal(rentCar.calculatePriceOfCar('Mercedes', 5), `You choose Mercedes and it will cost $${5 * 50}!`);
        });

        it('when pass not existed model should throw a exception', () => {
            assert.throw(() => rentCar.calculatePriceOfCar('BWM', 1), 'No such model in the catalog!');
            assert.throw(() => rentCar.calculatePriceOfCar('Mrcedes', 1), 'No such model in the catalog!');
            assert.throw(() => rentCar.calculatePriceOfCar('Toyot', 1), 'No such model in the catalog!');
            assert.throw(() => rentCar.calculatePriceOfCar('udi', 1), 'No such model in the catalog!');
            assert.throw(() => rentCar.calculatePriceOfCar('Volkswage', 1), 'No such model in the catalog!');
        });

        it('when pass invalid parameters should throw a exception', () => {
            assert.throw(() => rentCar.calculatePriceOfCar(), 'Invalid input!');
            assert.throw(() => rentCar.calculatePriceOfCar(1, 1), 'Invalid input!');
            assert.throw(() => rentCar.calculatePriceOfCar(-1, -1), 'Invalid input!');
            assert.throw(() => rentCar.calculatePriceOfCar(1.20, 1.20), 'Invalid input!');
            assert.throw(() => rentCar.calculatePriceOfCar(-1.20, -1.20), 'Invalid input!');
            assert.throw(() => rentCar.calculatePriceOfCar([], []), 'Invalid input!');
            assert.throw(() => rentCar.calculatePriceOfCar(function() {}, function() {}), 'Invalid input!');
            assert.throw(() => rentCar.calculatePriceOfCar({}, {}), 'Invalid input!');
            assert.throw(() => rentCar.calculatePriceOfCar(true, false), 'Invalid input!');
            assert.throw(() => rentCar.calculatePriceOfCar('', ''), 'Invalid input!');
            assert.throw(() => rentCar.calculatePriceOfCar('dasda', '13123'), 'Invalid input!');
        });
    });

    describe('checkBudget test', () => {

        it('when pass valid parameters should return message', () => {
            assert.equal(rentCar.checkBudget(10, 10, 100), 'You rent a car!');
            assert.equal(rentCar.checkBudget(10, 10, 120), 'You rent a car!');
            assert.equal(rentCar.checkBudget(10, 10, 200), 'You rent a car!');
            assert.equal(rentCar.checkBudget(10, 100, 100), 'You need a bigger budget!');
            assert.equal(rentCar.checkBudget(10, 100, 120), 'You need a bigger budget!');
            assert.equal(rentCar.checkBudget(10, 100, 200), 'You need a bigger budget!');
        });
    });
});