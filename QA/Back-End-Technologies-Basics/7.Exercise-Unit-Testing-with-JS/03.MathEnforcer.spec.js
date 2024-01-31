import {mathEnforcer} from "./MathEnforcer.js"
import { expect } from "chai"

describe ("mathEnforcer",  () => {
    describe ('addFive',  () => {
        it('should return undefined when pass string as input ',  () => {
           const stringInput = "someString";
           const undefinedResult = mathEnforcer.addFive(stringInput);
           expect(undefinedResult).to.be.undefined;
        })
        it('should return undefined when pass undefined as input ',  () => {
            const undefinedInput = undefined;
            const undefinedResult = mathEnforcer.addFive(undefinedInput);
            expect(undefinedResult).to.be.undefined;
         })
         it('should return undefined when pass number as string as input ',  () => {
            const undefinedInput = "5";
            const undefinedResult = mathEnforcer.addFive(undefinedInput);
            expect(undefinedResult).to.be.undefined;
         })
         it('should return actual result if we input a number ',  () => {
            const undefinedInput = 10;
            const undefinedResult = mathEnforcer.addFive(undefinedInput);
            expect(undefinedResult).to.equals(15);
         })
         it('should return actual result if we input a fraction ',  () => {
            const undefinedInput = 10.10;
            const undefinedResult = mathEnforcer.addFive(undefinedInput);
            expect(undefinedResult).to.equals(15.10);
         })
         it('should return actual result if we input a negative number ',  () => {
            const undefinedInput = -10;
            const undefinedResult = mathEnforcer.addFive(undefinedInput);
            expect(undefinedResult).to.equals(-5);
         })
         it('should return actual result if we input a 0 ',  () => {
            const undefinedInput = 0;
            const undefinedResult = mathEnforcer.addFive(undefinedInput);
            expect(undefinedResult).to.equals(5);
         })
    })

    describe("subtractTen" ,  () => {

        it('should return undefined when pass string as input',  () => {
            const undefinedInput = "someString";
            const undefinedResult = mathEnforcer.subtractTen(undefinedInput);
            expect(undefinedResult).to.equals(undefined);
         })
         it('should return undefined when pass undefined as input',  () => {
            const undefinedInput = undefined;
            const undefinedResult = mathEnforcer.subtractTen(undefinedInput);
            expect(undefinedResult).to.equals(undefined);
         })
         it('should return undefined when pass number as string as input ',  () => {
            const undefinedInput = "6";
            const undefinedResult = mathEnforcer.subtractTen(undefinedInput);
            expect(undefinedResult).to.be.undefined;
         })
         it('should return actual result if we input a number ',  () => {
            const undefinedInput = 10;
            const undefinedResult = mathEnforcer.subtractTen(undefinedInput);
            expect(undefinedResult).to.equals(0);
         })
         it('should return actual result if we input a fraction ',  () => {
            const undefinedInput = 20.20;
            const undefinedResult = mathEnforcer.subtractTen(undefinedInput);
            expect(undefinedResult).to.equals(10.20);
         })
         it('should return actual result if we input a negative number ',  () => {
            const undefinedInput = -30;
            const undefinedResult = mathEnforcer.subtractTen(undefinedInput);
            expect(undefinedResult).to.equals(-40);
         })
         it('should return actual result if we input a 0 ',  () => {
            const input = 0;
            const result = mathEnforcer.subtractTen(input);
            expect(result).to.equals(-10);
         })
         

    })
    describe("sum" , () => {
        it('shold return actual result if inputs are bouth numbers', () => {
            const num1 = 2;
            const num2 = 3;
            const result = mathEnforcer.sum(num1, num2);
            expect(result).to.equals(5);

        })
        it('should return undefined if one input is a string', () =>{
            const num1 = 5;
            const num2 ='3';
            const result = mathEnforcer.sum(num1, num2);
            expect(result).to.equals(undefined);
        })
        it('should return undefined if bouth is a string', () =>  {
            const num1 = '4';
            const num2 = '6';
            const result = mathEnforcer.sum(num1, num2);
            expect(result).to.equals(undefined);
        })
        it('should return undefined if one number is undefined other string', () =>  {
            const num1 = undefined;
            const num2 = '6';
            const result = mathEnforcer.sum(num1, num2);
            expect(result).to.equals(undefined);


        })
        it('should return undefined if bouth is undefined', () =>  {
            const num1 = undefined;
            const num2 = undefined;
            const result = mathEnforcer.sum(num1, num2);
            expect(result).to.equals(undefined);


        })
        it('should return actual result if we input a fraction', () =>  {
            const num1 = 10.10;
            const num2 = 10;
            const result = mathEnforcer.sum(num1, num2);
            expect(result).to.equals(20.10);


        })
        it('should return actual result if bouth inputs is a fraction', () =>  {
            const num1 = 5.5;
            const num2 = 5.5;
            const result = mathEnforcer.sum(num1, num2);
            expect(result).to.equals(11);


        })
        it('should return the actual result if one is a negative number and the other is a normal number ', () =>  {
            const num1 = 1;
            const num2 = -3;
            const result = mathEnforcer.sum(num1, num2);
            expect(result).to.equals(-2);


        })
        it(' should return the real result if one is a negative fractional number and the other is a normal fractional number ', () =>  {
            const num1 = -1.2;
            const num2 = 3.2;
            const result = mathEnforcer.sum(num1, num2);
            expect(result).to.equals(2);


        })
        it(' should return the real result if it is only one number  ', () =>  {
            const num1 = 1;
            const result = mathEnforcer.sum(num1);
            expect(result).to.equals(undefined);


        })
        it(' should return three numbers ', () =>  {
            const num1 = 2;
            const num2 = 2;
            const num3 = 2;
            const result = mathEnforcer.sum(num1, num2, num3);
            expect(result).to.equals(4);


        })
        
        
    })

    
})



