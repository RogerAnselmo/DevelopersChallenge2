using API.Models;
using API.OfxParser;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace API.Services
{
    public class OfxService
    {
        private readonly OfxDocumentParser _ofxDocumentParser;

        public OfxService(OfxDocumentParser ofxDocumentParser) => _ofxDocumentParser = ofxDocumentParser;

        public IList<Transaction> TransactionsObj { get; } = new List<Transaction>();

        public virtual IEnumerable<Transaction> ImportFiles(Stream fileStream)
        {
            var ofxDocuments = _ofxDocumentParser.Load(fileStream);
            foreach (var document in ofxDocuments.ToArray())
            {
                var transactions = _ofxDocumentParser.ExtractTransactions(document);
                var newTransactions = transactions.Where(t => !TransactionsObj.Contains(t));
                (TransactionsObj as List<Transaction>)?.AddRange(newTransactions);
            }
            return TransactionsObj;
        }
    }
}
