import {analyzeArray} from "./ArrayAnalyzer.js"
import { expect } from "chai"

describe ("analyzeArray",  () => {

    it('should return undefined if array length equals to zero' , () => {
        const input = [];
        const result = analyzeArray(input);
        expect(result).to.deep.equal(undefined);
    })
    it('should return undefined if equals to a number ' , () => {
        const input = 10;
        const result = analyzeArray(input);
        expect(result).to.deep.equal(undefined);
    })
    it('should return undefined if input is an empty array ' , () => {
        const input =  [];
        const result = analyzeArray(input);
        expect(result).to.deep.equal(undefined);
    })
    it('should return answer if it is an array of two numbers ' , () => {
        const input = [10, 2];
        const result = analyzeArray(input);
        expect(result).to.deep.equal({ min: 2, max: 10, length: 2 });
    })
    it('should return answer if it is array of three numbers ' , () => {
        const input = [10, 3, 5];
        const result = analyzeArray(input);
        expect(result).to.deep.equal({ min: 3, max: 10, length: 3 });
    })
    it('should return answer if it is array of 10 numbers, positive & negative, int, & double ' , () => {
        const input = [10, -3, 5, -1.00065, -456.01, 7809.1, 0, 69, -69, 420.69];
        const result = analyzeArray(input);
        expect(result).to.deep.equal({ min: -456.01, max: 7809.1, length: 10 });
    })
    it('should return undefined if input is an array of numbers, some as strings ' , () => {
        const input = [10, '3', 5];
        const result = analyzeArray(input);
        expect(result).to.deep.equal(undefined);
    })
    it('should return undefined if input is an array of numbers and strings ' , () => {
        const input = [10, 'string', 5];
        const result = analyzeArray(input);
        expect(result).to.deep.equal(undefined);
    })
    it('should return undefined if input is undefined ' , () => {
        const input = undefined;
        const result = analyzeArray(input);
        expect(result).to.deep.equal(undefined);
    })
    it('should return undefined if input is an array of undefined ' , () => {
        const input = [undefined];
        const result = analyzeArray(input);
        expect(result).to.deep.equal(undefined);
    })
    it('should return undefined if input is an array of bool ' , () => {
        const input = [true, false, true];
        const result = analyzeArray(input);
        expect(result).to.deep.equal(undefined);
    })
    it('should return undefined if input is an array of NaN and numbers ' , () => {
        const input = [NaN, 25, 0];
        const result = analyzeArray(input);
        expect(result).to.deep.equal({ min: NaN, max: NaN, length: 3 });
    })
    it('should return undefined if input is a non-array input ' , () => {
        const input =  'string';
        const result = analyzeArray(input);
        expect(result).to.deep.equal(undefined);
    })
})