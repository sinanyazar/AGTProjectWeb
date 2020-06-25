using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using AGT_Web_Project.Models;

namespace AGT_Web_Project.Controllers
{
    public class HomeController : Controller
    {
        private List<Cities> _cityList = new List<Cities>();
        private List<Rates> _rateList = new List<Rates>();

        // GET: Home
        public ActionResult Index()
        {
            // XML ile meteoroloji genel müdürlüğünün sitesinden verilerin çekilmesi ...
            #region Hava Durumu
            string url = "https://www.mgm.gov.tr/FTPDATA/analiz/sonSOA.xml";

            WebClient wc = new WebClient();

            string xmlData = wc.DownloadString(url);

            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(xmlData);

            XmlNodeList cities = xDoc.DocumentElement.SelectNodes("sehirler");

            foreach (XmlNode item in cities)
            {
                if (item.SelectSingleNode("ili").InnerText == "İSTANBUL")
                {
                    try
                    {
                        Cities city = new Cities();

                        city.City = item.SelectSingleNode("ili").InnerText;
                        city.State = item.SelectSingleNode("Durum").InnerText;
                        city.MaxTemperature = int.Parse(item.SelectSingleNode("Mak").InnerText);
                        
                        _cityList.Add(city);
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }
            }

            ViewBag.City = _cityList.FirstOrDefault().City;
            ViewBag.CityState = _cityList.FirstOrDefault().State;
            ViewBag.CityMaxTemperature = _cityList.FirstOrDefault().MaxTemperature + " ºC";

            #endregion // XML ile  // XML ile 

            // XML ile merkez bankasının sitesinden verilerin çekilmesi ...
            #region Merkez Bankası Kur
            string urlRate = "https://www.tcmb.gov.tr/kurlar/today.xml";

            string xmlRateData = wc.DownloadString(urlRate);

            xDoc.LoadXml(xmlRateData);

            XmlNodeList rates = xDoc.DocumentElement.SelectNodes("Currency");

            foreach (XmlNode item in rates)
            {
                if (item.SelectSingleNode("Isim").InnerText == "ABD DOLARI" || item.SelectSingleNode("Isim").InnerText == "EURO" || item.SelectSingleNode("CurrencyName").InnerText == "POUND STERLING")
                {
                    try
                    {
                        Rates rate = new Rates();
                        if (item.SelectSingleNode("CurrencyName").InnerText == "POUND STERLING")
                        {
                            rate.Name = item.SelectSingleNode("CurrencyName").InnerText;
                        }
                        else
                        {
                            rate.Name = item.SelectSingleNode("Isim").InnerText;
                        }
                        rate.ForexBuying = item.SelectSingleNode("ForexBuying").InnerText;
                        rate.ForexSelling = item.SelectSingleNode("ForexSelling").InnerText;

                        _rateList.Add(rate);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }

            ViewBag.RateList = _rateList.ToList();
            #endregion

            return View();
        }
    }
}