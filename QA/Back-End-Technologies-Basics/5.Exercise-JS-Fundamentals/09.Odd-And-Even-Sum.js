function oddAndEvenSum(number) {
    let numAsString = number.toString();
    let oddSum = 0;
    let evenSum = 0;

    for (let i = 0; i < numAsString.length; i++) {
        let currentDigit = Number(numAsString[i]);

        if (currentDigit % 2 === 0) {
            evenSum += currentDigit;
        } else {
            oddSum += currentDigit;
        }
    }

    console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
}


oddAndEvenSum(1000435);  
oddAndEvenSum(3495892137259234);  
