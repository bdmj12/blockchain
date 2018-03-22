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

        public Block(string data, string previousHash)
        {
            this.data = data;
            this.previousHash = previousHash;


            this.timeStamp = DateTime.Now.Ticks;

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