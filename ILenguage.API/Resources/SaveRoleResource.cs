using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;//anotaciones y entradas de datos
using System.Linq;
using System.Threading.Tasks;

namespace ILenguage.API.Resources
{
    public class SaveRoleResource
    {
        //sirve para guardar la informacion
        [Required]//condiciones
        [MaxLength(30)]//condiciones
        //solo guardamos el nombre debido a que el ID se autogenera
        public string Name { get; set; }
    }
}
