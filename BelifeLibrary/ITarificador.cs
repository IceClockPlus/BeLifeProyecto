using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelifeLibrary
{
    interface ITarificador
    {
        Cliente Cliente { get; set; }

        double CalcularPrima();
    }
}
