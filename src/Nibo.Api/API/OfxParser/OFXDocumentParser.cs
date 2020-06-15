using Api.OfxModels;
using API.Extensions;
using API.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace API.OfxParser
{
    public class OfxDocumentParser
    {
        public virtual IEnumerable<OfxDocument> Load(params Stream[] streams) =>
            streams.Select(Load).ToList();

        public virtual IEnumerable<Transaction> ExtractTransactions(OfxDocument ofxDocument) =>
            ofxDocument
                .Bank
                .TransactionWrapper
                .StmTrs
                .TranList
                .Transactions
                .Select(x => x.ToTransaction());

        private static OfxDocument Load(Stream stream)
        {
            using var reader = new StreamReader(stream, Encoding.Default);
            return GetOfxContent(reader.ReadToEnd());
        }

        private static string ConvertToXml(string sgml)
        {
            using var reader = new StringReader(sgml);
            string line;

            var stringBuilder = new StringBuilder();

            while ((line = reader.ReadLine()) != null)
            {
                if (line.EndsWith(">", StringComparison.CurrentCulture))
                {
                    stringBuilder.AppendLine(line);
                    continue;
                }

                var tagStart = line.IndexOf("<", StringComparison.CurrentCultureIgnoreCase);
                var tagEnd = line.IndexOf(">", StringComparison.CurrentCultureIgnoreCase);

                var tagName = line.Substring(tagStart + 1, (tagEnd - tagStart) - 1);

                stringBuilder.AppendLine(line.Contains($"</{tagName}>") ? line : $"{line}</{tagName}>");
            }

            return stringBuilder.ToString();
        }

        private static OfxDocument GetOfxContent(string data)
        {
            var xmlDocument = new XmlDocument();

            var ofx = data.Remove(0, data.IndexOf("<", StringComparison.CurrentCultureIgnoreCase));

            ofx = ConvertToXml(ofx);
            xmlDocument.LoadXml(ofx);

            var reader = new StringReader(xmlDocument.InnerXml);
            var result = (OfxDocument)new XmlSerializer(typeof(OfxDocument))
                .Deserialize(reader);

            return result;
        }
    }
}
