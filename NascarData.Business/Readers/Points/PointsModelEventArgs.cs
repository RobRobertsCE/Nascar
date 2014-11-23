namespace NascarApi.Readers
{
    using System;
    using NascarApi.Models.Points;

    public sealed class PointsModelEventArgs : ApiModelEventArgs<PointsModel>
    {
        public PointsModelEventArgs(PointsModel model)
            : base(model)
        { }
    }
}
