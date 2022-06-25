const flowerShop = require('./flowerShop');
const assert = require('chai').assert;

describe('Flower Shop Tests', () => {

    describe('calcPriceOfFlowers tests', () => {
        
        it('when pass valid price and quantity should return message', () => {
            assert.equal(flowerShop.calcPriceOfFlowers('Roses', 10, 3), `You need $${(10 * 3).toFixed(2)} to buy Roses!`);
            assert.equal(flowerShop.calcPriceOfFlowers('Roses', 1, 3), `You need $${(1 * 3).toFixed(2)} to buy Roses!`);
            assert.equal(flowerShop.calcPriceOfFlowers('Roses', 20, 4), `You need $${(20 * 4).toFixed(2)} to buy Roses!`);
        });

        it('when pass invalid parameters should throw a exception', () => {
            assert.throw(() => flowerShop.calcPriceOfFlowers(), 'Invalid input!');
            assert.throw(() => flowerShop.calcPriceOfFlowers(1), 'Invalid input!');
            assert.throw(() => flowerShop.calcPriceOfFlowers(1, '1'), 'Invalid input!');
            assert.throw(() => flowerShop.calcPriceOfFlowers(1, '1', '2'), 'Invalid input!');
            assert.throw(() => flowerShop.calcPriceOfFlowers(1, 1.20, '2'), 'Invalid input!');
            assert.throw(() => flowerShop.calcPriceOfFlowers(1, 1.20, 2.20), 'Invalid input!');
            assert.throw(() => flowerShop.calcPriceOfFlowers(true, false, false), 'Invalid input!');
            assert.throw(() => flowerShop.calcPriceOfFlowers([], [], []), 'Invalid input!');
            assert.throw(() => flowerShop.calcPriceOfFlowers({}, {}, {}), 'Invalid input!');
            assert.throw(() => flowerShop.calcPriceOfFlowers(function() {}, function() {}, function() {}), 'Invalid input!');
            assert.throw(() => flowerShop.calcPriceOfFlowers('', '', ''), 'Invalid input!');
        });
    });

    describe('checkFlowersAvailable tests', () => {

        it('when pass flower which is in the array should return succed message', () => {
            assert.equal(flowerShop.checkFlowersAvailable('Rose', ['Rose', 'Lily', 'Orchid']), 'The Rose are available!');
            assert.equal(flowerShop.checkFlowersAvailable('Lily', ['Rose', 'Lily', 'Orchid']), 'The Lily are available!');
            assert.equal(flowerShop.checkFlowersAvailable('Orchid', ['Rose', 'Lily', 'Orchid']), 'The Orchid are available!');
        });

        it('when pass flower which is not included in the array should return fail message', () => {
            assert.equal(flowerShop.checkFlowersAvailable('Rose', ['Lily', 'Orchid']), 'The Rose are sold! You need to purchase more!');
            assert.equal(flowerShop.checkFlowersAvailable('Lily', ['Rose', 'Orchid']), 'The Lily are sold! You need to purchase more!');
            assert.equal(flowerShop.checkFlowersAvailable('Orchid', ['Rose', 'Lily']), 'The Orchid are sold! You need to purchase more!');
        });
    });

    describe('sellFlowers test', () => {
        
        it('when pass valid parameters should receive a message', () => {
            assert.equal(flowerShop.sellFlowers(['Rose', 'Lily', 'Orchid'], 0), 'Lily / Orchid');
            assert.equal(flowerShop.sellFlowers(['Rose', 'Lily', 'Orchid'], 1), 'Rose / Orchid');
            assert.equal(flowerShop.sellFlowers(['Rose', 'Lily', 'Orchid'], 2), 'Rose / Lily');
        });

        it('when pass invalid parameters should throw a exception', () => {
            assert.throw(() => flowerShop.sellFlowers(), 'Invalid input!');
            assert.throw(() => flowerShop.sellFlowers(1), 'Invalid input!');
            assert.throw(() => flowerShop.sellFlowers(1, ''), 'Invalid input!');
            assert.throw(() => flowerShop.sellFlowers(1, 1), 'Invalid input!');
            assert.throw(() => flowerShop.sellFlowers(1.20, 2.20), 'Invalid input!');
            assert.throw(() => flowerShop.sellFlowers('1.20', '2.20'), 'Invalid input!');
            assert.throw(() => flowerShop.sellFlowers(true, false), 'Invalid input!');
            assert.throw(() => flowerShop.sellFlowers([], []), 'Invalid input!');
            assert.throw(() => flowerShop.sellFlowers({}, {}), 'Invalid input!');
            assert.throw(() => flowerShop.sellFlowers(function() {}, function() {}), 'Invalid input!');
        });
    });
});