// to get current year
function getYear() {
    var currentDate = new Date();
    var currentYear = currentDate.getFullYear();
    document.querySelector("#displayYear").innerHTML = currentYear;
}

getYear();

// nav menu
function openNav() {
    document.getElementById("myNav").classList.toggle("menu_width");
    document
        .querySelector(".custom_menu-btn")
        .classList.toggle("menu_btn-style");
} function validateRadioButtonList() {
    var radioButtonList = document.getElementById('<%= paymentTypeRadioButtonList.ClientID %>');
    var radioButtons = radioButtonList.getElementsByTagName('input');
    var isChecked = false;

    for (var i = 0; i < radioButtons.length; i++) {
        if (radioButtons[i].checked) {
            isChecked = true;
            break;
        }
    }

    if (!isChecked) {
        alert('Please select a payment option.');
        return false;
    }
    return true;
}

function onPlaceOrderButtonClick() {
    var isValid = validateRadioButtonList();
    if (isValid) {
        // Perform further actions or submit form
        return true;
    } else {
        return false;
    }
}