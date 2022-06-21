const bookSelection = require('./bookSelection');
const assert = require('chai').assert;

describe('Book Selection Tests', () => {

    describe('isGenreSuitable tests', () => {

        it('when genre is Thriller or Horror and age is under 12 show return genre is not suitable', () => {
            assert.equal(bookSelection.isGenreSuitable('Thriller', 12), 'Books with Thriller genre are not suitable for kids at 12 age');
            assert.equal(bookSelection.isGenreSuitable('Thriller', 11), 'Books with Thriller genre are not suitable for kids at 11 age');
            assert.equal(bookSelection.isGenreSuitable('Thriller', 10), 'Books with Thriller genre are not suitable for kids at 10 age');

            assert.equal(bookSelection.isGenreSuitable('Horror', 12), 'Books with Horror genre are not suitable for kids at 12 age');
            assert.equal(bookSelection.isGenreSuitable('Horror', 11), 'Books with Horror genre are not suitable for kids at 11 age');
            assert.equal(bookSelection.isGenreSuitable('Horror', 10), 'Books with Horror genre are not suitable for kids at 10 age');
        });

        it('when pass diffrent from Thriller and Horror and age show get genre is suitable', () => {
            assert.equal(bookSelection.isGenreSuitable('Comedy', 12), 'Those books are suitable');
            assert.equal(bookSelection.isGenreSuitable('Drama', 11), 'Those books are suitable');
            assert.equal(bookSelection.isGenreSuitable('Action', 10), 'Those books are suitable');

             assert.equal(bookSelection.isGenreSuitable('Horror', 13), 'Those books are suitable');
             assert.equal(bookSelection.isGenreSuitable('Thriller', 13), 'Those books are suitable');
        });
    });

    describe('isItAffordable tests', () => {

        it('when don\'t have enough money return message for that', () => {
            assert.equal(bookSelection.isItAffordable(120, 10), 'You don\'t have enough money');
            assert.equal(bookSelection.isItAffordable(20, 10), 'You don\'t have enough money');
            assert.equal(bookSelection.isItAffordable(30, 10), 'You don\'t have enough money');
            assert.equal(bookSelection.isItAffordable(11, 10), 'You don\'t have enough money');
            assert.equal(bookSelection.isItAffordable(11.20, 10), 'You don\'t have enough money');
            assert.equal(bookSelection.isItAffordable(11.50, 10), 'You don\'t have enough money');
        });

        it('when have enough money return message how much money left', () => {
            assert.equal(bookSelection.isItAffordable(10, 120), 'Book bought. You have 110$ left');
            assert.equal(bookSelection.isItAffordable(10, 10), 'Book bought. You have 0$ left');
            assert.equal(bookSelection.isItAffordable(10, 30), 'Book bought. You have 20$ left');
            assert.equal(bookSelection.isItAffordable(10, 11), 'Book bought. You have 1$ left');
            assert.equal(bookSelection.isItAffordable(10.10, 11), `Book bought. You have ${11 - 10.10}$ left`);
        });

        it('when pass invalid price and budget throw a error', () => {
            assert.throw(() => bookSelection.isItAffordable('', ''), 'Invalid input');
            assert.throw(() => bookSelection.isItAffordable('1', '2'), 'Invalid input');
            assert.throw(() => bookSelection.isItAffordable([], []), 'Invalid input');
            assert.throw(() => bookSelection.isItAffordable({}, {}), 'Invalid input');
            assert.throw(() => bookSelection.isItAffordable(function () {}, function() {}), 'Invalid input');
        });
    });

    describe('suitableTitles tests', () => {

        it('when pass valid books and genre return array of books titles in that genre', () => {
            assert.deepEqual(bookSelection.suitableTitles(
            [{
                title: 'a',
                genre: 'a'
            }, {
                title: 'b',
                genre: 'a'
            }], 'a'), ['a', 'b']);

            assert.deepEqual(bookSelection.suitableTitles(
            [{
                title: 'a',
                genre: 'a'
            }, {
                title: 'b',
                genre: 'b'
            }], 'a'), ['a']);

             assert.deepEqual(bookSelection.suitableTitles(
            [{
                title: 'a',
                genre: 'b'
            }, {
                title: 'b',
                genre: 'b'
            }], 'a'), []);
        });
    });
});
