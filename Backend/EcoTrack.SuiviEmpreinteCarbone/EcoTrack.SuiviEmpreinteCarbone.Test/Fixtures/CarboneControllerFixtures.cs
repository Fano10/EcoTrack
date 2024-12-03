using EcoTrack.SuiviEmpreinteCarbone.API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoTrack.SuiviEmpreinteCarbone.Test.Fixtures
{
    public class CarboneControllerFixtures
    {
        public static UserDto getExistUser()
        {
            return new UserDto()
            {
                Sub = "1",
                Name = "fano"
            };
        }
        public static UserDto getNotExistUser()
        {
            return new UserDto()
            {
                Sub = "2",
                Name = "bob"
            };
        }
    }
}
