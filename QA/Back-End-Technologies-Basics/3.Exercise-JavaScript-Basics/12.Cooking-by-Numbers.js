function solve(raw, first, second, third, forth, fifth){

    let number  = parseInt(raw, 10);

    if (first === 'chop'){
        number = number / 2;
    }
    else if (first === 'dice'){
        number =Math.sqrt(number);
    }
    else if (first === 'spice'){
        number += 1;
    }
    else if ( first === 'bake'){
        number = number * 3;
    }
    else if (first === 'fillet'){
        number = number * 0.8;
    }
    console.log(number);

    if (second === 'chop'){
        number = number / 2;
    }
    else if (second === 'dice'){
        number =Math.sqrt(number);
    }
    else if (second === 'spice'){
        number += 1;
    }
    else if ( second === 'bake'){
        number = number * 3;
    }
    else if (second === 'fillet'){
        number = number * 0.8;
    }
    console.log(number);

    if (third === 'chop'){
        number = number / 2;
    }
    else if (third === 'dice'){
        number =Math.sqrt(number);
    }
    else if (third === 'spice'){
        number += 1;
    }
    else if ( third === 'bake'){
        number = number * 3;
    }
    else if (third === 'fillet'){
        number = number * 0.8;
    }
    console.log(number);

    if (forth === 'chop'){
        number = number / 2;
    }
    else if (forth === 'dice'){
        number =Math.sqrt(number);
    }
    else if (forth === 'spice'){
        number += 1;
    }
    else if ( forth === 'bake'){
        number = number * 3;
    }
    else if (forth === 'fillet'){
        number = number * 0.8;
    }
    console.log(number);

    if (fifth === 'chop'){
        number = number / 2;
    }
    else if (fifth === 'dice'){
        number =Math.sqrt(number);
    }
    else if (fifth === 'spice'){
        number += 1;
    }
    else if ( fifth === 'bake'){
        number = number * 3;
    }
    else if (fifth === 'fillet'){
        number = number * 0.8;
    }
    console.log(number);
}

solve('32', 'chop', 'chop', 'chop', 'chop', 'chop');
solve('9', 'dice', 'spice', 'chop', 'bake', 'fillet');
