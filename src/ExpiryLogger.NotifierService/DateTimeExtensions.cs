namespace ExpiryLogger.NotifierService;

public static class DateTimeExtensions
{
	public static DateTime GetFirstDayOfCurrentMonth()
	{
		return DateTime.Now.GetFirstDayOfMonth();
	}

	public static DateTime GetFirstDayOfMonth(this DateTime dateTime)
	{
		var dt = new DateTime(dateTime.Year, dateTime.Month, 1);
		return dt;
	}

	public static DateTime GetFirstDayOfCurrentWeek()
	{
		return DateTime.Today.GetFirstDayOfWeek();
	}

	public static DateTime GetFirstDayOfWeek(this DateTime dateTime)
	{
		var culturalFirstDayOfWeek = Thread.CurrentThread.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
		var firstDayOfWeek = dateTime.Date.AddDays((-(int)dateTime.DayOfWeek) + (int)culturalFirstDayOfWeek);
		return firstDayOfWeek;
	}

}
