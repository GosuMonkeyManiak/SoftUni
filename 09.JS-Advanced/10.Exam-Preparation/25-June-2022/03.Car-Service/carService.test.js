const carService = require('./carService');
const assert = require('chai').assert;

describe('carService tests', () => {

    describe('isItExpensive tests', () => {

        it('when pass engine or transmission should return special message', () => {
            assert.equal(carService.isItExpensive('Engine'), 'The issue with the car is more severe and it will cost more money');
            assert.equal(carService.isItExpensive('Transmission'), 'The issue with the car is more severe and it will cost more money');
        });

        it('when pass engine part different from engine or transmission should return message', () => {
            assert.equal(carService.isItExpensive('Clutch'), 'The overall price will be a bit cheaper');
            assert.equal(carService.isItExpensive('Drift shaft'), 'The overall price will be a bit cheaper');
        });
    });

    describe('discount tests', () => {
        
        it('when pass parts between 3 and 7 should return message with price saved', () => {
            assert.equal(carService.discount(3, 100), `Discount applied! You saved ${100 * 0.15}$`);
            assert.equal(carService.discount(4, 100), `Discount applied! You saved ${100 * 0.15}$`);
            assert.equal(carService.discount(5, 100), `Discount applied! You saved ${100 * 0.15}$`);
            assert.equal(carService.discount(6, 100), `Discount applied! You saved ${100 * 0.15}$`);
            assert.equal(carService.discount(7, 100), `Discount applied! You saved ${100 * 0.15}$`);
        });

        it('when pass parts which count is bigger than 7 have bigger discount', () => {
            assert.equal(carService.discount(8, 100), `Discount applied! You saved ${100 * 0.3}$`);
            assert.equal(carService.discount(9, 100), `Discount applied! You saved ${100 * 0.3}$`);
            assert.equal(carService.discount(10, 100), `Discount applied! You saved ${100 * 0.3}$`);
            assert.equal(carService.discount(11, 100), `Discount applied! You saved ${100 * 0.3}$`);
        });

        it('when pass parts which count is less or equal to 2 should return special message', () => {
            assert.equal(carService.discount(1, 100), 'You cannot apply a discount');
            assert.equal(carService.discount(2, 100), 'You cannot apply a discount');
            assert.equal(carService.discount(0, 100), 'You cannot apply a discount');
            assert.equal(carService.discount(-1, 100), 'You cannot apply a discount');
        });

        it('when pass invalid parameters should throw a exception', () => {
            assert.throw(() => carService.discount(), 'Invalid input');
            assert.throw(() => carService.discount(''), 'Invalid input');
            assert.throw(() => carService.discount('', ''), 'Invalid input');
            assert.throw(() => carService.discount(true, false), 'Invalid input');
            assert.throw(() => carService.discount({}, {}), 'Invalid input');
            assert.throw(() => carService.discount([], []), 'Invalid input');
            assert.throw(() => carService.discount(function() {}, function() {}), 'Invalid input');
        });
    });

    describe('partsToBuy tests', () => {

        it('when pass valid catalog and valid parts should return needed price', () => {
            assert.equal(carService.partsToBuy([{
                part: 'blowoff valve',
                price: 145
            },{
                part: 'coil springs',
                price: 230
            }], ['blowoff valve', 'coil springs']), 145 + 230);

            assert.equal(carService.partsToBuy([{
                part: 'blowoff valve',
                price: 145
            },{
                part: 'coil springs',
                price: 230
            }], ['blowoff valv', 'coi springs']), 0);
        });

        it('when catelog is empty should return zero', () => {
            assert.equal(carService.partsToBuy([], ['blowoff valv', 'coi springs']), 0);
        });

        it('when pass invalid parameters should throw a exception', () => {
            assert.throw(() => carService.partsToBuy(), 'Invalid input');
            assert.throw(() => carService.partsToBuy(1), 'Invalid input');
            assert.throw(() => carService.partsToBuy(1, 2), 'Invalid input');
            assert.throw(() => carService.partsToBuy(1.20, 2), 'Invalid input');
            assert.throw(() => carService.partsToBuy(1.20, 2.20), 'Invalid input');
            assert.throw(() => carService.partsToBuy('', ''), 'Invalid input');
            assert.throw(() => carService.partsToBuy(true, false), 'Invalid input');
            assert.throw(() => carService.partsToBuy({}, {}), 'Invalid input');
            assert.throw(() => carService.partsToBuy(function() {}, function() {}), 'Invalid input');
        });
    });
});