using System.Web;
using System.Web.Mvc;

namespace ExamenFInalProgramacion3_MatthiasPaniagua
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
