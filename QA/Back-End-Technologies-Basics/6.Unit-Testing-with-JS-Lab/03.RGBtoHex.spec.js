
import { rgbToHexColor } from './RGBtoHex.js'
import { expect } from 'chai'

describe('The function rgbToHexColor', () =>{

    

it ('should return undefined if red value is invalid', () =>{
    
    const nonNumericRedValueResult = rgbToHexColor ('123', 0, 0);
    const negativeRedValueResult = rgbToHexColor(-123, 0, 0);
    const tooBigRedValue = rgbToHexColor(999, 0, 0);
    expect(nonNumericRedValueResult).to.be.undefined;
    expect(negativeRedValueResult).to.be.undefined
    expect(tooBigRedValue).to.be.undefined

})

it('should return undefined if green value is invalid', () => {

    const nonNumericGreenValueResult = rgbToHexColor (0, '123', 0);
    const negativeGreenValueResult = rgbToHexColor(0, '123', 0);
    const tooBigGreenValue = rgbToHexColor(0, 999, 0);
    expect(nonNumericGreenValueResult).to.be.undefined;
    expect(negativeGreenValueResult).to.be.undefined
    expect(tooBigGreenValue).to.be.undefined


})
it('should return undefined if blue value is invalid', () =>{

    const nonNumericBlueValueResult = rgbToHexColor (0, 0, '123');
    const negativeBlueValueResult = rgbToHexColor(0, 0, '123');
    const tooBigBlueValue = rgbToHexColor(0, 0, 999);
    expect(nonNumericBlueValueResult).to.be.undefined;
    expect(negativeBlueValueResult).to.be.undefined
    expect(tooBigBlueValue).to.be.undefined


})
it('it should return a correct hex value if a correct rgb is given', () =>{

    const redValue = 223;
    const blueValue = 123;
    const greenValue = 12;
    const result = rgbToHexColor (redValue, blueValue, greenValue);
    expect(result).to.be.equals('#DF7B0C')

})
it('it should return a correct hex value if a max rgb value is given', () =>{

    const redValue = 255;
    const blueValue = 255;
    const greenValue = 255;
    const result = rgbToHexColor (redValue, blueValue, greenValue);
    expect(result).to.be.equals('#FFFFFF')

})
it('it should return a correct hex value if a min rgb value is given', () =>{

    const redValue = 0;
    const blueValue = 0;
    const greenValue = 0;
    const result = rgbToHexColor (redValue, blueValue, greenValue);
    expect(result).to.be.equals('#000000')

})

})
