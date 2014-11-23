using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NascarApi.Readers;

namespace NascarApi
{
    //
    // Processors 
    //
    public delegate void ProcessingCompleteDelegate(object sender, EventArgs e);
    public delegate void ArchivingCompleteDelegate(object sender, EventArgs e);
    public delegate void ProcessingErrorDelegate(object sender, Exception ex);

    //
    // Readers 
    //
    public delegate void ApiEngineStartedDelegate(object sender, EventArgs e);
    public delegate void ApiEngineStoppedDelegate(object sender, EventArgs e);
    public delegate void ApiEngineErrorDelegate(object sender, Exception e);
    public delegate void ApiResultDelegate(object sender, ApiFeedType feedType, string jsonResult);
    public delegate void AsyncApiResultDelegate(object sender, string jsonResult);
    public delegate void ApiModelEventDelegate<T>(object sender, ApiModelEventArgs<T> e);    
    

}
