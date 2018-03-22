using System;

namespace Blockchain
{
    public class Block
    {

        public string hash;
        public string previousHash;
        private string data;
        private long timeStamp;
        private int nonce;

        DateTime baseDate = new DateTime(1970, 1, 1);

        public Block(string data, string previousHash)
        {
            this.data = data;
            this.previousHash = previousHash;


            TimeSpan diff = DateTime.Now - baseDate;
            this.timeStamp = (long)(diff.TotalMilliseconds);

            this.hash = CalculateHash();

        }

        public string CalculateHash()
        {
            string CalculatedHash = Hash.GetHashSha256(
                previousHash + 
                timeStamp.ToString() + 
                nonce.ToString() +
                data
            );
            return CalculatedHash;
        }

        public void MineBlock(int difficulty) {
            string target = new string(new char[difficulty]).Replace("\0", "0");
            while(!hash.Substring(0,difficulty).Equals(target)){
                nonce++;
                hash = CalculateHash();
            }
            Console.WriteLine("Block Mined! : " + hash);
        }
    }
}