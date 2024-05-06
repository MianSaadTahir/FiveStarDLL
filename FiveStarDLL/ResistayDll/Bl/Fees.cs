using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResistayDLL.Bl
{
    public class Fees
    {
        private int FeeAmount;
        private string Date;

        public Fees() { }
        public Fees(int FeeAmount,string Date) 
        {
            this.FeeAmount = FeeAmount;
            this.Date = Date;
        }
        public string GetDate() { return Date; }
        public void SetDate(string Date) { this.Date = Date; }
        public int GetFeeAmount() { return FeeAmount;}
        public void SetFeeAmount(int FeeAmount) {  this.FeeAmount = FeeAmount; }
    }
}
