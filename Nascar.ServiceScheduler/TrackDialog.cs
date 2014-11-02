﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nascar.ServiceScheduler.Data;

namespace Nascar.ServiceScheduler
{
    public partial class TrackDialog : Form
    {
        public bool IsNew { get; set; }

        private ScheduledTrack _track = null;
        public ScheduledTrack Track { 
            get 
            { return _track; } 
            private set 
            {
                _track = value;
            } 
        }

        public TrackDialog()
            :this(new ScheduledTrack())
        {  }

        public TrackDialog(ScheduledTrack track)
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
        }
    }
}
