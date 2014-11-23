namespace NascarApi.Readers
{
    using System;
    using NascarApi.Models.Qualifying;

    public sealed class QualifyingModelEventArgs : ApiModelEventArgs<QualifyingModel>
    {
        public QualifyingModelEventArgs(QualifyingModel model)
            : base(model)
        { }
    }
}
