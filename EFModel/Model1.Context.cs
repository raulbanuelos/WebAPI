﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BDEntities : DbContext
    {
        public BDEntities()
            : base("name=BDEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CAT_CATEGORIA> CAT_CATEGORIA { get; set; }
        public virtual DbSet<CAT_SUB_CATEGORIA> CAT_SUB_CATEGORIA { get; set; }
        public virtual DbSet<TBL_CALIFICACION_NEGOCIO> TBL_CALIFICACION_NEGOCIO { get; set; }
        public virtual DbSet<TBL_RELACIION> TBL_RELACIION { get; set; }
        public virtual DbSet<TR_USUARIO_NEGOCIO> TR_USUARIO_NEGOCIO { get; set; }
        public virtual DbSet<CAT_USUARIO_APLICACION> CAT_USUARIO_APLICACION { get; set; }
        public virtual DbSet<CAT_NEGOCIO> CAT_NEGOCIO { get; set; }
        public virtual DbSet<TBL_USUARIO> TBL_USUARIO { get; set; }
        public virtual DbSet<PEDIDOS> PEDIDOS { get; set; }
    }
}
