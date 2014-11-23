namespace NascarApi
{
    using NascarApi.Models;
    using System;

    public class ApiModelEventArgs<T> : EventArgs
    {
        public T Model { get; protected set; }

        public DateTime Arrived { get; protected internal set; }
        
        public ApiModelEventArgs(T model)
        {
            this.Arrived = DateTime.Now;
            this.Model = model;
        }
    }
    public class IApiModelEventArgs: EventArgs
    {
        public IApiModel Model { get; protected set; }

        public DateTime Arrived { get; protected internal set; }

        public IApiModelEventArgs(IApiModel model)
        {
            this.Arrived = DateTime.Now;
            this.Model = model;
        }
    }
}
