function CalculateBudget() {
    var netPay = $("#netPay")[0].value;
    var netPay2 = $("#netPay2")[0].value;
    var housing = $("#housing")[0].value;
    var utilities = $("#utilities")[0].value;
    var otherBills = $("#otherBills")[0].value;
    var savings = $("#savings")[0].value;
    var food = $("#food")[0].value;
    var entertainment = $("#entertainment")[0].value;
    var others = $("#others")[0].value;
    var remaining = 0;
        remaining = +netPay + +netPay2 - +utilities - +housing - +otherBills;
        $("#remaining")[0].value = remaining;
        $("#savings1")[0].value = remaining * (.01 * savings);
        $("#food1")[0].value = remaining * (.01 * food);
        $("#entertainment1")[0].value = remaining * (.01 * entertainment);
        $("#others1")[0].value = remaining * (.01 * others);   
}