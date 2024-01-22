function solve(people,group,day){
    let totalAmount = 0;

    if(group === 'Students'){
        if(day === 'Friday'){
            totalAmount = people *  8.45;
        }
        else if(day === 'Saturday'){
            totalAmount = people * 9.80;
        }
        else if(day === 'Sunday'){
            totalAmount = people * 10.46;
        }
        if(people >= 30){
            totalAmount = totalAmount * 0.85;
        }

    }
    if(group === 'Business'){
        if(day === 'Friday'){
            totalAmount = people *  10.90;
        }
        else if(day === 'Saturday'){
            totalAmount = people * 15.60;
        }
        else if(day === 'Sunday'){
            totalAmount = people * 16;
        }
        if(people >= 10 && people <= 20){
            totalAmount = totalAmount * 0.95;
        }

    }
    if(group === 'Regular'){
        if(day === 'Friday'){
            totalAmount = people *  15;
        }
        else if(day === 'Saturday'){
            totalAmount = people * 20;
        }
        else if(day === 'Sunday'){
            totalAmount = people * 22.50;
        }
        if(people >= 100 ){
            const pricePerNight = totalAmount / people;
            totalAmount = pricePerNight * (people - 10);
        }

    }
    console.log(`Total price: ${totalAmount.toFixed(2)}`);
}

solve(30,
    "Students",
    "Sunday"
    )
solve(40,
    "Regular",
    "Saturday"
    )