//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DiyetSporWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblAntremanAyrinti
    {
        public int ayrintiid { get; set; }
        public Nullable<int> antremanid { get; set; }
        public Nullable<int> programid { get; set; }
    
        public virtual tblAntreman tblAntreman { get; set; }
        public virtual tblProgram tblProgram { get; set; }
    }
}
