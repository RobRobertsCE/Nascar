namespace NascarApi.Readers
{
    using System;
    using NascarApi.Models.Flag;

    public sealed class FlagModelEventArgs : ApiModelEventArgs<FlagModel>
    {
        public FlagModelEventArgs(FlagModel model)
            : base(model)
        { }
    }
}

