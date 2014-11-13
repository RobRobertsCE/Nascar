using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Nascar.Api.Models;


namespace Nascar.Data
{
    [Table("LapsLed")]
    public class LapsLed
    {
        [Key()]
        public int laps_led_id { get; set; }
        public int vehicle_id { get; set; }
        //public int live_feed_id { get; set; }
        public int start_lap { get; set; }
        public int end_lap { get; set; }

    }
}
