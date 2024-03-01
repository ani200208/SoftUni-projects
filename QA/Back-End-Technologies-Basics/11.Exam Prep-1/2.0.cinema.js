function cinema(input){
    const numberofmovies = parseInt(input[0], 10);
    const allmovies = input.slice(1, numberofmovies + 1);
    const allcommands = input.slice(numberofmovies + 1);
    
    for (let index = 0; index < allcommands.length; index++) {
        const command = allcommands[index].split(' ');

        if (command[0] === 'Sell') {
            const soldMovie = allmovies.shift();
            console.log(`${soldMovie} ticket sold!`);
        } else if (command[0] === 'Add') {
            const movieTitleToAdd = command.slice(1).join(' ');
            allmovies.push(movieTitleToAdd);
        } else if (command[0] === 'Swap') {
            const startIdx = parseInt(command[1], 10);
            const endIdx = parseInt(command[2], 10);

            if (startIdx >= 0 && startIdx < allmovies.length &&
                endIdx >= 0 && endIdx < allmovies.length) {
                const temp = allmovies[startIdx];
                allmovies[startIdx] = allmovies[endIdx];
                allmovies[endIdx] = temp;
                console.log("Swapped!");
            }
        } else if (command[0] === 'End') {
            break;
        }
    }

    if (allmovies.length > 0) {
        console.log(`Tickets left: ${allmovies.join(', ')}`);
    } else {
        console.log("The box office is empty");
    }
}

cinema(['3','Avatar', 'Titanic', 'Joker', 'Sell', 'End', 'Swap 0 1']);
cinema(['5', 'The Matrix', 'The Godfather', 'The Shawshank Redemption', 'The Dark Knight', 'Inception', 'Add The Lord of the Rings', 'Swap 1 4', 'End']);
cinema(['3', 'Star Wars', 'Harry Potter', 'The Hunger Games', 'Sell', 'Sell', 'Sell', 'End']);
