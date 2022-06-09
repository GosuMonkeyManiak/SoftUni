const lookupChar = require('./charLoopup');
const assert = require('chai').assert;

describe('LoopUpChar Tests', () => {

    it('when pass valid parameters should return a character that we want to look up', () => {
        assert.equal(lookupChar('mercedes', 3), 'c');
        assert.equal(lookupChar('mercedes', 0), 'm');
        assert.equal(lookupChar('mercedes', 7), 's');
    });

    it('when pass incorrect second parameter index which is out of string should return undefined', () => {
        assert.equal(lookupChar('mercedes', -1), 'Incorrect index');
        assert.equal(lookupChar('mercedes', -120), 'Incorrect index');
        assert.equal(lookupChar('mercedes', 120), 'Incorrect index');
        assert.equal(lookupChar('mercedes', 8), 'Incorrect index');
    });

    it('when pass as first parameter number should return undefined', () => {
        assert.isUndefined(lookupChar(1, 1));
        assert.isUndefined(lookupChar(3.14, 1));
        assert.isUndefined(lookupChar(1000, 1));
    });

    it('when pass as first parameter boolean should return undefined', () => {
        assert.isUndefined(lookupChar(true, 1));
        assert.isUndefined(lookupChar(false, 1));
        assert.isUndefined(lookupChar(true, 1));
    });

    it('when pass as first parameter array should return undefined', () => {
        assert.isUndefined(lookupChar([], 1));
        assert.isUndefined(lookupChar([1 , 2, 3], 1));
        assert.isUndefined(lookupChar(['1', '2', '3'], 1));
    });

    it('when pass as first parameter object should return undefined', () => {
        assert.isUndefined(lookupChar({}, 1));
        assert.isUndefined(lookupChar({ first: 'test', second: 'test'}, 1));
    });

    it('when pass as second parameter boolean should return undefined', () => {
        assert.isUndefined(lookupChar('asda', true));
        assert.isUndefined(lookupChar('false', false));
        assert.isUndefined(lookupChar('true', true));
    });

    it('when pass as second parameter array should return undefined', () => {
        assert.isUndefined(lookupChar('adasd', []));
        assert.isUndefined(lookupChar('dasda', [1 , 2, 3]));
        assert.isUndefined(lookupChar('asdasd', ['1', '2', '3']));
    });

    it('when pass as second parameter object should return undefined', () => {
        assert.isUndefined(lookupChar('sadasd', {}));
        assert.isUndefined(lookupChar('dasdasd', { first: 'test', second: 'test'}));
    });

    it('when pass invalid parameters should return undefined', () => {
        assert.isUndefined(lookupChar('1', '1'));
        assert.isUndefined(lookupChar(true, false));
        assert.isUndefined(lookupChar([1 , 1, 3], ['1' , '1', '3']));
        assert.isUndefined(lookupChar({}, {}));
    });

    it('when do not pass parameters should return undefined', () => {
        assert.isUndefined(lookupChar());
    });
});