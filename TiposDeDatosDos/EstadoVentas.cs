using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiposDeDatosDos
{
    public enum EstadoVentas
    {
        //Por defecto comienza a contar desde 0, pero si se desea que comience a contar desde
        //un número en específico, simplemente se le asigna.
        Exitoso = 1,
        PendienteDePago = 2,
        Cancelada = 3
    }
}
