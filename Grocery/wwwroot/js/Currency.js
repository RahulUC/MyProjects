// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
// JAVASCRIPT CODE WILL GO HERE

// WHEN DOCUMENT READY
function isNumber(evt) {
    var iKeyCode = (evt.which) ? evt.which : evt.keyCode
    if (iKeyCode != 46 && iKeyCode > 31 && (iKeyCode < 48 || iKeyCode > 57)) {
        alert("Enter only numeric values !! ");
        return false;
    }

    return true;
}
function convertCurrency() {
    var from = document.getElementById("from").value;
    var to = document.getElementById("to").value;
    var xmlhttps = new XMLHttpRequest();
    var url = "https://data.fixer.io/api/latest?access_key=e989923b13543e675bfe8dbc6a233999&base=" + from + "&symbols=" + to;
    xmlhttps.open("GET", url, true);
    xmlhttps.send();
    xmlhttps.onreadystatechange = function () {
        if (xmlhttps.readyState == 4 && xmlhttps.status == 200) {
            var result = xmlhttps.responseText;
            var jsResult = JSON.parse(result);
            var oneUnit = jsResult.rates[to];
            var amt = document.getElementById("fromAmount").value;
            document.getElementById("toAmount").value = (oneUnit * amt).toFixed(2);

        }
    }

}