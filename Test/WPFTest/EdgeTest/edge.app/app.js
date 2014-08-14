module.exports = function (data, callback) {

    // Imports.
    var edge = require("./../edge/edge.js"),
        http = require("http");

    // Create http server.
    var server = http.createServer(function (request, response) {

        response.end("Hello from edge (node inside .Net CLR) ! It's " + new Date() + ".");

    }).listen(data.port, function () {

        // Stop callback.
        callback(null, function (data, callback) {
            server.close();
            callback();
        });

    });

    return server;
};