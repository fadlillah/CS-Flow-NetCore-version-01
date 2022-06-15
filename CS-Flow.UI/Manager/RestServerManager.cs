using System;
using System.Net;
using System.Xml;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_Flow.Models;

namespace CS_Flow.Manager
{
    public class RestServerManager
    {
        private HttpListener _listener;
        private FillingBatchManager _fillingBatchManager = new FillingBatchManager();
        private FillingSessionManager _fillingSessionManager = new FillingSessionManager();
        private bool SuccessGateIn = false;
        private Task taskListener;
        public RestServerManager()
        {

        }
        public RestServerManager(string url)
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add(url);
        }
        public void startConnection()
        {
            if (!_listener.IsListening)
            {
                _listener.Start();
            }            
        }
        private void ResponseServer(HttpListenerResponse response, string textResponse)
        {
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(textResponse);
            response.ContentType = "text/xml";
            response.ContentEncoding = Encoding.UTF8;
            // Get a response stream and write the response to it.
            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
        }
        private XElement CreateDocXML(List<TransactionResponse> transactionResponses)
        {
            XElement transactionList = new XElement("transactionlist");
            XElement elementTransaction = new XElement("transaction");
            XElement elementSessionArray = new XElement("session_array");
            foreach (TransactionResponse ts in transactionResponses)
            {
                elementTransaction.SetAttributeValue("actualloaded", ts.actualloaded);
                elementTransaction.SetAttributeValue("batchcnt", ts.batchcnt);
                elementTransaction.SetAttributeValue("batchnumber", ts.batchnumber);
                elementTransaction.SetAttributeValue("completed", ts.completed);
                elementTransaction.SetAttributeValue("dens", ts.dens);
                elementTransaction.SetAttributeValue("destinationID", ts.destinationID);
                elementTransaction.SetAttributeValue("destinationcompany", ts.destinationcompany);
                elementTransaction.SetAttributeValue("endtotal", ts.endtotal);
                elementTransaction.SetAttributeValue("fpname", ts.fpname);
                elementTransaction.SetAttributeValue("gatelogid", ts.gatelogid);
                elementTransaction.SetAttributeValue("id", ts.id);
                elementTransaction.SetAttributeValue("measured_dens", ts.measured_dens);
                elementTransaction.SetAttributeValue("measured_temp1", ts.measured_temp1);
                elementTransaction.SetAttributeValue("measured_temp2", ts.measured_temp2);
                elementTransaction.SetAttributeValue("multibatch", ts.multibatch);
                elementTransaction.SetAttributeValue("preset", ts.preset);
                elementTransaction.SetAttributeValue("product", ts.product);
                elementTransaction.SetAttributeValue("starttime", ts.starttime);
                elementTransaction.SetAttributeValue("starttotal", ts.starttotal);
                elementTransaction.SetAttributeValue("stoptime", ts.stoptime);
                elementTransaction.SetAttributeValue("temp", ts.temp);
                elementTransaction.SetAttributeValue("transporter", ts.transporter);
                elementTransaction.SetAttributeValue("transporterID", ts.transporterID);
                elementTransaction.SetAttributeValue("transportertype", ts.transportertype);

                XElement propElement;
                if (ts.transactionResponseDetails != null)
                {
                    foreach (TransactionResponseDetail trd in ts.transactionResponseDetails)
                    {
                        XElement session = new XElement("session");
                        for (int i = 0; i < trd.GetType().GetProperties().Length; i++)
                        {
                            var property = trd.GetType().GetProperties()[i];
                            propElement = new XElement(property.Name, new XAttribute("value", trd.GetType().GetProperty(property.Name).GetValue(trd, null)));
                            session.Add(propElement);

                        }
                        elementSessionArray.Add(session);
                    }
                }
                
            }
            elementTransaction.Add(elementSessionArray);
            transactionList.Add(elementTransaction);
            return transactionList;
        }
        public void realtimeListening()
        {
            while (true)
            {
                if (!_listener.IsListening)
                {
                    _listener.Start();
                }
                HttpListenerContext context = _listener.GetContext();
                string responseString = "";
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;
                string localPath = request.Url.LocalPath;
                #region new Transaction
                if (localPath == "/newtransaction")
                {
                    //new Filling Batch
                    FillingBatch fillingBatch = new FillingBatch();
                    fillingBatch.order_id = request.QueryString.GetValues("id")[0];
                    fillingBatch.preset = Convert.ToInt32(request.QueryString.GetValues("preset")[0]);
                    fillingBatch.filling_point = request.QueryString.GetValues("fpname")[0];
                    fillingBatch.pin = request.QueryString.GetValues("pin")[0];
                    fillingBatch.truck = request.QueryString.GetValues("transporterID")[0];
                    fillingBatch.scancode = request.QueryString.GetValues("truckserialnumber")[0];
                    fillingBatch.product = request.QueryString.GetValues("product")[0];
                    fillingBatch.status = 0;
                    fillingBatch.batch_id = 1;
                    fillingBatch.gatein_time = Convert.ToInt32(DateTimeOffset.Now.ToUnixTimeSeconds());
                    fillingBatch.gateout_time = 0;
                    SuccessGateIn = _fillingBatchManager.Add(fillingBatch);
                    if (SuccessGateIn)
                    {
                        //Form1.RealTimeTransaction(transactions);
                        // Construct a response.
                        responseString = "<Transaction/>";
                        ResponseServer(response, responseString);
                    }
                    else
                    {
                        response.Close();
                    }
                }
                #endregion
                //
                #region Get transaction
                else if (localPath == "/gettransactiont")
                {
                    string TransPorterId = request.QueryString.GetValues("transporterid")[0];
                    FillingBatch fillingBatch = new FillingBatch();
                    FillingSession flSession = new FillingSession();
                    List<TransactionResponse> transactionResponses = new List<TransactionResponse>();
                    fillingBatch = _fillingBatchManager.getByTransporterId(TransPorterId);                    
                    if (fillingBatch != null)
                    {
                        if (fillingBatch.status != 5)
                        {
                            TransactionResponse tsResponse = new TransactionResponse();
                            flSession = _fillingSessionManager.getLoaded(fillingBatch.id);
                            if (fillingBatch.status == 4)
                            {
                                tsResponse.completed = true;
                            }
                            else
                            {
                                tsResponse.completed = false;
                            }
                            
                            tsResponse.batchcnt = fillingBatch.batch_id;
                            tsResponse.pin = fillingBatch.pin;
                            tsResponse.preset = fillingBatch.preset;
                            tsResponse.product = fillingBatch.product;
                            tsResponse.transporterID = fillingBatch.truck;
                            tsResponse.transporterID = fillingBatch.order_id;
                            tsResponse.id = fillingBatch.order_id;
                            if (flSession != null)
                            {
                                tsResponse.dens = (double)flSession.density;
                                tsResponse.fpname = fillingBatch.filling_point;

                                tsResponse.measured_dens = flSession.measured_density;
                                tsResponse.measured_temp1 = flSession.measured_temperature_1;
                                tsResponse.measured_temp2 = flSession.measured_temperature_2;
                                tsResponse.actualloaded = flSession.loaded;
                                if (flSession.interrupted != false)
                                {
                                    tsResponse.multibatch = true;
                                }
                                else
                                {
                                    tsResponse.multibatch = false;
                                }

                                tsResponse.starttime =convertToOA(flSession.start_time);
                                tsResponse.starttotal = flSession.start_totalizer;
                                tsResponse.stoptime = flSession.stop_time;
                                tsResponse.temp = (double)flSession.temperature;
                                TransactionResponseDetail tsResponseDetail = new TransactionResponseDetail();
                                tsResponseDetail.fpname = fillingBatch.filling_point;
                                tsResponseDetail.starttime = convertToOA(flSession.start_time);
                                tsResponseDetail.stoptime = convertToOA(flSession.stop_time);
                                tsResponseDetail.preset = fillingBatch.preset;
                                tsResponseDetail.loaded = flSession.loaded;
                                tsResponseDetail.starttotal = flSession.stop_totalizer;
                                tsResponseDetail.endtotal = flSession.stop_totalizer;
                                tsResponseDetail.starttotal2 = flSession.stop_totalizer_2;
                                tsResponseDetail.endtotal2 = flSession.stop_totalizer_2;
                                tsResponseDetail.interrupted = flSession.interrupted;
                                tsResponse.transactionResponseDetails.Add(tsResponseDetail);
                            }
                            transactionResponses.Add(tsResponse);
                            responseString = CreateDocXML(transactionResponses).ToString();
                        }
                        else
                        {
                            responseString = "<Transaction/>";
                        }
                        ResponseServer(response, responseString);
                    }
                    #endregion
                }
                #region Remove Transaction
                else if (localPath == "/deletetransaction")
                {
                    string id = request.QueryString.GetValues("id")[0];
                    FillingBatch fillingBatch = new FillingBatch();
                    fillingBatch = _fillingBatchManager.getByOrderId(id);
                    if(fillingBatch != null)
                    {
                        bool succes = _fillingBatchManager.UpdateGateOut(id);
                        if (succes)
                        {
                            responseString = "<Transaction/>";
                            ResponseServer(response, responseString);
                        }
                        else
                        {
                            response.Close();
                        }
                        
                    }
                    else
                    {
                        response.Close();
                    }
                }
                #endregion

            }
        }
        public double convertToOA(int unixTimeStamp)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime.ToOADate();
        }
    }
}
