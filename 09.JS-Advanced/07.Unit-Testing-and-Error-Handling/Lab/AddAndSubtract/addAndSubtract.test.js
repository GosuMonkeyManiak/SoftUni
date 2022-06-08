const createCalculator = require('./addAndSubtract');
const assert = require('chai').assert;

describe('CreateCalculator Tests', () => {

    it('when invoke function should return object that have three properties which is functions', () => {
        let calculator = createCalculator(); 

        assert.isObject(calculator);
        assert.isTrue(calculator.hasOwnProperty('add'));
        assert.isTrue(calculator.hasOwnProperty('subtract'));
        assert.isTrue(calculator.hasOwnProperty('get'));
        assert.isFunction(calculator['add']);
        assert.isFunction(calculator['subtract']);
        assert.isFunction(calculator['get']);
    });

    it('when call add should increase internal sum', () => {
        let calculator = createCalculator();
        calculator.add(5);
        calculator.add(3);

        assert.equal(calculator.get(), 8);
    });

    it('when call subtract should decrease internal sum', () => {
        let calculator = createCalculator();
        calculator.add(5);
        calculator.add(3);
        calculator.subtract(8)

        assert.equal(calculator.get(), 0);
    });

    it('when call add with number which is string should increase internal sum', () => {
        let calculator = createCalculator();
        calculator.add('5');
        calculator.add('3');

        assert.equal(calculator.get(), 8);
    });

    it('when call subtract with number which is string should decrease internal sum', () => {
        let calculator = createCalculator();
        calculator.add('5');
        calculator.add('3');
        calculator.subtract('8')

        assert.equal(calculator.get(), 0);
    });
});