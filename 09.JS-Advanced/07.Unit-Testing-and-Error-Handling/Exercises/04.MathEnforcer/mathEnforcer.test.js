const mathEnforcer = require('./mathEnforcer');
const assert = require('chai').assert;

describe('mathEnforcer', () => {

    it('when load module should return object with three properties which is functions', () => {
        assert.isObject(mathEnforcer);

        assert.isTrue(mathEnforcer.hasOwnProperty('addFive'));
        assert.isTrue(mathEnforcer.hasOwnProperty('subtractTen'));
        assert.isTrue(mathEnforcer.hasOwnProperty('sum'));

        assert.isFunction(mathEnforcer.addFive);
        assert.isFunction(mathEnforcer.subtractTen);
        assert.isFunction(mathEnforcer.sum);
    });

    describe('addFive', () => {

        it('when pass invalid parameters should return undefined', () => {
            assert.isUndefined(mathEnforcer.addFive(''));
            assert.isUndefined(mathEnforcer.addFive('120'));
            assert.isUndefined(mathEnforcer.addFive(true));
            assert.isUndefined(mathEnforcer.addFive([]));
            assert.isUndefined(mathEnforcer.addFive([1 , 2 , 3]));
            assert.isUndefined(mathEnforcer.addFive(['1' , '2' , '3']));
            assert.isUndefined(mathEnforcer.addFive({}));
            assert.isUndefined(mathEnforcer.addFive(() => {}));
            assert.isUndefined(mathEnforcer.addFive());
        });

        it('when pass positive integer number should return correct result', () => {
            assert.equal(mathEnforcer.addFive(10), 15);
            assert.equal(mathEnforcer.addFive(0), 5);
        });

        it('when pass negative integer number should return correct result', () => {
            assert.equal(mathEnforcer.addFive(-10), -5);
            assert.equal(mathEnforcer.addFive(-5), 0);
        });

        it('when pass positive floating point number should return correct result', () => {
            assert.closeTo(mathEnforcer.addFive(3.33), 8.33, 0.01);
            assert.closeTo(mathEnforcer.addFive(10.23), 15.23, 0.01);
        });

        it('when pass negative floating point number should return correct result', () => {
            assert.closeTo(mathEnforcer.addFive(-3.33), 1.67, 0.01);
            assert.closeTo(mathEnforcer.addFive(-10.23), -5.23, 0.01);
        });
    });

    describe('subtractTen', () => {

        it('when pass invalid parameters should return undefined', () => {
            assert.isUndefined(mathEnforcer.subtractTen(''));
            assert.isUndefined(mathEnforcer.subtractTen('120'));
            assert.isUndefined(mathEnforcer.subtractTen(true));
            assert.isUndefined(mathEnforcer.subtractTen([]));
            assert.isUndefined(mathEnforcer.subtractTen([1 , 2 , 3]));
            assert.isUndefined(mathEnforcer.subtractTen(['1' , '2' , '3']));
            assert.isUndefined(mathEnforcer.subtractTen({}));
            assert.isUndefined(mathEnforcer.addFive(() => {}));
            assert.isUndefined(mathEnforcer.subtractTen());
        });

        it('when pass positive integer number should return correct result', () => {
            assert.equal(mathEnforcer.subtractTen(10), 0);
            assert.equal(mathEnforcer.subtractTen(0), -10);
        });

        it('when pass negative integer number should return correct result', () => {
            assert.equal(mathEnforcer.subtractTen(-10), -20);
            assert.equal(mathEnforcer.subtractTen(-5), -15);
        });

        it('when pass positive floating point number should return correct result', () => {
            assert.closeTo(mathEnforcer.subtractTen(3.33), -6.67, 0.01);
            assert.closeTo(mathEnforcer.subtractTen(10.45), 0.45, 0.01);
        });

        it('when pass negative floating point number should return correct result', () => {
            assert.closeTo(mathEnforcer.subtractTen(-3.33), -13.33, 0.01);
            assert.closeTo(mathEnforcer.subtractTen(-10.23), -20.23, 0.01);
        });
    });

    describe('sum', () => {

        it('when pass invalid parameters should return undefined', () => {
            assert.isUndefined(mathEnforcer.sum('', ''));
            assert.isUndefined(mathEnforcer.sum('120', '20'));
            assert.isUndefined(mathEnforcer.sum(true, false));
            assert.isUndefined(mathEnforcer.sum([], []));
            assert.isUndefined(mathEnforcer.sum([1 , 2 , 3], [1 , 2 , 3]));
            assert.isUndefined(mathEnforcer.sum(['1' , '2' , '3'], ['1' , '2' , '3']));
            assert.isUndefined(mathEnforcer.sum({}, {}));
            assert.isUndefined(mathEnforcer.sum(() => {} ,() => {}));
            assert.isUndefined(mathEnforcer.sum());
            assert.isUndefined(mathEnforcer.sum(''));
            assert.isUndefined(mathEnforcer.sum('120'));
            assert.isUndefined(mathEnforcer.sum(true));
            assert.isUndefined(mathEnforcer.sum([]));
            assert.isUndefined(mathEnforcer.sum([1 , 2 , 3]));
            assert.isUndefined(mathEnforcer.sum(['1' , '2' , '3']));
            assert.isUndefined(mathEnforcer.sum({}));
            assert.isUndefined(mathEnforcer.sum(() => {}));
        });

        it('when pass positive integer number should return correct result', () => {
            assert.equal(mathEnforcer.sum(5, 10), 15);
            assert.equal(mathEnforcer.sum(0, 10), 10);
            assert.equal(mathEnforcer.sum(0, 0), 0);
        });

        it('when pass negative integer number should return correct result', () => {
            assert.equal(mathEnforcer.sum(-10, -10), -20);
            assert.equal(mathEnforcer.sum(-5, -15), -20);
        });

        it('when pass negative and positive integer number should return correct result', () => {
            assert.equal(mathEnforcer.sum(-10, 10), 0);
            assert.equal(mathEnforcer.sum(-5, 15), 10);
        });

        it('when pass positive floating point number should return correct result', () => {
            assert.closeTo(mathEnforcer.sum(3.10, 4.10), 7.19, 0.01);
            assert.closeTo(mathEnforcer.sum(10.50, 10.50), 21, 0.01);
        });

        it('when pass positive and negative floating point number should return correct result', () => {
            assert.closeTo(mathEnforcer.sum(-3.10, 4.10), 0.99, 0.01);
            assert.closeTo(mathEnforcer.sum(10.50, -10.50), 0, 0.01);
        });

        it('when pass negative floating point number should return correct result', () => {
            assert.closeTo(mathEnforcer.sum(-3.30, -3.30), -6.60, 0.01);
            assert.closeTo(mathEnforcer.sum(-10.40, -10.40), -20.80, 0.01);
        });
    });
});