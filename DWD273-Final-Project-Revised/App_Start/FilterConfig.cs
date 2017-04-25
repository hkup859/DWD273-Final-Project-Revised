using System.Web;
using System.Web.Mvc;

namespace DWD273_Final_Project_Revised
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
