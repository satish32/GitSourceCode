using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Diagnostics;


using AppFunc = System.Func<
    System.Collections.Generic.IDictionary<string, object>,
    System.Threading.Tasks.Task
    >;

namespace Owin.Demo.Middleware
{
    public class DebugMiddleware
    {
        AppFunc _next;

        public DebugMiddleware(AppFunc next)
        {
            _next = next;
        }

        public async Task Invoke(Dictionary<string,object> env)
        {
            var owinCtx = new Microsoft.Owin.OwinContext(env);

            Debug.WriteLine("Incomming..");
            await _next(env);
            Debug.WriteLine("Outgoingin..");

        }
    }
}