using CARS.Utilities;
using log4net;
using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;



namespace PayTNCDriver
{
    public class DriverPayAPI
    {
        private static int _webRequestTimeOut = int.Parse(ConfigurationManager.AppSettings["WebRequestTimeOut"]);
        private static readonly ILog _logger = new LogHandler().GetLogger();
        private static Stopwatch _stopWatch = new Stopwatch();
        public WebResponse Response { get; set; }

        //private static DateTime _tokenExpiry = DateTime.MinValue;
        private string _tokenCurrent = "0";

        public DriverPayAPI()
        {
            //
            // TODO: Add constructor logic here
            //
            
        }

        public string GetAuthenticationToken()
        {
            Model.APIAuthentication auth = null;
            try
            {
                WebClient client = new WebClient();

                client.Headers.Add("contentType", ConfigurationManager.AppSettings["ContentType"]);
                client.Headers.Add("X-Method-Override", ConfigurationManager.AppSettings["XMethodOverride"]);
                client.Headers.Add("DEVELOPERID", ConfigurationManager.AppSettings["DeveloperID"]);
                client.Headers.Add("DEVELOPERPASSWORD", ConfigurationManager.AppSettings["DeveloperPassword"]);

                string result = client.UploadString(ConfigurationManager.AppSettings["AuthenticationTokenUrl"], "POST", "{}");

                JavaScriptSerializer jss = new JavaScriptSerializer();
                auth = jss.Deserialize<Model.APIAuthentication>(result);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return auth.token;
        }   

        public WebResponse PostWebRequest(string postData, string uriValue)
        {

            // Object to hold web requests
            WebRequest webRequest = null;
            WebResponse httpWebResponse = null;

            _logger.Info("In PostWebRequst(): ");

            try
            {
                // Create a request and pass the URL to receive the post. 
                _logger.Debug("Creating web request for uriValue: " + uriValue);

                webRequest = WebRequest.Create(uriValue);
                webRequest.Timeout = _webRequestTimeOut;

                _logger.Debug("Web Request Timeout Set: " + _webRequestTimeOut.ToString());

                _logger.Debug("Creatied web request for uriValue: " + uriValue);

                // We set the Method property of the request to POST.
                webRequest.Method = "POST";
                _logger.Debug("Set web request as POST: ");

                // We create what is being sent by the POST method and convert it to byte array.
                //string postData = this.GetTextFromXMLFile(filePath);
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                _logger.Debug("Converted into byteArray length: " + byteArray.Length);

                // We set the ContentType of the WebRequest to json.
                webRequest.ContentType = "application/json";
                _logger.Debug("Set content type as : " + "application/json");

                // Set auth token
                string authToken = CurrentAuthorization();
                webRequest.Headers.Add("authenticationtoken", authToken);
                _logger.Debug("Set authentication token as : " + authToken);


                // We set the ContentLength of the WebRequest.
                webRequest.ContentLength = byteArray.Length;
                _logger.Debug("_webRequest.ContentLength: " + webRequest.ContentLength);

                // We get the request stream.
                _logger.Debug("Stopwatch started: ");
                _stopWatch.Start();

                // create the Stream object.
                _logger.Debug("Getting EntityHander PostWebRequest stream object dataStream: ");
                Stream dataStream = webRequest.GetRequestStream();
                _logger.Debug("Created dataStream: ");

                // write the data to the request stream.
                _logger.Debug("Writing dataStream: ");
                dataStream.Write(byteArray, 0, byteArray.Length);

                // Close stream object
                if (dataStream != null)
                {
                    _logger.Debug("Closing the object dataStream: ");
                    dataStream.Close();
                }

                _stopWatch.Stop();
                _logger.Debug("Stopwatch stopped: ");

                _logger.Debug("Elapsed time in making _webRequest.GetRequestStream()(): " + Helper.GetElapsedTime(_stopWatch));

            }
            catch (System.Net.WebException ex)
            {
                _stopWatch.Stop();
                _logger.Debug("Stopwatch stopped in the  WebException block : ");
                _logger.Debug("Elapsed time in making _webRequest.GetRequestStream()(): " + Helper.GetElapsedTime(_stopWatch));

                //LogError(ex);
                _logger.Error("WebException in PostWebRequest(): " + ex.Message);
                _logger.Error("WebException in _webRequest.GetResponse() Stack Trace Info: " + ex.ToString());
            }
            catch (System.NotImplementedException ex)
            {
                _stopWatch.Stop();
                _logger.Debug("Stopwatch stopped in the  NotImplementedExceptionion block : ");
                _logger.Debug("Elapsed time in making _webRequest.GetRequestStream()(): " + Helper.GetElapsedTime(_stopWatch));

                //LogError(ex);
                _logger.Error("NotImplementedException in PostWebRequest(): " + ex.Message);
                _logger.Error("NotImplementedException in _webRequest.GetResponse() Stack Trace Info: " + ex.ToString());
            }
            catch (Exception ex)
            {
                _stopWatch.Stop();
                _logger.Debug("Stopwatch stopped in the Exception block : ");
                _logger.Debug("Elapsed time in making _webRequest.GetRequestStream()(): " + Helper.GetElapsedTime(_stopWatch));

                //LogError(ex);
                _logger.Error("Exception in PostWebRequest(): " + ex.Message);
                _logger.Error("Exception in _webRequest.GetResponse() Stack Trace Info: " + ex.ToString());
            }

            return httpWebResponse = (WebResponse)webRequest.GetResponse();
        }

        public Model.DriverPayLoadResponse LoadCard(Model.DriverPayLoad loadCardRequest, Model.Driver driverList)
        {

            Model.DriverPayLoadResponse loadCardResponse = null;
            JavaScriptSerializer jss = new JavaScriptSerializer();

            try
            {
                WebClient client = new WebClient();
                string json = new JavaScriptSerializer().Serialize(loadCardRequest);
                _logger.Debug("Load Card request json: " + json);
                _logger.Debug("Load Card request json, UserID: " + driverList.CardUserID + " CardProxyNumber: " + driverList.CardProxyNumber);
                string loadCardUrl = String.Format(ConfigurationManager.AppSettings["LoadCardUrl"], driverList.CardUserID, driverList.CardProxyNumber);

                WebResponse httpWebResponse = PostWebRequest(json, loadCardUrl);
                _logger.Debug("Called PostWebRequest() for Driver Pay Card Load: ");
                Stream dataStream = httpWebResponse.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                // Read the api response.
                string responseFromServer = reader.ReadToEnd();
                _logger.Debug("Load Card response json: " + responseFromServer);
                loadCardResponse = jss.Deserialize<Model.DriverPayLoadResponse>(responseFromServer);
            }
            catch (WebException e)
            {
                _logger.Debug("Load Card API Error: " + e.Message);
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    Stream dataStream = ((WebResponse)e.Response).GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    string responseFromServer = reader.ReadToEnd();
                    _logger.Debug("Load Card API Response : " + responseFromServer);
                    loadCardResponse = jss.Deserialize<Model.DriverPayLoadResponse>(responseFromServer);
                    _logger.Debug("Load Card API Response Error Code: " + loadCardResponse.errorDetails[0].errorCode);
                    _logger.Debug("Load Card API Response Error Description: " + loadCardResponse.errorDetails[0].errorDescription);
                }
            }
            finally { jss = null; }
            return loadCardResponse;
        }

        public Model.DriverPayUnloadResponse UnloadCard(Model.DriverPayUnload unloadCardRequest, Model.Driver driverList)
        {

            Model.DriverPayUnloadResponse unloadCardResponse = null;
            JavaScriptSerializer jss = new JavaScriptSerializer();

            try
            {
                WebClient client = new WebClient();
                string json = new JavaScriptSerializer().Serialize(unloadCardRequest);
                _logger.Debug("Unload Card request json: " + json);
                _logger.Debug("Unload Card request json, UserID: " + driverList.CardUserID + " CardProxyNumber: " + driverList.CardProxyNumber);
                string unloadCardUrl = String.Format(ConfigurationManager.AppSettings["UnloadCardUrl"], driverList.CardUserID, driverList.CardProxyNumber);

                WebResponse httpWebResponse = PostWebRequest(json, unloadCardUrl);
                _logger.Debug("Called PostWebRequest() for Driver Pay Card Load: ");
                Stream dataStream = httpWebResponse.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                // Read the api response.
                string responseFromServer = reader.ReadToEnd();
                _logger.Debug("Unload Card response json: " + responseFromServer);
                unloadCardResponse = jss.Deserialize<Model.DriverPayUnloadResponse>(responseFromServer);
            }
            catch (WebException e)
            {
                _logger.Debug("Unload Card API Error: " + e.Message);
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    Stream dataStream = ((WebResponse)e.Response).GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    string responseFromServer = reader.ReadToEnd();
                    _logger.Debug("Unload Card API Response : " + responseFromServer);
                    unloadCardResponse = jss.Deserialize<Model.DriverPayUnloadResponse>(responseFromServer);
                    _logger.Debug("Unload Card API Response Error Code: " + unloadCardResponse.errorDetails[0].errorCode);
                    _logger.Debug("Unload Card API Response Error Description: " + unloadCardResponse.errorDetails[0].errorDescription);
                }
            }
            finally { jss = null; }
            return unloadCardResponse;
        }

        public int BalanceEnquiry(int userid, string proxy)
        {
            Model.DriverPayBalance balanceCardResponse = null;
            JavaScriptSerializer jss = new JavaScriptSerializer();

            try
            {
                WebClient client = new WebClient();
                string authToken = string.Empty;
                //string json = string.Empty;                
                //_logger.Debug("Balance Card request json, UserID: " + userid + " CardProxyNumber: " + proxy);
                string balanceCardUrl = String.Format(ConfigurationManager.AppSettings["BalanceEnquiry"], userid, proxy);
                authToken = GetAuthenticationToken();
                _logger.Debug("Balance Enquiry token: " + authToken);

                client.Headers.Add("X-Method-Override", ConfigurationManager.AppSettings["XMethodOverride"]);
                client.Headers.Add("DEVELOPERID", ConfigurationManager.AppSettings["DeveloperID"]);
                client.Headers.Add("AuthenticationToken", authToken);
                client.Headers.Add("ProgramName", ConfigurationManager.AppSettings["ProgramName"]);

                _logger.Debug("Balance Enquiry request: " + balanceCardUrl);
                string result = client.DownloadString(balanceCardUrl);

                _logger.Debug("Balance Enquiry response: " + result);
                balanceCardResponse = jss.Deserialize<Model.DriverPayBalance>(result);

            }
            catch (WebException e)
            {
                _logger.Debug("Balance Card API Error: " + e.Message);
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    Stream dataStream = ((WebResponse)e.Response).GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    string responseFromServer = reader.ReadToEnd();
                    _logger.Debug("Balance Card API Response : " + responseFromServer);
                    balanceCardResponse = jss.Deserialize<Model.DriverPayBalance>(responseFromServer);
                    _logger.Debug("Balance Card API Response Error Code: " + balanceCardResponse.errorDetails[0].errorCode);
                    _logger.Debug("Balance Card API Response Error Description: " + balanceCardResponse.errorDetails[0].errorDescription);
                }
            }
            finally { jss = null; }
            return balanceCardResponse.accountBal;


        }

        public string CurrentAuthorization()
        {
            if (_tokenCurrent.Equals("0"))
            {
                //_tokenExpiry = DateTime.Now.AddHours(int.Parse(ConfigurationSettings.AppSettings["GenerateToken"])); //GenerateToken
                _tokenCurrent = GetAuthenticationToken();
            }

            return _tokenCurrent;
        }
    }
}
