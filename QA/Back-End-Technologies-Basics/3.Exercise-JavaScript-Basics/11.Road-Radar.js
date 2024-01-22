function solve(speed, area) {
    let speedLimit = 0;

    if (area === 'motorway') {
        speedLimit = 130;
    } else if (area === 'interstate') {
        speedLimit = 90;
    } else if (area === 'city') {
        speedLimit = 50;
    } else if (area === 'residential') {
        speedLimit = 20;
    }

    const speedLimitDiffrence = speed - speedLimit;

    if (speedLimitDiffrence <= 0) {
        console.log(`Driving ${speed} km/h in a ${speedLimit} zone`);
    } else if (speedLimitDiffrence > 0 && speedLimitDiffrence <= 20) {
        console.log(`The speed is ${speedLimitDiffrence} km/h faster than the allowed speed of ${speedLimit} - speeding`);
    } else if (speedLimitDiffrence > 20 && speedLimitDiffrence <= 40) {
        console.log(`The speed is ${speedLimitDiffrence} km/h faster than the allowed speed of ${speedLimit} - excessive speeding`);
    } else {
        console.log(`The speed is ${speedLimitDiffrence} km/h faster than the allowed speed of ${speedLimit} - reckless driving`);
    }
}

solve(40, 'city');
solve(21, 'residential');
solve(120, 'interstate');
solve(200, 'motorway');

