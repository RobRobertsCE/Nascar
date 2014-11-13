using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nascar.Data.Schedule
{
    [Table("Session")]
    public class Session
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None), Key()]
        public int session_id { get; set; }
        public string session_name { get; set; }
    }
}
