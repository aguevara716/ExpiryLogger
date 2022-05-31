using ExpiryLogger.DataAccessLayer.Entities;
using ExpiryLogger.DataAccessLayer.Repositories;
using Microsoft.Extensions.Logging;

namespace ExpiryLogger.NotifierService;

public interface IItemsRetriever
{
    EmailData GetEmailData();
}

public class ItemsRetriever : IItemsRetriever
{
    private readonly ILogger<IItemsRetriever> _logger;
    private readonly IRepository<ProductDetail> _productDetailsRepository;
    private readonly ITimeframeRetriever _timeframeRetriever;

    public ItemsRetriever(ILogger<IItemsRetriever> logger, IRepository<ProductDetail> productDetailsRepository, ITimeframeRetriever timeframeRetriever)
    {
        _logger = logger;
        _productDetailsRepository = productDetailsRepository;
        _timeframeRetriever = timeframeRetriever;
    }

    public EmailData GetEmailData()
    {
        _logger.LogTrace("GetEmailData");
        var (firstDayOfMonth, lastDayOfMonth) = _timeframeRetriever.GetCurrentMonth();
        var (firstDayOfWeek, lastDayOfWeek) = _timeframeRetriever.GetCurrentWeek();
        var (today, tomorrow) = _timeframeRetriever.GetCurrentDay();
        var productsExpiringThisMonth = _productDetailsRepository.Get(pd => pd.ExpirationDate >= firstDayOfMonth && pd.ExpirationDate <= lastDayOfMonth)?.ToList() ?? new List<ProductDetail>();
        _logger.LogInformation("Found {productsExpiringThisMonthCount:N0} products expiring this month", productsExpiringThisMonth.Count);

        var expiredThisMonth = productsExpiringThisMonth.Where(pd => pd.ExpirationDate >= firstDayOfMonth && pd.ExpirationDate < today);
        var expiringThisMonth = productsExpiringThisMonth.Where(pd => pd.ExpirationDate >= today && pd.ExpirationDate <= lastDayOfMonth);
        var expiringThisWeek = productsExpiringThisMonth.Where(pd => pd.ExpirationDate > today && pd.ExpirationDate <= lastDayOfWeek);
        var expiringToday = productsExpiringThisMonth.Where(pd => pd.ExpirationDate >= today && pd.ExpirationDate < tomorrow);

        var emailData = new EmailData.Builder()
            .SetExpiredThisMonth(expiredThisMonth)
            .SetExpiringThisMonth(expiringThisMonth)
            .SetExpiringThisWeek(expiringThisWeek)
            .SetExpiringToday(expiringToday)
            .Build();
        return emailData;
    }
}
