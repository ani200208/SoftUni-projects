
function personInfo(firstName, lastName, age) {
    let person = {
        firstName: firstName,
        lastName: lastName,
        age: Number(age)
    };

    
    console.log(`firstName: ${person.firstName}`);
    console.log(`lastName: ${person.lastName}`);
    console.log(`age: ${person.age}`);
}


personInfo("Peter", "Pan", "20");
personInfo("George", "Smith", "18");
