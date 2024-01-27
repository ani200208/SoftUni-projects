function sortNumbers(arr) {
    arr.sort((a, b) => a - b);  

    let result = [];
    let left = 0;
    let right = arr.length - 1;

    while (left <= right) {
        if (left !== right) {
            result.push(arr[left]);
            result.push(arr[right]);
        } else {
            result.push(arr[left]);
        }

        left++;
        right--;
    }

    return result;
}


let inputArray = [1, 65, 3, 52, 48, 63, 31, -3, 18, 56];
let resultArray = sortNumbers(inputArray);

console.log(resultArray);
