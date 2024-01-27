function solve(input){
    let uniqueNames = {};
    input.forEach(element => {
        let keyValuePair = element.split(" ");
        let key = keyValuePair[0];
        let value = keyValuePair [1];
        uniqueNames [key] = value;
        
    });

    for(let key in uniqueNames){
        console.log(`${key} -> ${uniqueNames[key]}`)
    }
}

solve(['Tim 0834212554',
'Peter 0877547887',
'Bill 0896543112',
'Tim 0876566344']
);

solve(['George 0552554',
'Peter 087587',
'George 0453112',
'Bill 0845344']
);