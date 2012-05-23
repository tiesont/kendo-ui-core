namespace Kendo.Mvc.UI
{
    /// <summary>
    /// Defines a generic ILinearScale.
    /// </summary>
    public interface ILinearScale<T> : IGaugeScale<T>
        where T : struct
    {
        /// <summary>
        /// The scale mirror.
        /// </summary>
        bool? Mirror { get; set; }

        /// <summary>
        /// The scale vertical.
        /// </summary>
        bool? Vertical { get; set; }
        
        /// <summary>
        /// The scale labels.
        /// </summary>
        GaugeLinearScaleLabels Labels { get; set; }
    }
}