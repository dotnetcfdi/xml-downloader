using XmlDownloader.Core.Helpers;

namespace XmlDownloader.Core.Models;

public class DateTimePeriod
{
    public DateTimePeriod(DateTime startDate, DateTime endDate)
    {
        StartDate = startDate;
        EndDate = endDate;

        StartDateSat = StartDate.ToSatFormat();
        EndDateSat = EndDate.ToSatFormat();
    }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }


    public string StartDateSat { get; set; }
    public string EndDateSat { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static DateTimePeriod CreateYesterdayQueryPeriod()
    {
        var yesterday = DateTime.Now.AddDays(-1);
        var startDate = yesterday.Date;
        var endDate = yesterday.Date.AddDays(1).AddSeconds(-1);
        return CreateQueryPeriod(startDate, endDate);
    }

    public static DateTimePeriod CreateTodayQueryPeriod()
    {
        var today = DateTime.Now;
        var startDate = today.Date;
        var endDate = today.Date.AddDays(1).AddSeconds(-1);
        return CreateQueryPeriod(startDate, endDate);
    }

    public static DateTimePeriod CreateQueryPeriod(DateTime startDate, DateTime endDate)
    {
        return new DateTimePeriod(startDate, endDate);
    }


    public static DateTimePeriod CreateTokenPeriod()
    {
        var created = DateTime.UtcNow;
        var expires = created.AddSeconds(300);
        return CreateQueryPeriod(created, expires);
    }

    public static DateTimePeriod CreateTokenPeriod(DateTime startDate)
    {
        var endDate = startDate.AddSeconds(300);
        return CreateQueryPeriod(startDate, endDate);
    }
}