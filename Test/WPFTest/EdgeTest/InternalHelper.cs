using System;
using System.IO;
using System.Threading.Tasks;
using EdgeJs;

namespace EdgeTest {

    public static class EdgeServer {
        public const int ServerPort = 4411;

        private static Func<object, Task<object>> serverTask;

        public static async Task<object> Start() {
            var start = Edge.Func("return require('./../edge.app/app.js')");

            serverTask = (Func<object, Task<object>>)await start(new {
                port = ServerPort,
                location = new DirectoryInfo(typeof(App).Assembly.Location).FullName
            });

            return null;
        }

        public static async Task<object> Stop() {
            return await serverTask(null);
        }
    }
}