function solve(listOfNames){
    listOfNames.sort((a, b)=> a.localeCompare(b))
    for (let index = 0; index < listOfNames.length; index +=1){
        console.log(`${index + 1}.${listOfNames[index]}`)
    }

}

solve(["John", "Bob", "Christina", "Ema"]);