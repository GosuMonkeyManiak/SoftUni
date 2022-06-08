const isSymmetric = require('./checkForSymmetry');
const assert = require('chai').assert;

describe('IsSymmetric Test', () => {

    it('when pass string should return false', () => {
        assert.equal(isSymmetric('test'), false);
    });

    it('when pass one numberic value should return false', () => {
        assert.equal(isSymmetric(1), false);
        assert.equal(isSymmetric(1.2), false);
    });

    it('when pass boolean value should return false', () => {
        assert.equal(isSymmetric(true), false);
        assert.equal(isSymmetric(false), false);
    });

    it('when pass array with different values should return false', () => {
        assert.equal(isSymmetric([1, 1.2, 'sadasd', true, false, 'a']), false);
    });

    it('when pass valid symmetric array with numbers should return true', () => {
        assert.equal(isSymmetric([1, 2, 2, 1]), true);
        assert.equal(isSymmetric([1]), true);
        assert.equal(isSymmetric([1, 1]), true);
        assert.equal(isSymmetric([1, 2, 1]), true);
        assert.equal(isSymmetric([]), true);
    });

    it('when pass invalid symmetric array with numbers should return false', () => {
        assert.equal(isSymmetric([1, 2]), false);
        assert.equal(isSymmetric([1, 2, 1, 1]), false);
    });

    it('when pass valid symmetric array with strings should return true', () => {
        assert.equal(isSymmetric(['a', 'b', 'b', 'a']), true);
    });

    it('when pass valid symmetric array with strings should return false', () => {
        assert.equal(isSymmetric(['a', 'b', 'b']), false);
    });
});