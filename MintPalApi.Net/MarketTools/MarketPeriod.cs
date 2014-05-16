namespace Jojatekok.MintPalAPI.MarketTools
{
    /// <summary>Represents a time frame of a market.</summary>
    public enum MarketPeriod
    {
        /// <summary>A time interval of 6 hours.</summary>
        Hours6,

        /// <summary>A time interval of 24 hours.</summary>
        Hours24,

        /// <summary>A time interval of 3 days.</summary>
        Days3,

        /// <summary>A time interval of a week.</summary>
        Week,

        /// <summary>The maximum time interval for a given market.</summary>
        Maximum
    }
}
