namespace NascarApi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NascarApi.Processors;

    public interface IFeed
    {
        event ProcessingCompleteDelegate ProcessingComplete;
        event ProcessingErrorDelegate ProcessingError;
        event ArchivingCompleteDelegate ArchivingComplete;

        int season_id { get; }
        int series_id { get; }
        int race_id { get; }
    }
}
