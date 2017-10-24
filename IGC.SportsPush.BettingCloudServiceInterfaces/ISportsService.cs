using ICG.SportsPush.BettingCloud.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGC.SportsPush.BettingCloud.ServiceInterfaces
{
    public interface ISportsService
    {
        List<SportTypeDTO> GetSports(List<KeyValuePair<string, object>> queryVariables);
        SportTypeDTO GetSport(List<KeyValuePair<string, object>> queryVariables);
    }
}
