function addAndSubtract(num1, num2, num3) {
    function sum(a, b) {
        return a + b;
    }

    function subtract(result, c) {
        return result - c;
    }

    let resultSum = sum(num1, num2);
    let finalResult = subtract(resultSum, num3);

    console.log(finalResult);
}


addAndSubtract(23, 6, 10);  
addAndSubtract(1, 17, 30);  
addAndSubtract(42, 58, 100);  
