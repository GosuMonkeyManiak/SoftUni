const isOddOrEven = require('./evenOrOdd');
const assert = require('chai').assert;

describe('IsOddOrEven tests', () => {
    
    it('when pass valid parameter with odd length should return odd', () => {
        assert.equal(isOddOrEven('123'), 'odd');
    });

    it('when pass valid parameter with even length should return even', () => {
        assert.equal(isOddOrEven('1234'), 'even');
    });

    it('when pass empty string should return even', () => {
        assert.equal(isOddOrEven(''), 'even');
    });

    it('when don\'t pass parameter should return undefined', () => {
        assert.isUndefined(isOddOrEven());
    });

    it('when pass numberic value should return undefined', () => {
        assert.isUndefined(isOddOrEven(1));
        assert.isUndefined(isOddOrEven(3.14));
    });

    it('when pass boolean value should return undefined', () => {
        assert.isUndefined(isOddOrEven(true));
        assert.isUndefined(isOddOrEven(false));
    });

    it('when pass array value should return undefined', () => {
        assert.isUndefined(isOddOrEven([]));
        assert.isUndefined(isOddOrEven([1 , 2, 3]));
        assert.isUndefined(isOddOrEven(['1' , '2', '3']));
        assert.isUndefined(isOddOrEven([{} , {}, {}]));
        assert.isUndefined(isOddOrEven([true , false, false]));
    });

    it('when pass a object value should return undefined', () => {
        assert.isUndefined(isOddOrEven({}));
        assert.isUndefined(isOddOrEven({ one: 'one', two: 'test two'}));
    });
});