using ICG.SportsPush.BettingCloud.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGC.SportsPush.BettingCloud.ServiceInterfaces
{
    public interface ICategoriesService
    {
        List<CategoryTypeDTO> GetCategories(List<KeyValuePair<string, object>> queryVariables);
        CategoryTypeDTO GetCategory(List<KeyValuePair<string, object>> queryVariables);
    }
}
