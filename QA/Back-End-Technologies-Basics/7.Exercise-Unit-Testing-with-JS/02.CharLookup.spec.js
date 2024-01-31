import {lookupChar} from "./CharLookup.js"
import {expect} from 'chai'

describe ("lookupChar", () => {
    
    it("should return undefined when First parameter is from incorrect and second parameter is correct type", () => {

        const incorrectFirstParam = 123;
        const correctSecondParam = 1;
        const undefinedResult = lookupChar(incorrectFirstParam, correctSecondParam);
        expect(undefinedResult).to.be.undefined;


    })
    it("should return undefined when First parameter is from correct type and second parameter is with incorrect type", () => {

        const correctFirstParam  = "some string here";
        const incorrectSecondParam = "10";
        const undefinedResult = lookupChar(correctFirstParam, incorrectSecondParam);
        expect(undefinedResult).to.be.undefined;
        

    })
    it("should return undefined when First parameter is from correct type and second parameter is with correct float type", () => {

        const correctFirstParam   = "some string here";
        const incorrectFloatNumberSecondParam = 10.10;
        const undefinedResult = lookupChar(correctFirstParam, incorrectFloatNumberSecondParam);
        expect(undefinedResult).to.be.undefined;
        

    })
    it("should return incorrect index when First parameter is from correct type and second parameter is bigger than the string legth ", () => {

        const correctFirstParam   = "some string here";
        const biggerLegthSecondParam = 20;
        const incorectindexresult = lookupChar(correctFirstParam, biggerLegthSecondParam);
        expect(incorectindexresult).to.be.equal("Incorrect index");
        

    })
    it("should return incorrect index when First parameter is from correct type and second parameter is lower than the string legth ", () => {

        const correctFirstParam   = "some string here";
        const lowerLegthSecondParam = -20;
        const incorectindexresult = lookupChar(correctFirstParam, lowerLegthSecondParam);
        expect(incorectindexresult).to.be.equal("Incorrect index");
        

    })
    it("should return correct when all the parameters are correct ", () => {

        const correctFirstParam   = "some string here";
        const correctSecondParam = 1;
        const correctresult = lookupChar(correctFirstParam, correctSecondParam);
        expect(correctresult).to.be.equal("o");
        

    })
    
})