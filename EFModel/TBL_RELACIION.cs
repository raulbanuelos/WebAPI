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
    
    public partial class TBL_RELACIION
    {
        public int ID_RELACIION { get; set; }
        public Nullable<int> ID_SUB_CATEGORIA { get; set; }
        public Nullable<int> ID_NEGOCIO { get; set; }
    
        public virtual CAT_SUB_CATEGORIA CAT_SUB_CATEGORIA { get; set; }
        public virtual CAT_NEGOCIO CAT_NEGOCIO { get; set; }
    }
}
