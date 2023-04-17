using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aulaADO17042023.Models;

namespace aulaADO17042023.Model
{
    public class Aviao
    {
        #region Properties

        public int  Id{ get; set; }
        public string Name { get; set; }
        public int NumberOfPassagers { get; set; }
        public string Description { get; set; }
        public Engine Engine { get; set; }



        public override string ToString()
        {
            return $"Id:{Id},\nNome:{Name},\nNúmero de passageiros:{NumberOfPassagers},\nDescrição:{Description}, \nMotor: {Engine}";
        }

        #endregion
    }
}
