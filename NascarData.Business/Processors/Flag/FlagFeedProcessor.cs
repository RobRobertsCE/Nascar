namespace NascarApi.Processors
{
    using NascarApi.Models.Flag;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NascarApi.Data;
    using NascarApi.Models;

    public class FlagFeedProcessor : FeedProcessor<FlagModel>
    {
        public override ApiFeedType FeedType
        {
            get { return ApiFeedType.LiveFlag; }
        }
       
        public FlagFeedProcessor(int season_id, int series_id, int race_id)
            : base(season_id, series_id, race_id)
        {
            
        }

        public override void ProcessModel(FlagModel model)
        {
            try
            {
                this.UpdateRunFlagState(model);
            }
            catch (Exception ex)
            {
                this.ExceptionHandler(ex);
            }
        }

        protected override void BeginProcessAsync(FlagModel model)
        {
            this.UpdateRunFlagState(model);
        }
        
        protected internal void UpdateRunFlagState(FlagModel model)
        {
            if (null == this.Run) return;

            RunFlagState flagState = this.Run.RunFlagStates.Where(s=>s.elapsed_time == model.elapsed_time).FirstOrDefault();

            if (null == flagState)
            {
                flagState = this.Context.RunFlagStates.Create();

                flagState.race_run_id = this.Run.race_run_id;
                flagState.flag_state = model.flag_state;
                flagState.lap_number = model.lap_number;
                flagState.elapsed_time = model.elapsed_time;
                flagState.comment = model.comment;
                flagState.beneficiary = model.beneficiary;
                flagState.time_of_day = model.time_of_day;

                this.Context.RunFlagStates.Attach(flagState);
                this.Run.RunFlagStates.Add(flagState);
                this.Context.SaveChanges();
            }
            else if (flagState.comment != model.comment || flagState.beneficiary != model.beneficiary)
            {
                flagState.comment = model.comment;
                flagState.beneficiary = model.beneficiary;
                this.Context.SaveChanges();
            }
        }
        
        protected internal Run FindRun(int race_id, int run_id)
        {
            return this.Context.Runs.Where(r => r.race_id == race_id && r.run_id == run_id).FirstOrDefault();
        }
    }
}