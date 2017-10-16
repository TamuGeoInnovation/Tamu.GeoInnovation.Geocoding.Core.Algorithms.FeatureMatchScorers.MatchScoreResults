using System;
using System.Xml.Serialization;
using USC.GISResearchLab.Common.Addresses;

namespace USC.GISResearchLab.Geocoding.Core.Algorithms.FeatureMatchScorers.MatchScoreResults
{
    public class MatchScorePenaltyResult
    {


        #region Properties

        public string Error { get; set; }

        [XmlIgnore]
        public Exception Exception { get; set; }
        public bool ExceptionOccurred { get; set; }

        private double _PenaltyValue;
        public double PenaltyValue
        {
            get
            {
                return _PenaltyValue;
            }
        }
        public TimeSpan TimeTaken { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }

        public AddressComponents AddressComponent { get; set; }

        public bool UsingAlternateZipCode { get; set; }
        public bool UsingAlternateCityName { get; set; }

        #endregion


        public override string ToString()
        {
            return AddressComponent.ToString() + " " + PenaltyValue + " " + TimeTaken.TotalMilliseconds;
        }

        public void StartTimer()
        {
            TimeStart = DateTime.Now;
        }

        public void AdjustPenalty(double newPenalty)
        {
            _PenaltyValue = newPenalty;
        }

        public void EndTimer(double value)
        {
            _PenaltyValue = value * 100.0;
            TimeEnd = DateTime.Now;
            TimeTaken = TimeEnd.Subtract(TimeStart);
        }
    }
}
