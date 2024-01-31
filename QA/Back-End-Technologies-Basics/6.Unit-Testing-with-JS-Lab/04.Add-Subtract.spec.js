
import { createCalculator } from './Add-Subtract.js'
import { expect } from 'chai'

describe('The function createCalculator', () =>{

    

it ('should return 0 if no operation are executed on the calculator', () =>{
    
    const calculator = createCalculator ();
    const result = calculator.get();
    expect(result).to.equals(0);

})

it('should return a negative number if only substract operations are executed with positive numbers on the calculator ', () => {

    const calculator = createCalculator ('123', 0, 0);
    calculator.subtract(3)
    calculator.subtract(3)
    calculator.subtract(10)
    const result = calculator.get();
    expect(result).to.equals(-16);


})
it('should return a positive number if only add operations are executed with positive numbers on the calculator', () =>{

    const calculator = createCalculator ();
    calculator.add(2)
    calculator.add(2)
    calculator.add(100)
    const result = calculator.get();
    expect(result).to.equals(104);


})
it('it should handel number as strings', () =>{

    const calculator = createCalculator ();
    calculator.add('2')
    calculator.add('2')
    calculator.add('100')
    calculator.subtract('104')
    const result = calculator.get();
    expect(result).to.equals(0);

})
it('it should handle a mix of operations', () =>{

    const calculator = createCalculator ();
    calculator.add(2)
    calculator.add(2)
    calculator.add(100)
    calculator.add(-4)
    calculator.subtract(-100)
    calculator.subtract(200)
    const result = calculator.get();
    expect(result).to.equals(0);

})


})
