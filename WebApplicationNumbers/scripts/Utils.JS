//
//
//
function SendNumber(strData) {
    const xhr = new XMLHttpRequest();

    xhr.onreadystatechange = function () {
        if (this.readyState == 4 /*request finished and response is ready*/ && this.status == 200) {
            // Typical action to be performed when the document is ready:
            //document.getElementById("demo").innerHTML = xhttp.responseText;
            alert(xhr.responseText);
        }
    }

    xhr.open("POST", "Home/AddNumber");
    xhr.setRequestHeader('Content-type', 'application/x-www-form-urlencoded'); // coding
    xhr.send("number=" + strData); // number is parameter name on controler action method
}

//
//
//
function ResetAll() {
    const xhr = new XMLHttpRequest();

    xhr.onreadystatechange = function () {
        if (this.readyState == 4 /*request finished and response is ready*/ && this.status == 200) {
            // Typical action to be performed when the document is ready:
            //document.getElementById("demo").innerHTML = xhttp.responseText;
            alert(xhr.responseText);
        }
    }

    xhr.open("POST", "Home/ResetAll");
    xhr.send(null);
}


//
//
//
function AddNumber() {
    const value = document.getElementById("fAdd").value;
    SendNumber(value);
}


//
//
//
function GetDataFromServer() {
    const xhr = new XMLHttpRequest();

    // Handle response from server
    xhr.onreadystatechange = function () {
        var allNumbers = document.getElementById('idAllNumbers');

        if (xhr.readyState < 4) {
            //allNumbers.innerHTML = "Loading...";
        }
        else if (xhr.readyState === 4) {
            if (xhr.status == 200 && xhr.status < 300) {
                allNumbers.innerHTML = xhr.responseText;
            }
        }
    }

    xhr.open('GET', 'Home/AllNumbers');
    xhr.send(null);
}


//
//
//
function GetDataFromServerUserNumbers() {
    const xhr = new XMLHttpRequest();

    // Handle response from server
    xhr.onreadystatechange = function () {
        var allNumbers = document.getElementById('idUserNumbers');

        if (xhr.readyState < 4) {
            //allNumbers.innerHTML = "Loading...";
        }
        else if (xhr.readyState === 4) {
            if (xhr.status == 200 && xhr.status < 300) {
                allNumbers.innerHTML = xhr.responseText;
            }
        }
    }

    xhr.open('GET', 'Home/NumbersForUser');
    xhr.send(null);
}


function _arrayToStr(arr, sparator)
{
    var strRes = "";

    for (var i = 0; i < arr.length; i++)
    {
        strRes += arr[i];

        if (i < arr.length - 1)
            strRes += ',';
    }

    return strRes;
}

//
// {"Sum":num,"Uniques":[num,num1,num2],"Repetitions":num}
//
function GetStatFromServer()
{
    $.get('Home/Statictics', null, function (data, textStatus) {

        var recivedResult = JSON.parse(data);

        var fUniques = document.getElementById("fUniques");
        var fSum = document.getElementById("fSum");
        var fNrRepetitions = document.getElementById("fNrRepetitions");

        var strUniques = _arrayToStr(recivedResult.Uniques);

        fUniques.value = strUniques;
        fSum.value = recivedResult.Sum;
        fNrRepetitions.value = recivedResult.Repetitions;
    });
}

