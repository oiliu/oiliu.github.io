        #region 根据IP获取地址
        public ActionResult LoginLocation()
        {
            return View();
        }

        [HttpPost]
        public string GetLocation()
        {
            string strIP = GetIP();
            if (string.IsNullOrEmpty(strIP))
            {
                return "{\"errNum\":300202,\"errMsg\":\"IP不存在！\"}";
            }
            string url = "http://apis.baidu.com/apistore/iplookupservice/iplookup";
            string param = "ip=" + strIP;
            string result = request(url, param);
            return result;
        }

        /// <summary>
        /// 发送HTTP请求
        /// </summary>
        /// <param name="url">请求的URL</param>
        /// <param name="param">请求的参数</param>
        /// <returns>请求结果</returns>
        public static string request(string url, string param)
        {
            string strURL = url + '?' + param;
            System.Net.HttpWebRequest request;
            request = (System.Net.HttpWebRequest)WebRequest.Create(strURL);
            request.Method = "GET";
            // 添加header
            request.Headers.Add("apikey", "apikey");
            System.Net.HttpWebResponse response;
            response = (System.Net.HttpWebResponse)request.GetResponse();
            System.IO.Stream s;
            s = response.GetResponseStream();
            string StrDate = "";
            string strValue = "";
            StreamReader Reader = new StreamReader(s, Encoding.UTF8);
            while ((StrDate = Reader.ReadLine()) != null)
            {
                strValue += StrDate + "\r\n";
            }
            return strValue;
        }

        public string GetIP()
        {
            string tempip = "";
            try
            {
                //http://1212.ip138.com/ic.asp
                //http://city.ip138.com/ip2city.asp
                HttpWebRequest wr = (HttpWebRequest)WebRequest.Create("http://1212.ip138.com/ic.asp");
                Stream s = wr.GetResponse().GetResponseStream();
                StreamReader sr = new StreamReader(s, Encoding.Default);
                string all = sr.ReadToEnd(); //读取网站的数据

                int start = all.IndexOf("[") + 1;
                int end = all.IndexOf("]", start);
                tempip = all.Substring(start, end - start);
                sr.Close();
                s.Close();
            }
            catch
            {
            }
            return tempip;
        }
        #endregion
