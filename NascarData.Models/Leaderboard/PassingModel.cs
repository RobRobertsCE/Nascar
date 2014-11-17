using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NascarData.Models.Leaderboard
{
    public class PassingModel
    {
        public double AverageRestartSpeed { get; set; }
        public double AverageRunningPosition { get; set; }
        public double AverageSpeed { get; set; }
        public int BestLap { get; set; }
        public double BestSpeed { get; set; }
        public double BestTime { get; set; }
        public string CarMake { get; set; }
        public string CarNo { get; set; }
        public int ElapsedTime { get; set; }
        public int FastestLaps { get; set; }
        public int LapCount { get; set; }
        public List<LapsLedModel> LapsLed { get; set; }
        public double LastLapSpeed { get; set; }
        public double LastLapTime { get; set; }
        public int Passes { get; set; }
        public int PassingDifferential { get; set; }
        public int RaceRank { get; set; }
        public int ResultID { get; set; }
        public int ResultStatus { get; set; }
        public string Sponsor { get; set; }
        public int StartPosition { get; set; }
        public int TimesPassed { get; set; }
        public double SFDelta { get; set; }
        public int QualifyingStatus { get; set; }
        public DriverModel Driver { get; set; }
        public int BonusPoints { get; set; }
        public int DeltaLeader { get; set; }
        public string FirstName { get; set; }
        public int HistoricalID { get; set; }
        public bool IsInChase { get; set; }
        public string LastName { get; set; }
        public int MembershipID { get; set; }
        public int Points { get; set; }
        public int PointsPosition { get; set; }
        public int RunningPositionPoints { get; set; }
        public bool is_on_track { get; set; }
    }

    //{
    //       "AverageRestartSpeed": 151.899,
    //       "AverageRunningPosition": 41.222,
    //       "AverageSpeed": 126.054,
    //       "BestLap": 2,
    //       "BestSpeed": 169.189,
    //       "BestTime": 31.917,
    //       "CarMake": "Chv",
    //       "CarNo": "7",
    //       "ElapsedTime": 1074,
    //       "FastestLaps": 0,
    //       "LapCount": 25,
    //       "LapsLed": [],
    //       "LastLapSpeed": 158.721,
    //       "LastLapTime": 34.022,
    //       "Passes": 10,
    //       "PassingDifferential": 7,
    //       "RaceRank": 43,
    //       "ResultID": 0,
    //       "ResultStatus": 1,
    //       "Sponsor": "Pilot/Flying J",
    //       "StartPosition": 39,
    //       "TimesPassed": 3,
    //       "SFDelta": -2,
    //       "QualifyingStatus": 0,
    //       "Driver":             {
    //           "DriverName": "Michael Annett #",
    //           "HistoricalDriverID": 3861,
    //           "IsInChase": false
    //       },
    //       "BonusPoints": 0,
    //       "DeltaLeader": -4519,
    //       "FirstName": "Michael",
    //       "HistoricalID": 3861,
    //       "IsInChase": false,
    //       "LastName": "Annett",
    //       "MembershipID": 146574,
    //       "Points": 523,
    //       "PointsPosition": 33,
    //       "RunningPositionPoints": 1,
    //       "is_on_track": true
    //   }
}
