using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Owin.Demo.Middleware;

namespace Owin.Demo
{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {

            //app.Use(async (ctx, nxt) =>
            //{
            //    Debug.WriteLine("Incomming..");
            //    await nxt();
            //    Debug.WriteLine("Outgoingin..");
            //});

            app.Use<DebugMiddleware>();

            app.Use(async (ctx, nxt) =>
            {
                await ctx.Response.WriteAsync("Hello World");

            });



         


        }

          
    }
}