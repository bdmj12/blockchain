using System;

namespace Blockchain
{
    public class Block
    {

        public string hash;
        public string previousHash;
        private string data;
        private long timeStamp; 
        DateTime baseDate = new DateTime(1970, 1, 1);
        public Block(string data, string previousHash)
        {
            this.data = data;
            this.previousHash = previousHash;


            TimeSpan diff = DateTime.Now - baseDate;
            this.timeStamp = (long)(diff.TotalMilliseconds);

                
        }
    }
}
