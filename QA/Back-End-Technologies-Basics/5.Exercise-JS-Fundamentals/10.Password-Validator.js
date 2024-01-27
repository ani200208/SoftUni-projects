function validatePassword(password) {
    let isValid = true;
    let digitsCount = 0;

    if (password.length < 6 || password.length > 10) {
        console.log("Password must be between 6 and 10 characters");
        isValid = false;
    }

    for (let char of password) {
        if (!(/[a-zA-Z0-9]/).test(char)) {
            console.log("Password must consist only of letters and digits");
            isValid = false;
            break;
        }

        if (/[0-9]/.test(char)) {
            digitsCount++;
        }
    }

    if (digitsCount < 2) {
        console.log("Password must have at least 2 digits");
        isValid = false;
    }

    if (isValid) {
        console.log("Password is valid");
    }
}


validatePassword('logIn');  
validatePassword('MyPass123');  
validatePassword('Pa$s$s');  
