using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NascarApi
{
    public interface IFeedProcessor<T>
    {
        int season_id { get; }
        int series_id { get; }
        int race_id { get; }
        int run_id { get; }

        void ProcessJson(string feedJson);
        void ProcessModel(T model);
    }
}
