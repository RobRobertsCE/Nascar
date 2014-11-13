using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Nascar.Api.Models;

namespace Nascar.Data
{
    [Table("Track")]
    public class Track
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None), Key()] 
        public int track_id { get; set; }
        public double track_length { get; set; }
        public string track_name { get; set; }

        public Track()
        {

        }

        public Track(int id, double length, string name)
        {
            track_id = id;
            track_length = length;
            track_name = name;
        }

        public void ApplyToModel(LiveFeedModel model)
        {
            model.track_id = track_id;
            model.track_length = track_length;
            model.track_name = track_name;
        }
    }
}
