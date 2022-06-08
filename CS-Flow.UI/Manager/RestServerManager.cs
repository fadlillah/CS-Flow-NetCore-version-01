using System;
using System.Net;
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

                HttpListenerResponse response = context.Response;
                SuccessGateIn = _fillingBatchManager.Add(fillingBatch);
                if (SuccessGateIn)
                {
                    //Form1.RealTimeTransaction(transactions);
                    // Construct a response.
                    responseString = "<Transaction/>";
                    byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                    response.ContentType = "text/xml";
                    response.ContentEncoding = Encoding.UTF8;
                    // Get a response stream and write the response to it.
                    response.ContentLength64 = buffer.Length;
                    System.IO.Stream output = response.OutputStream;
                    output.Write(buffer, 0, buffer.Length);
                }
                else
                {
                    response.Close();
                }
            }           
        }
    }
}
