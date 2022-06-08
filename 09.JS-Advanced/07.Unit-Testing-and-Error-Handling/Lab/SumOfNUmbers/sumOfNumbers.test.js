const sum = require('./sumOfNumbers');
const assert = require('chai').assert;

describe('Test group #1', () => {
    it('should return sum when passed array', () => {
        assert.equal(sum([1, 2, 3, 4, 5, 6, 7, 8, 9]), 45);
    });
}); 