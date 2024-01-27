function solve(n,input){
    let reverseArray = [];
    for (let i = 0; i < n; i++){
        reverseArray.unshift(input[i]);

    }
    
    console.log(reverseArray.join(" "));
}

solve(3, [10, 20, 30, 40, 50]);
solve(4, [-1, 20, 99, 5]);
solve(2, [66, 43, 75, 89, 47]);