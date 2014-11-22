using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NascarApi
{
    public delegate void ProcessingCompleteDelegate(object sender, EventArgs e);
    public delegate void ArchivingCompleteDelegate(object sender, EventArgs e);
    public delegate void ProcessingErrorDelegate(object sender, Exception ex);
}
