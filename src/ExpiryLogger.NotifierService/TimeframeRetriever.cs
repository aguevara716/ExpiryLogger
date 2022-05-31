using Microsoft.Extensions.Logging;

namespace ExpiryLogger.NotifierService;

public readonly record struct Timeframe(DateTime StartDate, DateTime EndDate);

public interface ITimeframeRetriever
{
    Timeframe GetCurrentMonth();
    Timeframe GetCurrentWeek();
    Timeframe GetCurrentDay();
}

public class TimeframeRetriever : ITimeframeRetriever
{
    private readonly ILogger<ITimeframeRetriever> _logger;

    public TimeframeRetriever(ILogger<ITimeframeRetriever> logger)
    {
        _logger = logger;
    }

    public Timeframe GetCurrentMonth()
    {
        _logger.LogTrace("GetCurrentMonth");
        var firstDayOfMonth = DateTimeExtensions.GetFirstDayOfCurrentMonth();
        var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddTicks(-1);
        var tf = new Timeframe(firstDayOfMonth, lastDayOfMonth);
        _logger.LogTrace("Current month: {timeframe}", tf);
        return tf;
    }

    public Timeframe GetCurrentWeek()
    {
        _logger.LogTrace("GetCurrentWeek");
        var firstDayOfWeek = DateTimeExtensions.GetFirstDayOfCurrentWeek();
        var lastDayOfWeek = firstDayOfWeek.AddDays(7).AddTicks(-1);
        var tf = new Timeframe(firstDayOfWeek, lastDayOfWeek);
        _logger.LogTrace("Current week: {timeframe}", tf);
        return tf;
    }

    public Timeframe GetCurrentDay()
    {
        _logger.LogTrace("GetCurrentDay");
        var tomorrow = DateTime.Today.AddDays(1).AddTicks(-1);
        var tf = new Timeframe(DateTime.Today, tomorrow);
        _logger.LogTrace("Current day {timeframe}", tf);
        return tf;
    }
}
