//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace prova_mvc.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class pictures
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public pictures()
        {
            this.comments = new HashSet<comments>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public byte[] picture { get; set; }
        public Nullable<int> user_id { get; set; }
        public byte[] data { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<comments> comments { get; set; }
        public virtual user user { get; set; }
    }
}
