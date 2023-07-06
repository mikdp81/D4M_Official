using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AraneaUtilities.CronAsyncTasks
{
    /// <summary>
    /// Base class for temporized and asyncronous operation on web server
    /// </summary>
    public abstract class CronAsyncHandler2 : HttpTaskAsyncHandler
    {

        public override async Task ProcessRequestAsync(HttpContext context)
        {
            await Task.Run(() =>
            {
                ServeContent(context);
            });

            Console.WriteLine("Test");
        }

        abstract protected void ServeContent(HttpContext context);

    }
}
