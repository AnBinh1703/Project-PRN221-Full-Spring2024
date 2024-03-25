"use strict";
var connection = new signalR.HubConnectionBuilder().withUrl("/abcd").build();
connection.on("cmf5edit", function () {
    location.href = '/List'
});
connection.start().catch(function (err) {
    return console.error(err.toString());
});
