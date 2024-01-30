
import { isSymmetric } from './CheckforSymmetry.js'
import { expect } from 'chai'

describe('The function isSymmetric', () =>{

    

it ('if given an empty array should return true', () =>{
    
    const inputArray = [];
    const result = isSymmetric(inputArray);
    expect(result).to.be.true;

})

it('should return false if a non-array value is given', () => {

    const nanResult = isSymmetric(NaN)
    const UndefinedResult = isSymmetric(undefined)
    const objectResult = isSymmetric({})
    const nullResult = isSymmetric(null)
    expect (nanResult).to.be.false
    expect(UndefinedResult).to.be.false
    expect(objectResult).to.be.false
    expect(nullResult).to.be.false

})
it('should return false if a non-symmetric array is given', () =>{

    const nonSymetricArray = [1, 2, 3, 4]
    const result = isSymmetric(nonSymetricArray)
    expect(result).to.be.false

})
it('should return true if a symmetric array is given', () =>{

    const SymetricArray = [3, 2, 1, 2, 3]
    const result = isSymmetric(SymetricArray)
    expect(result).to.be.true
})
it('should return false for symmetric lookalike value', () =>{

    const SymetricArray = ['1', '2', '3', 2, 1]
    const result = isSymmetric(SymetricArray)
    expect(result).to.be.false
})

})
