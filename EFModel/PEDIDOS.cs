//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class PEDIDOS
    {
        public int ID_PEDIDO { get; set; }
        public int ID_USUARIO_APLICACION { get; set; }
        public System.DateTime FECHA_PEDIDO { get; set; }
        public int ESTATUS { get; set; }
        public Nullable<int> ID_NEGOCIO_ASIGNADO { get; set; }
        public double LATITUD_INICIAL { get; set; }
        public double LONGITUD_INICIAL { get; set; }
        public Nullable<double> LATITUD_DESTINO { get; set; }
        public Nullable<double> LONGITUD_DESTINO { get; set; }
        public Nullable<System.DateTime> FECHA_FINAL { get; set; }
    
        public virtual CAT_USUARIO_APLICACION CAT_USUARIO_APLICACION { get; set; }
        public virtual CAT_NEGOCIO CAT_NEGOCIO { get; set; }
    }
}
