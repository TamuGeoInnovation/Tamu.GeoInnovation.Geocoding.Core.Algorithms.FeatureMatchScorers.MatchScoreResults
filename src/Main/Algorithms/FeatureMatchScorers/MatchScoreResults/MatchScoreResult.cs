using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using USC.GISResearchLab.Common.Addresses;

namespace USC.GISResearchLab.Geocoding.Core.Algorithms.FeatureMatchScorers.MatchScoreResults
{
    public class MatchScoreResult
    {

        #region Properties

        public string Error { get; set; }
        public bool ExceptionOccurred { get; set; }

        [XmlIgnore]
        public Exception Exception { get; set; }

        public List<MatchScorePenaltyResult> MatchScorePenaltyResults { get; set; }

        public double MatchScore
        {
            get
            {
                double ret = 100;
                if (MatchScorePenaltyResults.Count > 0)
                {
                    foreach (MatchScorePenaltyResult penalty in MatchScorePenaltyResults)
                    {
                        ret -= penalty.PenaltyValue;
                    }
                }
                return ret;
            }
        }

        public double AddressDistance { get; set; }
        public double AverageBlockSize { get; set; }
        public double NumberOfBlocksAway { get; set; }
        public FeatureMatchAddressParityResultType ParityResultType { get; set; }
        public FeatureMatchAddressRangeResultType AddressRangeResultType { get; set; }
        public FeatureMatchAddressRangePreferredEndResultType PreferredEndResultType { get; set; }
        public FeatureMatchAddressRangePreferredAddressRangeResultType PreferredAddressRangeResultType { get; set; }
        public AddressNumberType AddressNumberTypeUsed { get; set; }

        public TimeSpan TimeTaken { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }

        public AttributeWeightingScheme AttributeWeightingScheme { get; set; }

        #endregion

        public MatchScoreResult()
            : this(null)
        {
        }

        public MatchScoreResult(AttributeWeightingScheme attributeWeightingScheme)
        {
            MatchScorePenaltyResults = new List<MatchScorePenaltyResult>();
            ParityResultType = FeatureMatchAddressParityResultType.Unknown;
            AddressRangeResultType = FeatureMatchAddressRangeResultType.Unknown;
            PreferredEndResultType = FeatureMatchAddressRangePreferredEndResultType.Unknown;
            PreferredAddressRangeResultType = FeatureMatchAddressRangePreferredAddressRangeResultType.Unknown;
            AddressDistance = double.MaxValue;

            if (attributeWeightingScheme == null)
            {
                AttributeWeightingScheme = new AttributeWeightingScheme();
            }
            else
            {
                AttributeWeightingScheme = attributeWeightingScheme;
            }
        }

        public MatchScorePenaltyResult GetMatchScorePenaltyResult(AddressComponents addressComponent)
        {
            MatchScorePenaltyResult ret = null;

            if (MatchScorePenaltyResults != null)
            {
                foreach (MatchScorePenaltyResult matchScorePenaltyResult in MatchScorePenaltyResults)
                {
                    if (matchScorePenaltyResult.AddressComponent == addressComponent)
                    {
                        ret = matchScorePenaltyResult;
                        break;
                    }
                }
            }

            if (ret == null)
            {
                throw new Exception("unable to find penalty result for addressComponent: " + addressComponent);
            }


            return ret;
        }

        public void StartTimer()
        {
            TimeStart = DateTime.Now;
        }

        public void EndTimer()
        {
            TimeEnd = DateTime.Now;
            TimeTaken = TimeEnd.Subtract(TimeStart);
        }
    }
}
