function processParking(input) {
    const parkingLot = new Set();
    const output = [];

    for (const entry of input) {
        const [direction, carNumber] = entry.split(', ');

        if (direction === 'IN') {
            parkingLot.add(carNumber);
        } else if (direction === 'OUT') {
            parkingLot.delete(carNumber);
        }
    }

    const sortedCars = Array.from(parkingLot).sort((a, b) => a.localeCompare(b));

    if (sortedCars.length > 0) {
        output.push(sortedCars.join('\n'));
    } else {
        output.push('Parking Lot is Empty');
    }

    console.log(output.join('\n'));
}




processParking([
    'IN, CA2844AA',
    'IN, CA1234TA',
    'OUT, CA2844AA',
    'IN, CA9999TT',
    'IN, CA2866HI',
    'OUT, CA1234TA',
    'IN, CA2844AA',
    'OUT, CA2866HI',
    'IN, CA9876HH',
    'IN, CA2822UU'
]);
processParking([
    'IN, CA2844AA',
    'IN, CA1234TA',
    'OUT, CA2844AA',
    'OUT, CA1234TA'
]);
