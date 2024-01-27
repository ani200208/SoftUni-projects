function printEveryNthElement(arr, step) {
    let result = [];  

    for (let i = 0; i < arr.length; i += step) {
        result.push(arr[i]);  
    }

    return result;  
}


let example1 = printEveryNthElement(['5', '20', '31', '4', '20'], 2);
console.log(example1);  

let example2 = printEveryNthElement(['dsa', 'asd', 'test', 'tset'], 2);
console.log(example2);  

let example3 = printEveryNthElement(['1', '2', '3', '4', '5'], 6);
console.log(example3);  