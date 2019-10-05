using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetWebApplicationDemo.Models;
using System.Xml;
using System.Xml.Linq;

namespace AspNetWebApplicationDemo.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            XDocument doc = XDocument.Load("D:\\Imuri\\Race_2019_10_02_15_17_26.xml");
            var racedata = new List<Tuple<int, string, string>>();

            foreach (XElement el in doc.Root.Descendants())
            {
                if (el.Name == "Driver")
                {
                    int position = 0;
                    string name = "";
                    string FinishTime = "";


                    foreach (XElement resultTable in el.Descendants())
                    {
                        if (resultTable.Name == "Position")
                        {
                            position = Int32.Parse(resultTable.Value);
                        }
                        else if (resultTable.Name == "Name")
                        {
                            name = resultTable.Value;
                        }
                        else if (resultTable.Name == "FinishTime")
                        {
                            FinishTime = resultTable.Value;
                        }
                    }
                    racedata.Add(new Tuple<int, string, string>(position, name, FinishTime));

                }

            }
            racedata.Sort();
            foreach (Tuple<int, string, string> data in racedata)
            {
                //Console.WriteLine(data.Item1 + " " + data.Item2 + " " + data.Item3 + " ");

                ViewBag.kisadata = racedata;
               
            }

            /*
            XDocument doc = XDocument.Load("D:\\Imuri\\Race_2019_10_02_15_17_26.xml");

            List<string> lista = new List<string>();


            foreach (XElement el in doc.Root.Descendants())
            {
                if (el.Name == "Position")
                {
                    lista.Add(el.Value);
                }

                else if (el.Name == "Name" || el.Name == "FinishTime")
                {
                    
                    lista.Add(el.Value);
                }
            }
         

            ViewBag.dumppi = lista;
            */


            /*
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("D:\\Imuri\\Race_2019_10_02_15_17_26.xml");

            XmlNodeList driver = xmlDoc.GetElementsByTagName("Driver");

            List<string> lista = new List<string>();

            for (int laske = 0; laske < driver.Count; laske++)
            {
                var driverdata = new List<XmlNode>(driver[laske].Cast<XmlNode>());
                for (int laske2 = 0; laske2 < driverdata.Count; laske2++)
                {
                    lista.Add(driverdata[laske2].InnerText);
                }
            }

            ViewBag.dumppi = lista;
            */


            //XmlDocument tulosXml = new XmlDocument(); // Create an XML document object
            //tulosXml.Load("D:\\Imuri\\Race_2019_10_02_15_17_26.xml"); // Load the XML document from the specified file


            //XmlNodeList driver = tulosXml.GetElementsByTagName("Driver");

            //Lukee XML dokumentista Driver kentän ja kaiken sen alta
            //XmlNodeList kuski = tulosXml.GetElementsByTagName("Driver");
            //XmlNodeList simNimi = tulosXml.GetElementsByTagName("Name");
            //XmlNodeList simSijoitus = tulosXml.GetElementsByTagName("Position");
            //XmlNodeList simAika = tulosXml.GetElementsByTagName("FinishTime");

            //ViewBag.kuskinimi = kuski[0].InnerText;
            //ViewBag.kuskinimi = simNimi[0].InnerText;
            //ViewBag.kuskisijoitus = simSijoitus[0].InnerText;
            //ViewBag.kuskiaika = simAika[0].InnerText;

            // Display the results
            //Console.WriteLine("Nimi: " + simNimi[0].InnerText);
            //Console.WriteLine("Sijoitus: " + simSijoitus[0].InnerText);
            //Console.WriteLine("Loppuaika: " + simAika[0].InnerText);



            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
