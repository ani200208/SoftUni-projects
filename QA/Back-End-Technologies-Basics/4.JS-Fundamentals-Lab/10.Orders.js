function solve(product, quantity){

    if (product === "coffee"){
        console.log((quantity * 1.5).toFixed(2));
    }
    else if(product === "water"){
        console.log((quantity * 1.00).toFixed(2));
    }
    else if(product === "coke"){
        console.log((quantity * 1.40).toFixed(2));
    }
    else if(product === "snacks"){
        console.log((quantity * 2.00).toFixed(2));
    }

  
}

solve("water", 5);
solve("coffee", 2);