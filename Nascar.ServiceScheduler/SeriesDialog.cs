using System;
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
    public partial class SeriesDialog : Form
    {
        public bool IsNew { get; set; }

        private ScheduledSeries _series = null;
        public ScheduledSeries Series
        { 
            get 
            { return _series; } 
            private set 
            {
                _series = value;
            } 
        }

        public SeriesDialog()
            : this(new ScheduledSeries())
        {  }

        public SeriesDialog(ScheduledSeries series)
        {
            InitializeComponent();
            this.Series = series;
            this.IsNew = (this.Series.series_id==-1);
            SetBindings();
        }

        void SetBindings()
        {
            if (null == _series) return;
            this.txtId.DataBindings.Add(new Binding("Text", Series, "series_id"));
            this.txtName.DataBindings.Add(new Binding("Text", Series, "series_name"));
        }
    }
}
