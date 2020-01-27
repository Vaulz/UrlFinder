using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetExamenam.Models;

namespace NetExamenam.Services
{
    public class UrlDomainService
    {
        private readonly AppContext _appContext;

        public UrlDomainService(AppContext appContext)
        {
            _appContext = appContext;
        }

        public void SaveUrls(IEnumerable<UrlModel> urlModels)
        {

            _appContext.UrlModels.AddRange(
                urlModels.Where(x => !_appContext.UrlModels.Any(y => y.Url == x.Url)));

            _appContext.SaveChanges();
        }

        public List<UrlModel> GetAllUrls()
        {

            return _appContext.UrlModels.ToList();
        }
    }
}
