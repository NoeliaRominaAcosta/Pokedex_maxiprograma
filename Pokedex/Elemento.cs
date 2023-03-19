using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex
{
   class Elemento
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public override string ToString()
        {
            //cuando lo muestra en el datagrid, el toString muestra el namesspace 
            // y el nombre de la clase (base.ToString), por eso se sobreescribe el metodo para que muestre 
            //la descripcion
            return Descripcion; 
        }

    }
}
