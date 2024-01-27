function generateEmployeeList(employees) {
    let employeeList = {};

    for (let employee of employees) {
        let name = employee;
        let personalNum = name.length;

        employeeList[name] = personalNum;
    }

    for (let [name, personalNum] of Object.entries(employeeList)) {
        console.log(`Name: ${name} -- Personal Number: ${personalNum}`);
    }
}

generateEmployeeList([
    'Silas Butler',
    'Adnaan Buckley',
    'Juan Peterson',
    'Brendan Villarreal'
]);

generateEmployeeList([
    'Samuel Jackson',
    'Will Smith',
    'Bruce Willis',
    'Tom Holland'
]);
