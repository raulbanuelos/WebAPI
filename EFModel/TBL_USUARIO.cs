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
    
    public partial class TBL_USUARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_USUARIO()
        {
            this.TR_USUARIO_NEGOCIO = new HashSet<TR_USUARIO_NEGOCIO>();
        }
    
        public int ID_USUARIO { get; set; }
        public string USUARIO { get; set; }
        public string PASSWORD { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO_PATERNO { get; set; }
        public string APELLIDO_MATERNO { get; set; }
        public Nullable<System.DateTime> FECHA_NACIMIENTO { get; set; }
        public Nullable<System.DateTime> FECHA_CREACION { get; set; }
        public Nullable<int> ID_USUARIO_CREACION { get; set; }
        public Nullable<System.DateTime> FECHA_ACTUALIZACION { get; set; }
        public Nullable<int> ID_USUARIO_ACTUALIZACION { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TR_USUARIO_NEGOCIO> TR_USUARIO_NEGOCIO { get; set; }
    }
}
