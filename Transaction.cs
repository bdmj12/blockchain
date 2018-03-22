using System;
using System.Collections.Generic;

namespace Blockchain
{

    public class Transaction
    {

        public string transactionId; // this is also the hash of the transaction.
        public string sender; // senders address/public key.
        public string recipient; // Recipients address/public key.
        public float value;
        public byte[] signature; // this is to prevent anybody else from spending funds in our wallet.

        public List<TransactionInput> inputs = new List<TransactionInput>();
        public List<TransactionOutput> outputs = new List<TransactionOutput>();

        private static int sequence = 0; // a rough count of how many transactions have been generated. 

        // Constructor: 
        public Transaction(string from, string to, float value, List<TransactionInput> inputs)
        {
            this.sender = from;
            this.recipient = to;
            this.value = value;
            this.inputs = inputs;
        }

        // This Calculates the transaction hash (which will be used as its Id)
        private String calulateHash()
        {
            sequence++; //increase the sequence to avoid 2 identical transactions having the same hash
            return Hash.GetHashSha256(
                    sender +
                    recipient +
                    value.ToString() + 
                    sequence
                    );
        }
    }