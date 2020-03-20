//
//
//
SetUp();

//
//
//
function SetUp()
{
    var timerVar = setInterval(myTimer, 1000);
}

//
//
//
function myTimer()
{
    GetDataFromServer();
    GetDataFromServerUserNumbers();
    GetStatFromServer();
}


