const StringBuilder = require('./StringBuilder');
const assert = require('chai').assert;

describe('String Builder Tests', () => {

    describe('Instantiated test', () => {

        it('When create a instance with arguments should return instance', () =>{
            assert.isObject(new StringBuilder('alabala'));
            assert.isObject(new StringBuilder('Dimitar'));
            assert.isObject(new StringBuilder(''));
        });

        it('When create a instace with some string argument back field should have all characters of that string', () => {
            let someString = new StringBuilder('Pesho');

            let actual = someString._stringArray;
            let expected = ['P', 'e', 's', 'h', 'o'];

            for (let i = 0; i < actual.length; i++) {
                assert.isTrue(actual[i] === expected[i]);
            }
        });

        it('When create a instance with no argument should return instance', () => {
            assert.isObject(new StringBuilder());
            assert.isObject(new StringBuilder(undefined));
        });

        it('When try to create a instance with non-string arguments should throw an exception', () => {
            assert.Throw(() => new StringBuilder(12131), 'Argument must be a string');
            assert.Throw(() => new StringBuilder(12131.20), 'Argument must be a string');
            assert.Throw(() => new StringBuilder(-12131), 'Argument must be a string');
            assert.Throw(() => new StringBuilder(-12131.20), 'Argument must be a string');
            assert.Throw(() => new StringBuilder(0), 'Argument must be a string');
            assert.Throw(() => new StringBuilder([]), 'Argument must be a string');
            assert.Throw(() => new StringBuilder([1, 2, 3]), 'Argument must be a string');
            assert.Throw(() => new StringBuilder(['1', '2', '3']), 'Argument must be a string');
            assert.Throw(() => new StringBuilder([false, false, true]), 'Argument must be a string');
            assert.Throw(() => new StringBuilder([{}, {}, {}]), 'Argument must be a string');
            assert.Throw(() => new StringBuilder([function() {}, function() {}, function() {}]), 'Argument must be a string');
            assert.Throw(() => new StringBuilder({}), 'Argument must be a string');
            assert.Throw(() => new StringBuilder({name: 'alalbala', number: 12}), 'Argument must be a string');
            assert.Throw(() => new StringBuilder(function() {}), 'Argument must be a string');
            assert.Throw(() => new StringBuilder(null), 'Argument must be a string');
            assert.Throw(() => new StringBuilder(NaN), 'Argument must be a string');
        });
    });

    describe('Function append tests', () => {

        it('When call append should add passed string to end of array of characters', () => {
            let someString = new StringBuilder('Pesho');
            someString.append('123');

            let actual = someString._stringArray;
            let expected = ['P', 'e', 's', 'h', 'o', '1', '2', '3'];

            for (let i = 0; i < actual.length; i++) {
                assert.isTrue(actual[i] === expected[i]);
            }
        });

        it('When call apeend with empty string should be added to end of array of characters', () => {
            let someString = new StringBuilder('Pesho');
            someString.append('');

            let actual = someString._stringArray;
            let expected = ['P', 'e', 's', 'h', 'o', ''];

            for (let i = 0; i < actual.length; i++) {
                assert.isTrue(actual[i] === expected[i]);
            }
        });

        it('When call append with invalid non-string argument should throw an exception', () => {
            let someString = new StringBuilder('Pesho');

            assert.Throw(() => someString.append(12131), 'Argument must be a string');
            assert.Throw(() => someString.append(12131.20), 'Argument must be a string');
            assert.Throw(() => someString.append(-12131), 'Argument must be a string');
            assert.Throw(() => someString.append(-12131.20), 'Argument must be a string');
            assert.Throw(() => someString.append(0), 'Argument must be a string');
            assert.Throw(() => someString.append([]), 'Argument must be a string');
            assert.Throw(() => someString.append([1, 2, 3]), 'Argument must be a string');
            assert.Throw(() => someString.append(['1', '2', '3']), 'Argument must be a string');
            assert.Throw(() => someString.append([false, false, true]), 'Argument must be a string');
            assert.Throw(() => someString.append([{}, {}, {}]), 'Argument must be a string');
            assert.Throw(() => someString.append([function() {}, function() {}, function() {}]), 'Argument must be a string');
            assert.Throw(() => someString.append({}), 'Argument must be a string');
            assert.Throw(() => someString.append({name: 'alalbala', number: 12}), 'Argument must be a string');
            assert.Throw(() => someString.append(function() {}), 'Argument must be a string');
            assert.Throw(() => someString.append(null), 'Argument must be a string');
            assert.Throw(() => someString.append(NaN), 'Argument must be a string');
        });
    });

    describe('Function prepend tests', () => {

        it('When call prepend should add passed string to start of array of characters', () => {
            let someString = new StringBuilder('Pesho');
            someString.prepend('123');

            let actual = someString._stringArray;
            let expected = ['1', '2', '3', 'P', 'e', 's', 'h', 'o'];

            for (let i = 0; i < actual.length; i++) {
                assert.isTrue(actual[i] === expected[i]);
            }
        });

        it('When call prepend with empty string should\'t be added to start of array of characters', () => {
            let someString = new StringBuilder('Pesho');
            someString.prepend('');

            let actual = someString._stringArray;
            let expected = ['P', 'e', 's', 'h', 'o'];

            for (let i = 0; i < actual.length; i++) {
                assert.isTrue(actual[i] === expected[i]);
            }
        });

        it('When call prepend with invalid non-string argument should throw an exception', () => {
            let someString = new StringBuilder('Pesho');

            assert.Throw(() => someString.prepend(12131), 'Argument must be a string');
            assert.Throw(() => someString.prepend(12131.20), 'Argument must be a string');
            assert.Throw(() => someString.prepend(-12131), 'Argument must be a string');
            assert.Throw(() => someString.prepend(-12131.20), 'Argument must be a string');
            assert.Throw(() => someString.prepend(0), 'Argument must be a string');
            assert.Throw(() => someString.prepend([]), 'Argument must be a string');
            assert.Throw(() => someString.prepend([1, 2, 3]), 'Argument must be a string');
            assert.Throw(() => someString.prepend(['1', '2', '3']), 'Argument must be a string');
            assert.Throw(() => someString.prepend([false, false, true]), 'Argument must be a string');
            assert.Throw(() => someString.prepend([{}, {}, {}]), 'Argument must be a string');
            assert.Throw(() => someString.prepend([function() {}, function() {}, function() {}]), 'Argument must be a string');
            assert.Throw(() => someString.prepend({}), 'Argument must be a string');
            assert.Throw(() => someString.prepend({name: 'alalbala', number: 12}), 'Argument must be a string');
            assert.Throw(() => someString.prepend(function() {}), 'Argument must be a string');
            assert.Throw(() => someString.prepend(null), 'Argument must be a string');
            assert.Throw(() => someString.prepend(NaN), 'Argument must be a string');
        });
    });

    describe('Function insertAt tests', () => {

        it('When call insert add with string should be inserted to array of characters', () => {
            let someString = new StringBuilder('Pesho');
            someString.insertAt('123', 1);

            let actual = someString._stringArray;
            let expected = ['P', '1', '2', '3', 'e', 's', 'h', 'o'];

            for (let i = 0; i < actual.length; i++) {
                assert.isTrue(actual[i] === expected[i]);
            }
        });

        it('When call insert add with empty string should\'t be inserted to array of characters', () => {
            let someString = new StringBuilder('Pesho');
            someString.insertAt('', 1);

            let actual = someString._stringArray;
            let expected = ['P', 'e', 's', 'h', 'o'];

            for (let i = 0; i < actual.length; i++) {
                assert.isTrue(actual[i] === expected[i]);
            }
        });

        it('When call insert with invalid non-string argument should throw an exception', () => {
            let someString = new StringBuilder('Pesho');

            assert.Throw(() => someString.insertAt(12131, 1), 'Argument must be a string');
            assert.Throw(() => someString.insertAt(12131.20, 1), 'Argument must be a string');
            assert.Throw(() => someString.insertAt(-12131, 1), 'Argument must be a string');
            assert.Throw(() => someString.insertAt(-12131.20, 1), 'Argument must be a string');
            assert.Throw(() => someString.insertAt(0, 1), 'Argument must be a string');
            assert.Throw(() => someString.insertAt([], 1), 'Argument must be a string');
            assert.Throw(() => someString.insertAt([1, 2, 3], 1), 'Argument must be a string');
            assert.Throw(() => someString.insertAt(['1', '2', '3'], 1), 'Argument must be a string');
            assert.Throw(() => someString.insertAt([false, false, true], 1), 'Argument must be a string');
            assert.Throw(() => someString.insertAt([{}, {}, {}], 1), 'Argument must be a string');
            assert.Throw(() => someString.insertAt([function() {}, function() {}, function() {}, 1]), 'Argument must be a string');
            assert.Throw(() => someString.insertAt({}, 1), 'Argument must be a string');
            assert.Throw(() => someString.insertAt({name: 'alalbala', number: 12}, 1), 'Argument must be a string');
            assert.Throw(() => someString.insertAt(function() {}, 1), 'Argument must be a string');
            assert.Throw(() => someString.insertAt(null, 1), 'Argument must be a string');
            assert.Throw(() => someString.insertAt(NaN, 1), 'Argument must be a string');
        });
    });

    describe('Function remove tests', () => {

        it('When call remove should remove chracter from startIndex with length', () => {
            let someString = new StringBuilder('Pesho');
            someString.remove(0, 1);

            let actual = someString._stringArray;
            let expected = ['e', 's', 'h', 'o'];

            for (let i = 0; i < actual.length; i++) {
                assert.isTrue(actual[i] === expected[i]);
            }
        });

        it('When call remove should remove chracter from startIndex with length', () => {
            let someString = new StringBuilder('Pesho');
            someString.remove(someString._stringArray.length - 1, 1);

            let actual = someString._stringArray;
            let expected = ['P', 'e', 's', 'h'];

            for (let i = 0; i < actual.length; i++) {
                assert.isTrue(actual[i] === expected[i]);
            }
        });
    });

    describe('Function toString tests', () => {

        it('When call toString should return a string with all join chracters from back field', () => {
            let someString = new StringBuilder('Pesho');

            assert.equal(someString.toString(), 'Pesho');
        });
    });
});