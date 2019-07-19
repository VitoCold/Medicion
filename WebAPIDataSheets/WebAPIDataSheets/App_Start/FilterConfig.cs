using System.Web;
using System.Web.Mvc;

namespace WebAPIDataSheets
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
