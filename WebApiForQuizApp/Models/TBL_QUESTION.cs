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
    
    public partial class TBL_QUESTION
    {
        public long Question_id { get; set; }
        public Nullable<long> Question_exam_id { get; set; }
        public string Question_Text { get; set; }
        public string Question_Option1 { get; set; }
        public string Question_Option2 { get; set; }
        public string Question_Option3 { get; set; }
        public string Question_Option4 { get; set; }
        public string Question_Option5 { get; set; }
        public Nullable<int> Question_type { get; set; }
    
        public virtual TBL_EXAM TBL_EXAM { get; set; }
    }
}
