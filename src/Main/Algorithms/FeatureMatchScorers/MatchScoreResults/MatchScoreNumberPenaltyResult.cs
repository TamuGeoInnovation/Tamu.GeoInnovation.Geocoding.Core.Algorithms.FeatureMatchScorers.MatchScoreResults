using System;

namespace USC.GISResearchLab.Geocoding.Core.Algorithms.FeatureMatchScorers.MatchScoreResults
{
    public class MatchScoreNumberPenaltyResult : MatchScorePenaltyResult
    {

        #region Properties

        public FeatureMatchAddressParityResultType AddressRangeParityResultType { get; set; }
        public FeatureMatchAddressParityResultType AddressRangeHouseNumberParityResultType { get; set; }
        public FeatureMatchAddressParityResultType AddressRangeSuperParityResultType { get; set; }

        public FeatureMatchAddressRangeResultType AddressRangeMajorResultType { get; set; }
        public FeatureMatchAddressRangeResultType AddressRangeHouseNumberMajorResultType { get; set; }
        public FeatureMatchAddressRangeResultType AddressRangeSuperResultType { get; set; }

        public double AddressRangeMajorDistance { get; set; }
        public double AddressRangeHouseNumberDistance { get; set; }
        public double AddressSuperDistance { get; set; }

        public FeatureMatchAddressRangePreferredEndResultType AddressRangePreferredEndResultType { get; set; }
        public FeatureMatchAddressRangePreferredEndResultType AddressRangeHouseNumberPreferredEndResultType { get; set; }
        public FeatureMatchAddressRangePreferredEndResultType AddressRangeSuperPreferredEndResultType { get; set; }

        public double OverallAddressDistance { get; set; }
        public FeatureMatchAddressParityResultType OverallParityResultType { get; set; }
        public FeatureMatchAddressRangeResultType OverallAddressRangeResultType { get; set; }
        public FeatureMatchAddressRangePreferredEndResultType PreferredEndResultType { get; set; }
        public FeatureMatchAddressRangePreferredAddressRangeResultType PreferredAddressRangeResultType { get; set; }
        public AddressNumberType AddressNumberTypeUsed { get; set; }

        public double AddressDistance { get; set; }
        public FeatureMatchAddressParityResultType ParityResultType { get; set; }
        public FeatureMatchAddressRangeResultType AddressRangeResultType { get; set; }

        public double AverageBlockSize { get; set; }
        public double NumberOfBlocksAway { get; set; }

        public double PenaltyRangeValue { get; set; }
        public double PenaltyParityValue { get; set; }

        #endregion


        public MatchScoreNumberPenaltyResult()
            : base()
        {
            AddressRangeParityResultType = FeatureMatchAddressParityResultType.Unknown;
            AddressRangeHouseNumberParityResultType = FeatureMatchAddressParityResultType.Unknown;
            AddressRangeSuperParityResultType = FeatureMatchAddressParityResultType.Unknown;
            OverallParityResultType = FeatureMatchAddressParityResultType.Unknown;

            AddressRangeHouseNumberMajorResultType = FeatureMatchAddressRangeResultType.Unknown;
            AddressRangeMajorResultType = FeatureMatchAddressRangeResultType.Unknown;
            AddressRangeSuperResultType = FeatureMatchAddressRangeResultType.Unknown;
            OverallAddressRangeResultType = FeatureMatchAddressRangeResultType.Unknown;

            AddressRangePreferredEndResultType = FeatureMatchAddressRangePreferredEndResultType.Unknown;
            AddressRangeHouseNumberPreferredEndResultType = FeatureMatchAddressRangePreferredEndResultType.Unknown;
            AddressRangeSuperPreferredEndResultType = FeatureMatchAddressRangePreferredEndResultType.Unknown;


            AddressRangeMajorDistance = Double.MaxValue;
            AddressRangeHouseNumberDistance = Double.MaxValue;
            AddressSuperDistance = Double.MaxValue;
            OverallAddressDistance = Double.MaxValue;

            PreferredEndResultType = FeatureMatchAddressRangePreferredEndResultType.Unknown;
            PreferredAddressRangeResultType = FeatureMatchAddressRangePreferredAddressRangeResultType.Unknown;
        }


        public override string ToString()
        {
            return AddressComponent.ToString() + " " + PenaltyValue + " " + OverallAddressRangeResultType.ToString() + " " + TimeTaken.TotalMilliseconds;
        }
    }
}
