using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Blockchain
{
    public class MainClass
    {

        public static List<Block> blockchain = new List<Block>();
        public static int difficulty = 2;

        public static void Main(string[] args)

        {
            //add blocks to blockchain list:

            blockchain.Add(new Block("Hi im the first block", "0"));
            Console.WriteLine("Trying to Mine block 1... ");
            blockchain[0].MineBlock(difficulty);

            blockchain.Add(new Block("Yo im the second block", blockchain[blockchain.Count - 1].hash));
            Console.WriteLine("Trying to Mine block 2... ");
            blockchain[1].MineBlock(difficulty);

            blockchain.Add(new Block("Hey im the third block", blockchain[blockchain.Count - 1].hash));
            Console.WriteLine("Trying to Mine block 3... ");
            blockchain[2].MineBlock(difficulty);

            Console.WriteLine("\nBlockchain is Valid: " + IsChainValid());

            var person1 = new Wallet();

            person1.Encrypt("")

            // var blockchainJson = JsonConvert.SerializeObject(blockchain);
           //  Console.WriteLine(blockchainJson);
        }




        public static Boolean IsChainValid()
        {
            Block currentBlock;
            Block previousBlock;
            String hashTarget = new String(new char[difficulty]).Replace('\0', '0');

            //loop through blockchain to check hashes:
            for (int i = 1; i < blockchain.Count; i++)
            {
                currentBlock = blockchain[i];
                previousBlock = blockchain[i - 1];
                //compare registered hash and calculated hash:
                if (!currentBlock.hash.Equals(currentBlock.CalculateHash()))
                {
                    Console.WriteLine("Current Hashes not equal");
                    return false;
                }
                //compare previous hash and registered previous hash
                if (!previousBlock.hash.Equals(currentBlock.previousHash))
                {
                    Console.WriteLine("Previous Hashes not equal");
                    return false;
                }
                //check if hash is solved
                if (!currentBlock.hash.Substring(0, difficulty).Equals(hashTarget))
                {
                    Console.WriteLine("This block hasn't been mined");
                    return false;
                }

            }
            return true;
        }
    }
   
}