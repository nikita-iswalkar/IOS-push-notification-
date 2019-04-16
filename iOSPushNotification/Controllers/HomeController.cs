using iOSPushNotification.Models;
using Project.MoonAPNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iOSPushNotification.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Index(Notification obType)
        {
            string strResult = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {

                    try
                    {

                        // int result = 0;
                        //String[] arrayString;
                        //string[] arrMerchantId = MerchantIds.Split(',');
                        string strPushMessage = obType.message;
                        var appDomain = System.AppDomain.CurrentDomain;
                        var basePath = appDomain.BaseDirectory;
                        PushNotification objNo = new PushNotification(true, basePath + "\\jainPanchang_Dev_Push.p12", "1");
                        List<NotificationPayload> p = new List<NotificationPayload>();
                        //  var SplitMessageArray = strPushMessage.Split(new char[] { ':' }, 2); ;
                        //string splitMessage = SplitMessageArray[0].ToString();
                        List<string> strDeviceIds = new List<string>();
                        //for (int i = 0; i < arrMerchantId.Length; i++)
                        //{
                        //    strDeviceIds = GetDeviceIds(MerchantIds, splitMessage);
                        //}
                        //if (strDeviceIds.Count > 0)
                        //{
                        //    for (int j = 0; j < strDeviceIds.Count; j++)
                        //    {
                        //        switch (splitMessage)
                        //        {
                        //            case "Block":
                        //                {
                        //                    var regex = new Regex(Regex.Escape("Block:"));
                        //                    var newText = regex.Replace(strPushMessage, "", 1);
                        //                    p.Add(new NotificationPayload(strDeviceIds[j].ToString(), newText, 0, "default", "Block"));
                        //                    break;
                        //                }
                        //            case "CSynch":
                        //                {

                        //                    var regex2 = new Regex(Regex.Escape("CSynch:"));
                        //                    var newText2 = regex2.Replace(strPushMessage, "", 1);
                        //                    p.Add(new NotificationPayload(strDeviceIds[j].ToString(), newText2, 0, "default", "CSynch"));
                        //                    break;
                        //                }
                        //            default:
                        //                {
                        //                    p.Add(new NotificationPayload(strDeviceIds[j].ToString(), strPushMessage, 0, "default", "DSynch"));
                        //                    break;
                        //                }
                        //        }


                        //    }

                        var payload1 = new NotificationPayload(obType.tokenId, strPushMessage, 10, "default","", "http://hd-wall-papers.com/images/wallpapers/animal-nature-wallpaper/animal-nature-wallpaper-7.jpg");
                        //var payload2 = new NotificationPayload("610f02246c62f99d2b92a7610a7ce2215574fa9139292e7a98b428961b924261", strPushMessage, 12, "default");
                        p.Add(payload1);
                        //p.Add(payload2);


                        string certificatePath = basePath + "\\jainPanchang_Dev_Push.p12";
                        var push = new PushNotification(true, certificatePath, "1");
                        string strfilename = push.P12File;
                        var message1 = push.SendToApple(p);
                        //foreach (var item in message1)
                        //{
                        //    result = 1;
                        //}
                        strResult = "Success";

                    }
                    catch (Exception ef)
                    {
                        strResult = "fail";
                    }
                }
            }
            catch(Exception ex)
            {

            }
            ViewBag.message = strResult;
            return View(obType);
        }

    }
}