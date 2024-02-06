function Num_Empty() {
    document.getElementById("NumTxt").innerHTML = "";
}
function Name_Empty() {
    document.getElementById("NameTxt").innerHTML = "";
}
function Date_Empty() {
    document.getElementById("DateTxt").innerHTML = "";
}
function Cvv_Empty() {
    document.getElementById("CvvTxt").innerHTML = "";
}
function Credit_Empty() {
    document.getElementById("AmtTxt").innerHTML = "";
}

function CreditTransactionValidate() {

    var num = document.getElementById("CreditNum").value;
    var name = document.getElementById("CreditName").value;
    var dob_ip = document.getElementById('CreditDate').value;
    var cvv = document.getElementById('CreditCvv').value;
    var amt = document.getElementById('CreditAmt').value;


    document.getElementById("CreditNum").addEventListener('input', Num_Empty);
    document.getElementById("CreditName").addEventListener('input', Name_Empty);
    document.getElementById("CreditDate").addEventListener('input', Date_Empty);
    document.getElementById("CreditCvv").addEventListener('input', Cvv_Empty);
    document.getElementById("CreditAmt").addEventListener('input', Credit_Empty);


    if (num == '' || num.length != 16) {
        document.getElementById("NumTxt").style.color = "red";
        document.getElementById("NumTxt").innerHTML = "Card Number length must be 16";
        return false;
    }

    var validName_ip = name.trim().replaceAll(" ", "");
    for (let i = 0; i < validName_ip.length; i++) {
        var name_code = validName_ip.charCodeAt(i);
        if (!(name_code >= 65 && name_code <= 90) && !(name_code >= 97 && name_code <= 122)) {
            document.getElementById('NameTxt').style.color = "red";
            document.getElementById('NameTxt').innerHTML = "Name must be alphabets";
            return false;
        }
    }

    if (name == '') {
        document.getElementById('NameTxt').style.color = "red";
        document.getElementById('NameTxt').innerHTML = "Name must not be empty";
        return false;
    }

    if (dob_ip == '') {
        document.getElementById('DateTxt').style.color = "red";
        document.getElementById('DateTxt').innerHTML = "Expiry Date must not be empty";
        return false;
    }

    if (cvv == '') {
        document.getElementById('CvvTxt').style.color = "red";
        document.getElementById('CvvTxt').innerHTML = "CVV must not be empty";
        return false;
    }

    if (amt == '' || (amt < 100&&amt>100000)) {
        document.getElementById('AmtTxt').style.color = "red";
        document.getElementById('AmtTxt').innerHTML = "Amount must not be empty and greater than 100";
        return false;
    }
    return true;
}