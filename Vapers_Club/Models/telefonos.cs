//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Vapers_Club.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class telefonos
    {
        public int id { get; set; }
        public Nullable<int> id_cliente { get; set; }
        public Nullable<int> id_proveedor { get; set; }
        public int telefono { get; set; }
        public int tipo { get; set; }
    
        public virtual clientes clientes { get; set; }
        public virtual proveedores proveedores { get; set; }
        public virtual tipo_tel tipo_tel { get; set; }
    }
}
