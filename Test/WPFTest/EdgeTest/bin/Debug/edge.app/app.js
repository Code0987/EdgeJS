// FIX: #176 @https://github.com/tjanczuk/edge/issues/176 {
try {
    var stdout = process.stdout;
}
catch (e) {
    // This is a Windows GUI application without stdout and stderr defined.
    // Define process.stdout and process.stderr so that all output is discarded.
    (function () {
        var stream = require('stream');
        var NullStream = function (o) {
            stream.Writable.call(this);
            this._write = function (c, e, cb) { cb && cb(); };
        }
        require('util').inherits(NullStream, stream.Writable);
        var nullStream = new NullStream();
        process.__defineGetter__('stdout', function () { return nullStream; });
        process.__defineGetter__('stderr', function () { return nullStream; });
    })();
}
// }

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
