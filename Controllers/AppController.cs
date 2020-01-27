using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetExamenam.Models;
using NetExamenam.Services;

namespace NetExamenam.Controllers
{
    public class AppController : Controller
    {
        private readonly UrlFinderService _urlFinder;
        private readonly UrlDomainService _domainService;

        public AppController(
            UrlFinderService urlFinderService,
            UrlDomainService domainService)
        {
            _urlFinder = urlFinderService;
            _domainService = domainService;
            //_appContext = appContext;
        }

        // GET: App
        public ActionResult Index()
        {
            return View("UrlFinder");
        }

        public async Task<ActionResult> GetUrls(UrlFindModel urlFindModel)
        {
            var urls = await _urlFinder.FindUrls(urlFindModel);

            if (!urls.Any())
            {
                return View("OperationError", new OperationErrorModel
                {
                    Message = "Не удалось найти ссылки"
                });
            }

            _domainService.SaveUrls(urls);
            return View("ResultView", urls);
        }

        // GET: App/Details/5
        public ActionResult GetAllUrls()
        {
            return View("ResultView", _domainService.GetAllUrls());
        }
    }
}