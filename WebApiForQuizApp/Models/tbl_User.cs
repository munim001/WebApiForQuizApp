//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApiForQuizApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_User()
        {
            this.TBL_EXAM = new HashSet<TBL_EXAM>();
        }
    
        public long userid { get; set; }
        public string userName { get; set; }
        public string userLoginName { get; set; }
        public string userPassword { get; set; }
        public string userImage { get; set; }
        public Nullable<int> userType { get; set; }
        public Nullable<int> userCreatedBy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_EXAM> TBL_EXAM { get; set; }
        public virtual tbl_UserType tbl_UserType { get; set; }
    }
}
