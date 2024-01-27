function printCityInfo(cityObject) {
    for (const key in cityObject) {
        console.log(`${key} -> ${cityObject[key]}`);
    }
}


const sofiaInfo = {
    name: "Sofia",
    area: 492,
    population: 1238438,
    country: "Bulgaria",
    postCode: "1000"
};

const plovdivInfo = {
    name: "Plovdiv",
    area: 389,
    population: 1162358,
    country: "Bulgaria",
    postCode: "4000"
};


console.log("Sofia Information:");
printCityInfo(sofiaInfo);

console.log("Plovdiv Information:");
printCityInfo(plovdivInfo);
