using System;
using System.Drawing;
using Nascar.Api.Models;

namespace Nascar.WinApp.Views
{
    public interface IVehicleViewModel
    {
        double AverageRunningPosition { get; }
        int BestLap { get; }
        double BestLapSpeed { get; }
        double BestLapTime { get; }
        GreenFlagRun CurrentRun { get; }
        double DeltaLeader { get; }
        double DeltaLeader10Laps { get; }
        double DeltaLeader5Laps { get; }
        double DeltaLeaderGainLoss { get; }
        double DeltaPosition10Laps { get; }
        double DeltaPosition5Laps { get; }
        int DeltaPositionsRace { get; }
        int DeltaPositionsRun { get; }
        string DriverName { get; }
        double FiveLapAverage { get; }
        Nascar.WinApp.FlagState FlagState { get; set; }
        bool IsOnTrack { get; }
        int LapsCompleted { get; }
        string LapsLead { get; }
        int LapsSincePit { get; }
        int LapsSinceRestart { get; }
        double LastLapSpeed { get; }
        double LastLapTime { get; }
        int LastPitLap { get; }
        int LastRestartLap { get; }
        int LastRestartPosition { get; }
        int PassDifferential { get; }
        int PassesMade { get; }
        int QualityPassesMade { get; }
        int RunningPosition { get; }
        int StartingPosition { get; }
        double TenLapAverage { get; }
        double TwentyLapAverage { get; }
        VehicleModel Vehicle { get; set; }
        string VehicleNumber { get; }
        Image ManufacturerImage { get; }
        Image VehicleNumberImage { get; }
    }
}
