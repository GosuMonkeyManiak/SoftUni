const PaymentPackage = require('./paymentPackage');
const assert = require('chai').assert;

describe('Payment Package Tests', () => {

    describe('Tests for name', () => {

        it('When create new instance should set name from constructor and have back field for name and getter', () => {
            let nameInstaceTest = new PaymentPackage('bike', 120);

            assert.isTrue(nameInstaceTest.hasOwnProperty('_name'));
            assert.equal(nameInstaceTest.name, 'bike');
            assert.equal(nameInstaceTest._name, 'bike');
        });

        it('When create new instance should have setter for name', () => {
            let nameInstaceTest = new PaymentPackage('bike', 120);

            nameInstaceTest.name = 'car';
            assert.equal(nameInstaceTest.name, 'car');
            assert.equal(nameInstaceTest._name, 'car');
        });

        it('When create new instance with invalid name should throw an exception', () => {
            assert.Throw(() => new PaymentPackage(1231231, 1231), 'Name must be a non-empty string');
            assert.Throw(() => new PaymentPackage([], 1231), 'Name must be a non-empty string');
            assert.Throw(() => new PaymentPackage([1 ,2, 3], 1231), 'Name must be a non-empty string');
            assert.Throw(() => new PaymentPackage(['1', '2', '3'], 1231), 'Name must be a non-empty string');
            assert.Throw(() => new PaymentPackage([{}, {}, {}], 1231), 'Name must be a non-empty string');
            assert.Throw(() => new PaymentPackage([true, false, false], 1231), 'Name must be a non-empty string');
            assert.Throw(() => new PaymentPackage({name: 'Peter', age: 12}, 1231), 'Name must be a non-empty string');
            assert.Throw(() => new PaymentPackage(function() {}, 1231), 'Name must be a non-empty string');
            assert.Throw(() => new PaymentPackage(true, 1231), 'Name must be a non-empty string');
            assert.Throw(() => new PaymentPackage(3.14, 1231), 'Name must be a non-empty string');
            assert.Throw(() => new PaymentPackage('', 1231), 'Name must be a non-empty string');
            assert.Throw(() => new PaymentPackage(0, 1231), 'Name must be a non-empty string');
            assert.Throw(() => new PaymentPackage(-120, 1231), 'Name must be a non-empty string');
            assert.Throw(() => new PaymentPackage(-120.20, 1231), 'Name must be a non-empty string');
        });
    });

    describe('Test for value', () => {

         it('When create new instance should set value from constructor and have back filed for value and getter', () => {
            let valueInstacenTest = new PaymentPackage('bike', 120);

            assert.isTrue(valueInstacenTest.hasOwnProperty('_value'));
            assert.equal(valueInstacenTest.value, 120);
            assert.equal(valueInstacenTest._value, 120);
        });

        it('When create new instance should have setter for value', () => {
            let valueInstacenTest = new PaymentPackage('bike', 120);

            valueInstacenTest.value = 0;
            assert.equal(valueInstacenTest.value, 0);
            assert.equal(valueInstacenTest._value, 0);

            valueInstacenTest.value = 360;
            assert.equal(valueInstacenTest.value, 360);
            assert.equal(valueInstacenTest._value, 360);
        });

        it('When create new instance with invalid value should throw an exception', () => {
            assert.Throw(() => new PaymentPackage('car', -1231), 'Value must be a non-negative number');
            assert.Throw(() => new PaymentPackage('car', -1231.20), 'Value must be a non-negative number');
            assert.Throw(() => new PaymentPackage('car', ''), 'Value must be a non-negative number');
            assert.Throw(() => new PaymentPackage('car', '-120'), 'Value must be a non-negative number');
            assert.Throw(() => new PaymentPackage('car', '-120.20'), 'Value must be a non-negative number');
            assert.Throw(() => new PaymentPackage('car', []), 'Value must be a non-negative number');
            assert.Throw(() => new PaymentPackage('car', [1, 2, 3]), 'Value must be a non-negative number');
            assert.Throw(() => new PaymentPackage('car', ['1', '2', '3']), 'Value must be a non-negative number');
            assert.Throw(() => new PaymentPackage('car', [true, false, true]), 'Value must be a non-negative number');
            assert.Throw(() => new PaymentPackage('car', [{}, {}, {}]), 'Value must be a non-negative number');
            assert.Throw(() => new PaymentPackage('car', {name: 'Dimitar', age: 18}), 'Value must be a non-negative number');
            assert.Throw(() => new PaymentPackage('car', function() {}), 'Value must be a non-negative number');
            assert.Throw(() => new PaymentPackage('car', false), 'Value must be a non-negative number');
        });
    });

    describe('Tests for vat', () => {

        it('When create new instace should have VAT back field, getter and default value', () => {
            let vatInstanceTest = new PaymentPackage('bike', 120);

            assert.isTrue(vatInstanceTest.hasOwnProperty('_VAT'));
            assert.equal(vatInstanceTest.VAT, 20);
            assert.equal(vatInstanceTest._VAT, 20);
        });

        it('When create new instace should have setter for VAT', () => {
            let vatInstanceTest = new PaymentPackage('bike', 120);

            vatInstanceTest.VAT = 50;
            assert.equal(vatInstanceTest.VAT, 50);
            assert.equal(vatInstanceTest._VAT, 50);

            vatInstanceTest.VAT = 0;
            assert.equal(vatInstanceTest.VAT, 0);
            assert.equal(vatInstanceTest._VAT, 0);
        });

        it('When try to change VAT with invalid value should throw an exception', () => {
            let vatInstanceTest = new PaymentPackage('bike', 120);

            assert.throw(() => vatInstanceTest.VAT = -120, 'VAT must be a non-negative number');
            assert.throw(() => vatInstanceTest.VAT = -120.20, 'VAT must be a non-negative number');
            assert.throw(() => vatInstanceTest.VAT = [], 'VAT must be a non-negative number');
            assert.throw(() => vatInstanceTest.VAT = [1, 2, 3], 'VAT must be a non-negative number');
            assert.throw(() => vatInstanceTest.VAT = ['1', '2', '3'], 'VAT must be a non-negative number');
            assert.throw(() => vatInstanceTest.VAT = [true, false, true], 'VAT must be a non-negative number');
            assert.throw(() => vatInstanceTest.VAT = [{}, {}, {}], 'VAT must be a non-negative number');
            assert.throw(() => vatInstanceTest.VAT = {}, 'VAT must be a non-negative number');
            assert.throw(() => vatInstanceTest.VAT = {name: 'dasda', number: '123'}, 'VAT must be a non-negative number');
            assert.throw(() => vatInstanceTest.VAT = function() {}, 'VAT must be a non-negative number');
            assert.throw(() => vatInstanceTest.VAT = '', 'VAT must be a non-negative number');
            assert.throw(() => vatInstanceTest.VAT = '-120', 'VAT must be a non-negative number');
            assert.throw(() => vatInstanceTest.VAT = '-120.20', 'VAT must be a non-negative number');
            assert.throw(() => vatInstanceTest.VAT = '120.20', 'VAT must be a non-negative number');
            assert.throw(() => vatInstanceTest.VAT = '120', 'VAT must be a non-negative number');
            assert.throw(() => vatInstanceTest.VAT = true, 'VAT must be a non-negative number');
        });
    });

    describe('Tests for active', () => {
        const activeInstanceTest = new PaymentPackage('bike', 120);

        it('When create new instace should have active back field, getter and default value', () => {
            assert.isTrue(activeInstanceTest.hasOwnProperty('_active'));
            assert.isTrue(activeInstanceTest.active);
            assert.isTrue(activeInstanceTest._active);
        });

        it('When create new instace should have setter for active field', () => {
            activeInstanceTest.active = false;
            assert.equal(activeInstanceTest.active, false);
            assert.equal(activeInstanceTest._active, false);
        });

        it('When try to change active with invalid value should throw an exception', () => {
            assert.Throw(() => activeInstanceTest.active = 1, 'Active status must be a boolean');
            assert.Throw(() => activeInstanceTest.active = 1.20, 'Active status must be a boolean');
            assert.Throw(() => activeInstanceTest.active = -120, 'Active status must be a boolean');
            assert.Throw(() => activeInstanceTest.active = -355.10, 'Active status must be a boolean');
            assert.Throw(() => activeInstanceTest.active = '', 'Active status must be a boolean');
            assert.Throw(() => activeInstanceTest.active = '420', 'Active status must be a boolean');
            assert.Throw(() => activeInstanceTest.active = '560.20', 'Active status must be a boolean');
            assert.Throw(() => activeInstanceTest.active = '-70', 'Active status must be a boolean');
            assert.Throw(() => activeInstanceTest.active = '-90.09', 'Active status must be a boolean');
            assert.Throw(() => activeInstanceTest.active = [], 'Active status must be a boolean');
            assert.Throw(() => activeInstanceTest.active = [1, 2, 3], 'Active status must be a boolean');
            assert.Throw(() => activeInstanceTest.active = ['1', '2', '3'], 'Active status must be a boolean');
            assert.Throw(() => activeInstanceTest.active = [true, false, false], 'Active status must be a boolean');
            assert.Throw(() => activeInstanceTest.active = [{}, {}, {}], 'Active status must be a boolean');
            assert.Throw(() => activeInstanceTest.active = {}, 'Active status must be a boolean');
            assert.Throw(() => activeInstanceTest.active = {number: 123}, 'Active status must be a boolean');
            assert.Throw(() => activeInstanceTest.active = function() {}, 'Active status must be a boolean');
        });
    });

    describe('Test for toString', () => {

        it('When invoke toString() while active is true should return string with information for package', () => {
            let package = new PaymentPackage('car', 1200);

            let expected = 'Package: car\n';
            expected += '- Value (excl. VAT): 1200\n';
            expected += '- Value (VAT 20%): 1440';
            assert.equal(package.toString(), expected);
        });

        it('When invoke toString() while active is false should return string with information for package', () => {
            let package = new PaymentPackage('car', 1200);

            let expected = 'Package: car (inactive)\n';
            expected += '- Value (excl. VAT): 1200\n';
            expected += '- Value (VAT 20%): 1440';
            package.active = false;
            assert.equal(package.toString(), expected);
        });

        it('When change vat result should be valid for active package', () => {
            let package = new PaymentPackage('car', 1200);
            package.VAT = 0;

            let expected = 'Package: car\n';
            expected += '- Value (excl. VAT): 1200\n';
            expected += '- Value (VAT 0%): 1200';

            assert.equal(package.toString(), expected);
        });

        it('When change vat result should be valid for inactive package', () => {
            let package = new PaymentPackage('car', 1200);
            package.VAT = 0;
            package.active = false;

            let expected = 'Package: car (inactive)\n';
            expected += '- Value (excl. VAT): 1200\n';
            expected += '- Value (VAT 0%): 1200';

            assert.equal(package.toString(), expected);
        });

        it('When vat is 10% should return valid result', () => {
            let package = new PaymentPackage('car', 1200);
            package.VAT = 10;

            let expected = 'Package: car\n';
            expected += '- Value (excl. VAT): 1200\n';
            expected += '- Value (VAT 10%): 1320';

            assert.equal(package.toString(), expected);
        });

        it('When vat is 100% should return valid result', () => {
            let package = new PaymentPackage('car', 1200);
            package.VAT = 100;

            let expected = 'Package: car\n';
            expected += '- Value (excl. VAT): 1200\n';
            expected += '- Value (VAT 100%): 2400';

            assert.equal(package.toString(), expected);
        });

        it('When vat is 30% should return valid result', () => {
            let package = new PaymentPackage('car', 123);
            package.VAT = 30;

            let expected = 'Package: car\n';
            expected += '- Value (excl. VAT): 123\n';
            expected += '- Value (VAT 30%): 159.9';

            assert.equal(package.toString(), expected);
        });
    });
});