//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExamenFInalProgramacion3_MatthiasPaniagua.Controllers
{
    using System;
    using System.Collections.Generic;
    
    public partial class Proyectos
    {
        public int idpro { get; set; }
        public string npro { get; set; }
        public Nullable<System.DateTime> fechaI { get; set; }
        public Nullable<System.DateTime> fechaF { get; set; }
        public Nullable<int> EmpleadoId { get; set; }
        public Nullable<int> rolid { get; set; }
    
        public virtual Empleados Empleados { get; set; }
        public virtual Roles Roles { get; set; }
    }
}
