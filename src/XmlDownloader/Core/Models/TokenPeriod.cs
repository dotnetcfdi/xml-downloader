using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlDownloader.Core.Helpers;

namespace XmlDownloader.Core.Models
{
    public class TokenPeriod
    {
        public TokenPeriod(DateTime createdAt, DateTime expiresAt)
        {
            CreatedAt = createdAt;
            ExpiresAt = expiresAt;

            Created = CreatedAt.ToSatFormat();
            Expires = ExpiresAt.ToSatFormat();
        }

        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }


        public string Created { get; set; }
        public string Expires { get; set; }

        public static TokenPeriod Create()
        {
            var created = DateTime.UtcNow;
            var expires = created.AddSeconds(300);
            return new TokenPeriod(created, expires);
        }
    }
}