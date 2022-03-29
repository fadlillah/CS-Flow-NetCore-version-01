namespace CS_Flow.Models
{
    public class FillingBatch
    {
        public int id { get; set; }
        public string order_id { get; set; }

        public int batch_id { get; set; }
        public int preset { get; set; }
        public string product { get; set; }
        public string filling_point { get; set; }
        public int status { get; set; }
        public string pin { get; set; }
        public string scancode { get; set; }
        public string truck { get; set; }
        public int gatein_time { get; set; }
        public int gateout_time { get; set; }

    }
}