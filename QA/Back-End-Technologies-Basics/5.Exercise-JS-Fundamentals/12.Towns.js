function createTownObjects(input) {
    for (let row of input) {
        let [town, latitude, longitude] = row.split(' | ');

        latitude = Number(latitude).toFixed(2);
        longitude = Number(longitude).toFixed(2);

        let townObject = {
            town: town,
            latitude: latitude,
            longitude: longitude
        };

        console.log(townObject);
    }
}

let example1 = [
    'Sofia | 42.696552 | 23.32601',
    'Beijing | 39.913818 | 116.363625'
];

let example2 = [
    'Plovdiv | 136.45 | 812.575'
];

createTownObjects(example1);
createTownObjects(example2);
