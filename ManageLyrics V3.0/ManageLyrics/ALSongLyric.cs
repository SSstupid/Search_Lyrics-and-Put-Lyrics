using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows;
using System.Xml;


namespace ManageLyrics
{
    public class ALSongLyric
    {
        private string A = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><SOAP-ENV:Envelope xmlns:SOAP-ENV=\"http://www.w3.org/2003/05/soap-envelope\" xmlns:SOAP-ENC=\"http://www.w3.org/2003/05/soap-encoding\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:ns2=\"ALSongWebServer/Service1Soap\" xmlns:ns1=\"ALSongWebServer\" xmlns:ns3=\"ALSongWebServer/Service1Soap12\">";
        private string B = "<SOAP-ENV:Body><ns1:GetResembleLyricList2><ns1:encData>ENCDATA</ns1:encData><ns1:title>TITLE</ns1:title><ns1:artist>ARTIST</ns1:artist><ns1:pageNo>1</ns1:pageNo></ns1:GetResembleLyricList2></SOAP-ENV:Body></SOAP-ENV:Envelope>";
        private string C = "<SOAP-ENV:Body><ns1:GetLyricByID2><ns1:encData>ENCDATA</ns1:encData><ns1:lyricID>LYRICID</ns1:lyricID></ns1:GetLyricByID2></SOAP-ENV:Body></SOAP-ENV:Envelope>";
        private string D = "http://lyrics.alsong.co.kr/alsongwebservice/service1.asmx";
        private string EncData = "7c2d15b8f51ac2f3b2a37d7a445c3158455defb8a58d621eb77a3ff8ae4921318e49cefe24e515f79892a4c29c9a3e204358698c1cfe79c151c04f9561e945096ccd1d1c0a8d8f265a2f3fa7995939b21d8f663b246bbc433c7589da7e68047524b80e16f9671b6ea0faaf9d6cde1b7dbcf1b89aa8a1d67a8bbc566664342e12";

        public List<LyricBasicInfo> GetLyricsSearch(string aArtist, string aTitle)
        {
            XmlDocument xmlDocument = RequestLyList(A + B, D, aTitle, aArtist);
            List<LyricBasicInfo> lyricBasicInfoList = new List<LyricBasicInfo>();
            try 
            {
                for (int i = 0; i < xmlDocument.ChildNodes[1].ChildNodes[0].ChildNodes[0].ChildNodes[0].ChildNodes.Count; ++i)
                    lyricBasicInfoList.Add(new LyricBasicInfo()
                    {
                        LyricID = Convert.ToInt32(xmlDocument.ChildNodes[1].ChildNodes[0].ChildNodes[0].ChildNodes[0].ChildNodes[i].ChildNodes[0].ChildNodes[0].InnerText),
                        Title = xmlDocument.ChildNodes[1].ChildNodes[0].ChildNodes[0].ChildNodes[0].ChildNodes[i].ChildNodes[1].ChildNodes[0].InnerText,
                        Artist = xmlDocument.ChildNodes[1].ChildNodes[0].ChildNodes[0].ChildNodes[0].ChildNodes[i].ChildNodes[2].ChildNodes[0].InnerText,
                        Album = xmlDocument.ChildNodes[1].ChildNodes[0].ChildNodes[0].ChildNodes[0].ChildNodes[i].ChildNodes[3].ChildNodes[0].InnerText
                    });
            }
            catch(NullReferenceException e)
            {
                MessageBox.Show("No result");
            }
            return lyricBasicInfoList;
        }

        public XmlDocument RequestLyList(string A_0, string A_1, string Artist, string Title)
        {
            XmlDocument? xmlDocument1 = null;
            string str = A_0.Replace("^^", "\"").Replace("TITLE", Artist).Replace("ARTIST", Title).Replace("ENCDATA", EncData);
            WebRequest webRequest;
            try
            {
                webRequest = WebRequest.Create(A_1);
                webRequest.Method = "POST";
                webRequest.ContentType = "application/soap+xml";
                StreamWriter streamWriter = new StreamWriter(webRequest.GetRequestStream());
                streamWriter.WriteLine(str);
                streamWriter.Close();
                Stream responseStream = webRequest.GetResponse().GetResponseStream();
                XmlDocument xmlDocument2 = new XmlDocument();
                xmlDocument2.Load(responseStream);
                xmlDocument1 = xmlDocument2;
            }
            catch { }
            return xmlDocument1;
        }
        #region No using this code

       
        public LyricInfo GetLyricsFromID(int LyricID)
        {
            XmlDocument xmlDocument1 = RequestLyric((A + C.Replace("LYRICID", Convert.ToString(LyricID))).Replace("^^", "'"), D);
            return GetLyricDetail(xmlDocument1);
        }
        public static XmlDocument RequestLyric(string A_0, string A_1)
        {
            XmlDocument xmlDocument1 = (XmlDocument)null;
            string str = A_0.Replace("^^", "\"");
            WebRequest webRequest = (WebRequest)null;
            WebResponse webResponse = (WebResponse)null;
            try
            {
                webRequest = WebRequest.Create(A_1);
                webRequest.Method = "POST";
                webRequest.ContentType = "application/soap+xml";
                StreamWriter streamWriter = new StreamWriter(webRequest.GetRequestStream());
                streamWriter.WriteLine(str);
                streamWriter.Close();
                Stream responseStream = webRequest.GetResponse().GetResponseStream();
                XmlDocument xmlDocument2 = new XmlDocument();
                xmlDocument2.Load(responseStream);
                xmlDocument1 = xmlDocument2;
            }
            finally
            {
                /*webRequest?.GetRequestStream().Close();
                webResponse?.GetResponseStream().Close();*/
            }
            return xmlDocument1;
        }

        public static LyricInfo GetLyricDetail(XmlDocument Xml)
        {
            var lyricInfo = new LyricInfo();
            if (!Xml.HasChildNodes)
                return (LyricInfo)null;
            XmlNodeList childNodes = Xml.ChildNodes[1].ChildNodes[0].ChildNodes[0].ChildNodes;
            if (childNodes[0].Name == "GetLyricByID2Result")
            {
                if (childNodes[1].ChildNodes[0].InnerText == "")
                    return (LyricInfo)null;
                lyricInfo.LyricID = Convert.ToInt32(childNodes[1].ChildNodes[0].InnerText);
                lyricInfo.Title = childNodes[1].ChildNodes[1].InnerText;
                lyricInfo.Artist = childNodes[1].ChildNodes[3].InnerText;
                lyricInfo.Album = childNodes[1].ChildNodes[4].InnerText;
                lyricInfo.Lyric = childNodes[1].ChildNodes[2].InnerText.Replace("<br>", "\r\n");
                lyricInfo.RegisterName = childNodes[1].ChildNodes[5].InnerText;
                lyricInfo.RegisterMail = childNodes[1].ChildNodes[6].InnerText;
                lyricInfo.RegisterHomeURL = childNodes[1].ChildNodes[7].InnerText;
                lyricInfo.RegisterPhone = childNodes[1].ChildNodes[8].InnerText;
                lyricInfo.RegisterComment = childNodes[1].ChildNodes[9].InnerText;
                lyricInfo.ModifierName = childNodes[1].ChildNodes[10].InnerText;
                lyricInfo.ModifierMail = childNodes[1].ChildNodes[11].InnerText;
                lyricInfo.ModifierHomeURL = childNodes[1].ChildNodes[12].InnerText;
                lyricInfo.ModifierPhone = childNodes[1].ChildNodes[13].InnerText;
                lyricInfo.ModifierComment = childNodes[1].ChildNodes[14].InnerText;
                return lyricInfo;
            }
            if (!(childNodes[0].Name == "GetLyric7Result"))
                return (LyricInfo)null;
            lyricInfo.StatusID = Convert.ToInt32(childNodes[0].ChildNodes[0].InnerText);
            lyricInfo.LyricID = Convert.ToInt32(childNodes[0].ChildNodes[1].InnerText);
            lyricInfo.RegistDate = childNodes[0].ChildNodes[2].InnerText;
            lyricInfo.Title = childNodes[0].ChildNodes[3].InnerText;
            lyricInfo.Artist = childNodes[0].ChildNodes[4].InnerText;
            lyricInfo.Album = childNodes[0].ChildNodes[5].InnerText;
            lyricInfo.Lyric = childNodes[0].ChildNodes[8].InnerText.Replace("<br>", "\r\n");
            lyricInfo.RegisterName = childNodes[0].ChildNodes[9].InnerText;
            lyricInfo.RegisterMail = childNodes[0].ChildNodes[10].InnerText;
            lyricInfo.RegisterHomeURL = childNodes[0].ChildNodes[11].InnerText;
            lyricInfo.RegisterPhone = childNodes[0].ChildNodes[12].InnerText;
            lyricInfo.RegisterComment = childNodes[0].ChildNodes[13].InnerText;
            lyricInfo.ModifierName = childNodes[0].ChildNodes[14].InnerText;
            lyricInfo.ModifierMail = childNodes[0].ChildNodes[15].InnerText;
            lyricInfo.ModifierHomeURL = childNodes[0].ChildNodes[16].InnerText;
            lyricInfo.ModifierPhone = childNodes[0].ChildNodes[17].InnerText;
            lyricInfo.ModifierComment = childNodes[0].ChildNodes[18].InnerText;
            return lyricInfo;
        }
     

        #endregion
    }
}
