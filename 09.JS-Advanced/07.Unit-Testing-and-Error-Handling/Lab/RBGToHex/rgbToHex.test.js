const rgbToHexColor = require('./rgbToHex');
const assert = require('chai').assert;

describe('RGBToHexColor Tests', () => {

    it('when pass valid parameter should return valid hex color', () => {
        assert.equal(rgbToHexColor(120, 17, 255), '#7811FF');
    });

    it('when pass valid lowest values should return valid hex color', () => {
        assert.equal(rgbToHexColor(0 , 0, 0), '#000000');
    });

    it('when pass valid highest values should return valid hex color', () => {
        assert.equal(rgbToHexColor(255 , 255, 255), '#FFFFFF');
    });

    it('when pass one parameter out of range should return undefined', () => {
        assert.isUndefined(rgbToHexColor(255 , 256, 255));
    });

    it('when pass positive invalid range parameters should return undefined', () => {
        assert.isUndefined(rgbToHexColor(-1000 , 256, 520));
    });

    it('when pass negative invalid range parameters should return undefined', () => {
        assert.isUndefined(rgbToHexColor(-1 , -220, -520));
    });

    it('when pass invalid types should return undefined', () => {
        assert.isUndefined(rgbToHexColor([] , [], []));
        assert.isUndefined(rgbToHexColor([1 ,2, 3] , [1, 2, 3], [1 ,2, 3]));
        assert.isUndefined(rgbToHexColor('' , '', ''));
        assert.isUndefined(rgbToHexColor('adsad' , '12312', '12312'));
        assert.isUndefined(rgbToHexColor({} , {}, {}));
    });
});