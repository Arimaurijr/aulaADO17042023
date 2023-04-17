using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aulaADO17042023.Model;
using aulaADO17042023.Services;

namespace aulaADO17042023.Controllers
{
    public class AirplaneController
    {
        public bool Insert(Aviao airplane)
        {
            return new AirplaneService().Insert(airplane);
        }
        public List<Aviao> FindAll()
        {
            return new AirplaneService().FindAll();
        }
    }
}
