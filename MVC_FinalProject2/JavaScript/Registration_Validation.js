
function checkValidation() {
    Checkfirstname();
    Checklastname();
    Checkcontact();
    Checkemail();
    Checkgender();
    Checkaddress();
    Checkcity();
    Checkstate();
    Checkpincode();
    Checkusername();
    Checkpassword();
    Checkconfirmpassword();
}

//FIRSTNAME VALIDATION
function Checkfirstname() {
    var isName = /^[a-zA-Z]+$/;
    let fnameValue = document.getElementById("fname")
    if (fnameValue.value.trim() === "") {
        setErrorFor(fnameValue, "First name required");
    }
    else if (!isName.test(fnameValue.value.trim())) {
        setErrorFor(fnameValue,'Name cannot be a number or special characters');
    }
    else {
        setSuccessFor(fnameValue);
    }
}

//LASTNAME VALIDATION
function Checklastname() {
    var lName = /^[a-zA-Z]+$/;
    let lnameValue = document.getElementById("lname")
    if (lnameValue.value.trim() === "") {
        setErrorFor(lnameValue, "Last name required");
    }
    else if (!lName.test(lnameValue.value.trim())) {
        setErrorFor(lnameValue, 'Name cannot be a number or special characters');
    }
    else {
        setSuccessFor(lnameValue);
    }
}

//DATE OF BIRTH VALIDATION

function Checkdateofbirth() {
    let dobValue = document.getElementById("dob");
    let currentDate = new Date();
    let selectedDate = new Date(dobValue.value);

    if (dobValue.value.trim() === "") {
        setErrorFor(dobValue, 'Date of Birth required');
    } else if (isNaN(selectedDate)) {
        setErrorFor(dobValue, 'Invalid Date of Birth');
    } else {
        let age = calculateAge(selectedDate, currentDate);

        if (age < 18) {
            setErrorFor(dobValue, 'You must be at least 18 years old');
        } else {
            setSuccessFor(dobValue);
        }
    }
}

function calculateAge(birthDate, currentDate) {
    let age = currentDate.getFullYear() - birthDate.getFullYear();
    let months = currentDate.getMonth() - birthDate.getMonth();

    if (months < 0 || (months === 0 && currentDate.getDate() < birthDate.getDate())) {
        age--;
    }

    return age;
}


//PHONE NUMBER VALIDATION
function Checkcontact() {
    var isNumber = /^[0-9]+$/;
    let contactValue = document.getElementById("contact")
    if (contactValue.value.trim() === "") {
          setErrorFor(contactValue, 'Phonenumber required');
    }
    else if (!isNumber.test(contactValue.value.trim())) {
        setErrorFor(contactValue, 'Check your Phonenumber');
    }
    else {
        setSuccessFor(contactValue);
    }
}

//EMAIL VALIDATION
function Checkemail() {
    var isEmail = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
    let emailValue = document.getElementById("email")
    if (emailValue.value.trim() === "") {
        setErrorFor(emailValue, 'Email is required');
    }
    else if (!isEmail.test(emailValue.value.trim())) {
        setErrorFor(emailValue, 'Check your email Id');
    }
    else {
        setSuccessFor(emailValue);
    }
}

//GENDER VALIDATION

function Checkgender() {
    let radioButtons = document.querySelectorAll('.radio-button');
    let isChecked = false;

    for (let i = 0; i < radioButtons.length; i++) {
        if (radioButtons[i].checked) {
            isChecked = true;
            break;
        }
    }
    if (!isChecked) {
        setErrorFor(radioButtons[0], "Gender is required");
    } else {
        setSuccessFor(radioButtons[0]);
    }
}

//ADDRESS VALIDATION
function Checkaddress() {

    let addressValue = document.getElementById("address")
    if (addressValue.value.trim() === "") {
        setErrorFor(addressValue, "Address is required");
    }
    else {
        setSuccessFor(addressValue);
    }
}

//CITY VALIDATION
function Checkcity() {

    let cityValue = document.getElementById("city")
    if (cityValue.value.trim() === "") {
        setErrorFor(cityValue, "City is required");
    }
    else {
        setSuccessFor(cityValue);
    }
}

//STATE VALIDATION
function Checkstate() {

    let stateValue = document.getElementById("state")
    if (stateValue.value.trim() === "") {
        setErrorFor(stateValue, "State is required");
    }
    else {
        setSuccessFor(stateValue);
    }
}

//PINCODE VALIDATION
function Checkpincode() {
    var isNumber = /^[0-9]+$/;
    let pincodeValue = document.getElementById("pincode")
    if (pincodeValue.value.trim() === "") {
        setErrorFor(pincodeValue, 'Pincode required');
    }
    else if (!isNumber.test(pincodeValue.value.trim())) {
        setErrorFor(pincodeValue, 'Check your Pincode');
    }
    else {
        setSuccessFor(pincodeValue);
    }
}
//USERNAME VALIDATION
function Checkusername() {
    var isAlphanumeric = /^[a-zA-Z0-9]+$/;
    let usernameValue = document.getElementById("username");

    if (usernameValue.value.trim() === "") {
        setErrorFor(usernameValue, 'Username required');
    } else if (usernameValue.value.length < 5) {
        setErrorFor(usernameValue, 'Username must be at least 5 characters');
    } else if (!isAlphanumeric.test(usernameValue.value)) {
        setErrorFor(usernameValue, 'Username can only contain letters and numbers');
    } else {
        setSuccessFor(usernameValue);
    }
}

//PASSWORD VALIDATION

function Checkpassword() {
    let passwordValue = document.getElementById("password");

    if (passwordValue.value.trim() === "") {
        setErrorFor(passwordValue, 'Password required');
    } else if (passwordValue.value.length < 8) {
        setErrorFor(passwordValue, 'Password must be at least 8 characters');
    } else if (!containsUppercase(passwordValue.value)) {
        setErrorFor(passwordValue, 'Password must contain at least one uppercase letter');
    } else if (!containsLowercase(passwordValue.value)) {
        setErrorFor(passwordValue, 'Password must contain at least one lowercase letter');
    } else if (!containsNumber(passwordValue.value)) {
        setErrorFor(passwordValue, 'Password must contain at least one number');
    } else {
        setSuccessFor(passwordValue);
    }
}

function containsUppercase(str) {
    return /[A-Z]/.test(str);
}

function containsLowercase(str) {
    return /[a-z]/.test(str);
}

function containsNumber(str) {
    return /[0-9]/.test(str);
}

//CONFIRMPASSWOR VALIDATION

function Checkconfirmpassword() {
    let passwordValue = document.getElementById("password");
    let confirmPasswordValue = document.getElementById("confirmpassword");

    if (confirmPasswordValue.value.trim() === "") {
        setErrorFor(confirmPasswordValue, 'Confirm password required');
    } else if (confirmPasswordValue.value !== passwordValue.value) {
        setErrorFor(confirmPasswordValue, 'Passwords do not match');
    } else {
        setSuccessFor(confirmPasswordValue);
    }
}


    //SHOWING ERROR AND SUCCESS MESSAGE
    function setErrorFor(input, message) {
        const formControl = input.parentElement;
        const small = formControl.querySelector('small');
        small.classname = 'formerror';
        small.innerText = message;
    }

    function setSuccessFor(input){
        const formControl = input.parentElement;
        const small = formControl.querySelector('small');
        small.classname = 'formsuccess';
        small.innerHTML = "";
    }