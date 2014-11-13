using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Nascar.Api.Models;

namespace Nascar.Data
{
    [Table("Driver")]
    public class Driver
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None), Key()] 
        public int driver_id { get; set; }
        public string full_name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public bool is_in_chase { get; set; }
        
        public Driver()
        {

        }

        public Driver(DriverModel model)
        {
            driver_id = model.driver_id;
            full_name = model.full_name;
            first_name = model.first_name;
            last_name = model.last_name;
            is_in_chase = model.is_in_chase;
        }

        public void ApplyToModel(DriverModel model)
        {
            model.driver_id = driver_id;
            model.full_name = full_name;
            model.first_name = first_name;
            model.last_name = last_name;
            model.is_in_chase = is_in_chase;
        }
    }
}
