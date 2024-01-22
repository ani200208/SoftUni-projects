function solve(stnumber, ennumber){
    let message = '';
    let sum = 0;

   
    for(let index = stnumber; index <= ennumber; index += 1){
        sum += index;
        message += 
        ` ${index}` 
    }

    console.log(message.trimEnd());
    console.log(`Sum: ${sum}`);
}

solve(5, 10);
solve(0, 26);
solve(50, 60);
