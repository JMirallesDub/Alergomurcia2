//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Alergomurcia.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblUploadedFiledetail
    {
        public int fileID { get; set; }
        public string filenameName { get; set; }
        public string filePath { get; set; }
        public string Createdby { get; set; }
        public Nullable<System.DateTime> CreatedDt { get; set; }
        public string Updatedby { get; set; }
        public Nullable<System.DateTime> UpdatedDt { get; set; }
        public bool Active { get; set; }
        public int seccion { get; set; }
        public string title { get; set; }
        public string category { get; set; }
        public string idCategory { get; set; }
    }
}