using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Hospital.Web.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboCategoryOrders();
    }

}
