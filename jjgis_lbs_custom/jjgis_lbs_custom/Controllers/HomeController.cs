using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using jjgis_lbs_custom.Models;
using Oracle.ManagedDataAccess.Client;
using Newtonsoft.Json;
using System.Data;

namespace jjgis_lbs_custom.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Insert()
        {
            string string1 = System.IO.File.ReadAllText(@"C:\Users\Administrator\Desktop\CFS\XQ\YBSQ_XQ.txt", Encoding.UTF8);
            //string string2 = System.IO.File.ReadAllText(@"C:\Users\Administrator\Desktop\CFS\XQ\ALKEXQ_XQ.txt", Encoding.UTF8);
            //string string3 = System.IO.File.ReadAllText(@"C:\Users\Administrator\Desktop\CFS\XQ\BLYQ_XQ.txt", Encoding.UTF8);
            //string string4 = System.IO.File.ReadAllText(@"C:\Users\Administrator\Desktop\CFS\XQ\BLZQ_XQ.txt", Encoding.UTF8);
            //string string5 = System.IO.File.ReadAllText(@"C:\Users\Administrator\Desktop\CFS\XQ\HSQ_XQ.txt", Encoding.UTF8);
            //string string6 = System.IO.File.ReadAllText(@"C:\Users\Administrator\Desktop\CFS\XQ\KLXQ_XQ.txt", Encoding.UTF8);
            //string string7 = System.IO.File.ReadAllText(@"C:\Users\Administrator\Desktop\CFS\XQ\KSKTQ_XQ.txt", Encoding.UTF8);
            //string string8 = System.IO.File.ReadAllText(@"C:\Users\Administrator\Desktop\CFS\XQ\LXX_XQ.txt", Encoding.UTF8);
            //string string9 = System.IO.File.ReadAllText(@"C:\Users\Administrator\Desktop\CFS\XQ\NCX_XQ.txt", Encoding.UTF8);
            //string string10 = System.IO.File.ReadAllText(@"C:\Users\Administrator\Desktop\CFS\XQ\SSQ_XQ.txt", Encoding.UTF8);
            //string string11 = System.IO.File.ReadAllText(@"C:\Users\Administrator\Desktop\CFS\XQ\WNTQ_XQ.txt", Encoding.UTF8);
            //string string12 = System.IO.File.ReadAllText(@"C:\Users\Administrator\Desktop\CFS\XQ\YBSQ_XQ.txt", Encoding.UTF8);

            //string stringLHSQ = System.IO.File.ReadAllText(@"C:\Users\Administrator\Desktop\PoisHousingCFS\PoisHousingHSQ\PoisHousingL\poisHousingLF.txt", Encoding.UTF8);
            //string stringXQSSQ = System.IO.File.ReadAllText(@"C:\Users\Administrator\Desktop\PoisHousingCFS\PoisHousingSSQ\PoisHousingXQ\poisHousingSSQMoreF.txt", Encoding.UTF8);
            //string stringLSSQ = System.IO.File.ReadAllText(@"C:\Users\Administrator\Desktop\PoisHousingCFS\PoisHousingSSQ\PoisHousingL\poisHousingLF.txt", Encoding.UTF8);

            List<Dictionary<string, string>> obj1 = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(string1);
            //List<Dictionary<string, string>> obj2 = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(string2);
            //List<Dictionary<string, string>> obj3 = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(string3);
            //List<Dictionary<string, string>> obj4 = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(string4);
            //List<Dictionary<string, string>> obj5 = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(string5);
            //List<Dictionary<string, string>> obj6 = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(string6);
            //List<Dictionary<string, string>> obj7 = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(string7);
            //List<Dictionary<string, string>> obj8 = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(string8);
            //List<Dictionary<string, string>> obj9 = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(string9);
            //List<Dictionary<string, string>> obj10 = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(string10);
            //List<Dictionary<string, string>> obj11 = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(string11);
            //List<Dictionary<string, string>> obj12 = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(string12);

            //List<Dictionary<string, string>> objLHSQ = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(stringLHSQ);
            //List<Dictionary<string, string>> objXQSSQ = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(stringXQSSQ);
            //List<Dictionary<string, string>> objLSSQ = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(stringLSSQ);

            string connectionString = "User Id=LBSUSER;Password=LBSPWD;Data Source=10.1.8.17:1521/JJLBS";
            OracleConnection connection = new OracleConnection(connectionString);
            connection.Open();
            for (var i = 0; i < obj1.Count; i++)
            {
                OracleCommand cmd = connection.CreateCommand();

                string sql = $"begin insert into LBS_VILLAGE (VILLAGE_CODE, VILLAGE_NAME, VILLAGE_ADDRESS, VILLAGE_REGION, VILLAGE_TYPE, VILLAGE_X, VILLAGE_Y, VILLAGE_LNG, VILLAGE_LAT, VILLAGE_BOUNDS) values ('{obj1[i]["poiId"]}','{obj1[i]["poiName"]}','{obj1[i]["poiAddress"]}','{obj1[i]["poiRegion"]}','{obj1[i]["poiType"]}','{obj1[i]["poiLng"]}','{obj1[i]["poiLat"]}','{obj1[i]["poiLng"]}','{obj1[i]["poiLat"]}','{obj1[i]["poiBounds"]}');commit;end;";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
       

            //for (var i = 0; i < objLHSQ.Count; i++)
            //{
            //    OracleCommand cmd = connection.CreateCommand();

            //    string sql = $"begin insert into LBS_AJ_BUILDING (BUILDING_NUMBER, BUILDING_ADDRESS, BUILDING_X, BUILDING_Y, BUILDING_LNG, BUILDING_LAT, VILLAGE_ID, BUILDING_REGION, BUILDING_BOUNDS, BUILDING_TYPE) values ('{objLHSQ[i]["poiName"]}','{objLHSQ[i]["poiAddress"]}','{objLHSQ[i]["poiLng"]}','{objLHSQ[i]["poiLat"]}','{objLHSQ[i]["poiLng"]}','{objLHSQ[i]["poiLat"]}','{objLHSQ[i]["poiVillage"]}','{objLHSQ[i]["poiRegion"]}','{objLHSQ[i]["poiBounds"]}','{objLHSQ[i]["poiType"]}');commit;end;";
            //    cmd.CommandText = sql;
            //    cmd.ExecuteNonQuery();
            //}
            //for (var i = 0; i < objLSSQ.Count; i++)
            //{
            //    OracleCommand cmd = connection.CreateCommand();

            //    string sql = $"begin insert into LBS_AJ_BUILDING (BUILDING_NUMBER, BUILDING_ADDRESS, BUILDING_X, BUILDING_Y, BUILDING_LNG, BUILDING_LAT, VILLAGE_ID, BUILDING_REGION, BUILDING_BOUNDS, BUILDING_TYPE) values ('{objLSSQ[i]["poiName"]}','{objLSSQ[i]["poiAddress"]}','{objLSSQ[i]["poiLng"]}','{objLSSQ[i]["poiLat"]}','{objLSSQ[i]["poiLng"]}','{objLSSQ[i]["poiLat"]}','{objLSSQ[i]["poiVillage"]}','{objLSSQ[i]["poiRegion"]}','{objLSSQ[i]["poiBounds"]}','{objLSSQ[i]["poiType"]}');commit;end;";
            //    cmd.CommandText = sql;
            //    cmd.ExecuteNonQuery();
            //}
            connection.Close();
            return View();
        }

        public string Insert2()
        {
            string string1 = System.IO.File.ReadAllText(@"C:\Users\Administrator\Desktop\CFS\L\YBSQ_L.txt", Encoding.UTF8);
            List<Dictionary<string, string>> obj1 = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(string1);
            string connectionString = "User Id=LBSUSER;Password=LBSPWD;Data Source=10.1.8.17:1521/JJLBS";
            OracleConnection connection = new OracleConnection(connectionString);
            for (var i = 0; i < obj1.Count; i++)
            {
                if (obj1[i]["poiParent"].Length != 0)
                    
                {
                    string poiParent = obj1[i]["poiParent"];
                    DataSet ds = new DataSet();
                        try
                        {
                            connection.Open();
                            OracleDataAdapter command = new OracleDataAdapter($"begin insert into LBS_BUILDING lb (CODE, BUILDING_NUMBER, BUILDING_ADDRESS, REGION, TYPE, X, Y, LNG, LAT, BOUNDS, VILLAGE_ID, BUILDING_NAME) values ('{obj1[i]["poiId"]}','{obj1[i]["poiBrief"]}','{obj1[i]["poiAddress"]}','{obj1[i]["poiRegion"]}','{obj1[i]["poiType"]}','{obj1[i]["poiLng"]}','{obj1[i]["poiLat"]}','{obj1[i]["poiLng"]}','{obj1[i]["poiLat"]}','{obj1[i]["poiBounds"]}',(select VILLAGE_ID from LBS_VILLAGE lv WHERE lv.VILLAGE_CODE = '{obj1[i]["poiParent"]}' and rownum<2),'{obj1[i]["poiName"]}');commit;end;", connection);
                            
                            command.Fill(ds, "ds");
                        }
                        catch (OracleException ex)
                        {
                            throw new Exception(ex.Message);
                        }
                        connection.Close();
                } else
                {
                    string poiParent = obj1[i]["poiParent"];
                    DataSet ds = new DataSet();
                    try
                    {
                        connection.Open();
                        OracleDataAdapter command = new OracleDataAdapter($"begin insert into LBS_BUILDING lb (CODE, BUILDING_NUMBER, BUILDING_ADDRESS, REGION, TYPE, X, Y, LNG, LAT, BOUNDS, BUILDING_NAME) values ('{obj1[i]["poiId"]}','{obj1[i]["poiBrief"]}','{obj1[i]["poiAddress"]}','{obj1[i]["poiRegion"]}','{obj1[i]["poiType"]}','{obj1[i]["poiLng"]}','{obj1[i]["poiLat"]}','{obj1[i]["poiLng"]}','{obj1[i]["poiLat"]}','{obj1[i]["poiBounds"]}','{obj1[i]["poiName"]}');commit;end;", connection);

                        command.Fill(ds, "ds");
                    }
                    catch (OracleException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    connection.Close();
                }
                //string sql = $"begin insert into LBS_VILLAGE (VILLAGE_CODE, VILLAGE_NAME, VILLAGE_ADDRESS, VILLAGE_REGION, VILLAGE_TYPE, VILLAGE_X, VILLAGE_Y, VILLAGE_LNG, VILLAGE_LAT, VILLAGE_BOUNDS) values ('{obj1[i]["poiId"]}','{obj1[i]["poiName"]}','{obj1[i]["poiAddress"]}','{obj1[i]["poiRegion"]}','{obj1[i]["poiType"]}','{obj1[i]["poiLng"]}','{obj1[i]["poiLat"]}','{obj1[i]["poiLng"]}','{obj1[i]["poiLat"]}','{obj1[i]["poiBounds"]}');commit;end;";
                
            }
            string state = "inserted";
            return state;
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
