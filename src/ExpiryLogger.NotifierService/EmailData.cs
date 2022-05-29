using System;
using ExpiryLogger.DataAccessLayer.Entities;

namespace ExpiryLogger.NotifierService
{
	public class EmailData
	{
		public ProductDetail[] ExpiredThisMonth { get; private set; }
		public ProductDetail[] ExpiringToday { get; private set; }
		public ProductDetail[] ExpiringThisWeek { get; private set; }
		public ProductDetail[] ExpiringThisMonth { get; private set; }

        private EmailData()
        {
            ExpiredThisMonth = Array.Empty<ProductDetail>();
            ExpiringToday = Array.Empty<ProductDetail>();
            ExpiringThisWeek = Array.Empty<ProductDetail>();
            ExpiringThisMonth = Array.Empty<ProductDetail>();
        }

        public class Builder
        {
            private readonly EmailData emailData;

            public Builder()
            {
                emailData = new EmailData();
            }

            public Builder SetExpiredThisMonth(IEnumerable<ProductDetail> productDetails)
            {
                emailData.ExpiredThisMonth = productDetails?.ToArray() ?? Array.Empty<ProductDetail>();
                return this;
            }

            public Builder SetExpiringToday(IEnumerable<ProductDetail> productDetails)
            {
                emailData.ExpiringToday = productDetails.ToArray()?.ToArray() ?? Array.Empty<ProductDetail>();
                return this;
            }

            public Builder SetExpiringThisWeek(IEnumerable<ProductDetail> productDetails)
            {
                emailData.ExpiringThisWeek = productDetails?.ToArray() ?? Array.Empty<ProductDetail>();
                return this;
            }

            public Builder SetExpiringThisMonth(IEnumerable<ProductDetail> productDetails)
            {
                emailData.ExpiringThisMonth = productDetails?.ToArray() ?? Array.Empty<ProductDetail>();
                return this;
            }

            public EmailData Build()
            {
                return emailData;
            }
        }

    }
}

