function solve(number){


    let totalSum = 0;
    let allDigitsAreTheSame = true;
    const firstDigit = number % 10;

    while(number > 0){
        const currentDigit = number % 10;
        if(firstDigit != currentDigit){
            allDigitsAreTheSame = false;
        }
        totalSum += currentDigit;
        number = Math.floor(number / 10);
    }
    console.log(allDigitsAreTheSame);
    console.log(totalSum);
}

solve(2222222);
solve(1234);