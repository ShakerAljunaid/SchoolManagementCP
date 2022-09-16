using AjialAlsafa.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace AjialAlsafa.Services
{
    public class HelperFunctions
    {
        private string serverKey = "AAAAh0mel_w:APA91bFyoeKs4RHgF-qbDVVJvcMiSQV-RDRVKafGu6QgsPyrKe8i-5Au7GcHXsOjBHK7U-rOgzNkaL_Md0fXxDTjGB-h5O5q1oOgzpj24ehL2D8xtPwn8KibjfoJH8HstKmfy2y1kA0w";
        public String SendMessageFromFirebaseCloud(string topic, string title, List<Message> stg_Messages)
        {
            var result = "-1";
            var webAddr = "https://fcm.googleapis.com/fcm/send";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Headers.Add(HttpRequestHeader.Authorization, "key=" + serverKey);
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                //string strNJson = @"{
                //    $to$: $/topics/"+ topic+ "$,$data$: { $ShortDesc$: $data to payload$, $click_action$: $FLUTTER_NOTIFICATION_CLICK$, $view$: $show_notifications_screen$ },$notification$: {  $title$: $" + title+"$, $text$: $"+content+"$,$sound$:$default$ } }";

                //var cmpStr = Zip(JsonConvert.SerializeObject(stg_Messages));
                string strNJson = @"{    $data$:{ $title$:$" + title + "$,$content$:" + JsonConvert.SerializeObject(stg_Messages) + ",$url$:$myurl$   },   $to$:$/topics/" + topic + "$,   $click_action$: $FLUTTER_NOTIFICATION_CLICK$, }";






                streamWriter.Write(strNJson.Replace('$', '"'));
                streamWriter.Flush();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }

    }
}