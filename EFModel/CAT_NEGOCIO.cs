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
    
    public partial class CAT_NEGOCIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CAT_NEGOCIO()
        {
            this.TBL_CALIFICACION_NEGOCIO = new HashSet<TBL_CALIFICACION_NEGOCIO>();
            this.TBL_RELACIION = new HashSet<TBL_RELACIION>();
            this.TR_USUARIO_NEGOCIO = new HashSet<TR_USUARIO_NEGOCIO>();
            this.PEDIDOS = new HashSet<PEDIDOS>();
        }
    
        public int ID_NEGOCIO { get; set; }
        public Nullable<double> LATITUD { get; set; }
        public Nullable<double> LONGITUD { get; set; }
        public string NOMBRE { get; set; }
        public string DESCRIPCION { get; set; }
        public string HORARIOS { get; set; }
        public string TELEFONO { get; set; }
        public Nullable<bool> IS_ACTIVO { get; set; }
        public string CODIGO_ACTIVACION { get; set; }
        public Nullable<System.DateTime> FECHA_CREACION { get; set; }
        public Nullable<int> ID_USUARIO_CREACION { get; set; }
        public Nullable<System.DateTime> FECHA_ACTUALIZACION { get; set; }
        public Nullable<int> ID_USUARIO_ACTUALIZACION { get; set; }
        public Nullable<int> ESTATUS { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_CALIFICACION_NEGOCIO> TBL_CALIFICACION_NEGOCIO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_RELACIION> TBL_RELACIION { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TR_USUARIO_NEGOCIO> TR_USUARIO_NEGOCIO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PEDIDOS> PEDIDOS { get; set; }
    }
}
