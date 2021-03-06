﻿using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Xml;
using System.Xml.Serialization;

namespace Remont
{
    public class LicenceDto
    {
        public DateTime ValidUntil { get; set; }
        public static string PublicKey = @"<RSAKeyValue>
<Modulus>s5oxxjZj0LjhAhkjIb1BZV6uPSPqM3/8hpukgsi5xryB7rC7+DIDtKuWXbfqBOu6XeeQEsMQ7tEHF+gwr+eLILGAGJ5D31ENCNm2g9kH5qp3aOEuMgS+7+65cgzy3KjoptwtF9B5tZkj7Ac+5VPTnJoEJOlrhrNQ1kCs3voPG9M=</Modulus>
<Exponent>AQAB</Exponent>
</RSAKeyValue>";
    }

    public class LicenceValidator
    {
        public LicenceValidator()
        {
            var cd = Directory.GetCurrentDirectory();
            foreach (var file in Directory.EnumerateFiles(cd, "*.gh_licence"))
            {
                if (TryLoadLicense(file))
                {
                    if (IsValid)
                    {
                        return;
                    }
                }
            }
        }

        public bool IsValid
        {
            get { return ValidUntil > DateTime.Now; }
        }

        private bool TryLoadLicense(string fileName)

        {

            RSACryptoServiceProvider rsaKey = new RSACryptoServiceProvider();



            rsaKey.FromXmlString(LicenceDto.PublicKey);



            // Create a new XML document.

            XmlDocument xmlDoc = new XmlDocument();



            // Load an XML file into the XmlDocument object.

            xmlDoc.PreserveWhitespace = true;

            xmlDoc.Load(fileName);



            // Verify the signature of the signed XML.

            bool result = VerifyXml(xmlDoc, rsaKey);

            if (!result)

                return false;



            HasLicense = true;

            LicenceDto dto;

            using (var fileStream = File.OpenRead(fileName))

            {

                dto = (LicenceDto)new XmlSerializer(typeof(LicenceDto)).Deserialize(fileStream);

            }




            ValidUntil = dto.ValidUntil;



            return true;

        }

        public DateTime ValidUntil { get; set; }

        public bool HasLicense { get; set; }


        // Verify the signature of an XML file against an asymmetric

        // algorithm and return the result.

        public static Boolean VerifyXml(XmlDocument Doc, RSA Key)

        {

            // Check arguments.

            if (Doc == null)

                throw new ArgumentException("Doc");

            if (Key == null)

                throw new ArgumentException("Key");



            // Create a new SignedXml object and pass it

            // the XML document class.

            SignedXml signedXml = new SignedXml(Doc);



            // Find the "Signature" node and create a new

            // XmlNodeList object.

            XmlNodeList nodeList = Doc.GetElementsByTagName("Signature");



            // Throw an exception if no signature was found.

            if (nodeList.Count <= 0)

            {

                throw new CryptographicException("Verification failed: No Signature was found in the document.");

            }



            // This example only supports one signature for

            // the entire XML document. Throw an exception

            // if more than one signature was found.

            if (nodeList.Count >= 2)

            {

                throw new CryptographicException("Verification failed: More that one signature was found for the document.");

            }



            // Load the first node.

            signedXml.LoadXml((XmlElement)nodeList[0]);



            // Check the signature and return the result.

            return signedXml.CheckSignature(Key);

        }


    }
}
