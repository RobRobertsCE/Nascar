using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nascar.Data.Schedule;

namespace Nascar.ServiceScheduler
{
    public partial class TrackDialog : Form
    {
        public bool IsNew { get; set; }

        private Track _track = null;
        public Track Track { 
            get 
            { return _track; } 
            private set 
            {
                _track = value;
            } 
        }

        public TrackDialog()
            :this(new Track())
        {  }

        public TrackDialog(Track track)
        {
            InitializeComponent();
            this.Track = track;
            this.IsNew = (this.Track.track_id==0);
            SetBindings();
        }

        void SetBindings()
        {
            if (null == _track) return;
            this.txtId.DataBindings.Add(new Binding("Text", Track, "track_id"));
            this.txtName.DataBindings.Add(new Binding("Text", Track, "track_name"));
            this.txtLength.DataBindings.Add(new Binding("Text", Track, "track_length"));
        }
    }
}
