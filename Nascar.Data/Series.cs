using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Nascar.Models;

namespace Nascar.Data
{
    [Table("Series")]
    public class Series
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None), Key()] 
        public int series_id { get; set; }
        public string series_name { get; set; }

        public Series()
        {

        }

        public Series(int id, string name)
        {
            series_id = id;
            series_name = name;
        }

        public void ApplyToModel(LiveFeedModel model)
        {
            model.series_id = series_id;
        }
    }
}
