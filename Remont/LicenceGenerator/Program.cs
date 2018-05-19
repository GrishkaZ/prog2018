using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Remont;

namespace LicenceGenerator
{
    class Program
    {
        private static void GenerateNewKeyPair()

        {

            string withSecret;
            string woSecret;
            using (var rsaCsp = new RSACryptoServiceProvider())

            {

                withSecret = rsaCsp.ToXmlString(true);
                woSecret = rsaCsp.ToXmlString(false);

            }

            File.WriteAllText("private.xml", withSecret);
            File.WriteAllText("public.xml", woSecret);

            Console.WriteLine(withSecret);
            Console.WriteLine();
            Console.WriteLine(woSecret);

        }
        static void Main(string[] args)
        {
            if (args.Any(a => a == "--generate"))
            {
                GenerateNewKeyPair();
            }

            var dto = new LicenceDto()
            {
                ValidUntil = DateTime.Now.AddDays(5)
            };

            var fileName = string.Join("", DateTime.Now.ToString().Where(c => char.IsDigit(c)));
            new LicenceGenerator().CreateLicenseFile(dto, fileName + ".gh_licence");
        }
    }
    class LicenceGenerator
    {
        private static string PrivateKey = @"< RSAKeyValue >
            < Modulus > s5oxxjZj0LjhAhkjIb1BZV6uPSPqM3 / 8hpukgsi5xryB7rC7+DIDtKuWXbfqBOu6XeeQEsMQ7tEHF+gwr+eLILGAGJ5D31ENCNm2g9kH5qp3aOEuMgS+7+65cgzy3KjoptwtF9B5tZkj7Ac+5VPTnJoEJOlrhrNQ1kCs3voPG9M=</Modulus>
<Exponent>AQAB</Exponent>
<P>+DTbpin9aS0I4c8b9jR9aU2cjK7901rniRIZTT0OI8ZulMuh4F4js1a5Cma7YswmfOu8iAUgZSmwEPYWRrIIUQ==</P>
<Q>uT3hTrwFDNqdnc6liOO1O9Ej1RlEgu0JuqXNTjfzDh7koqCzj9NJh/04qO4zF77ZxQB8E2RrZ2FnUX4Ga2L84w==</Q>
<DP>PNqYz9CTtOm5t8NTk7Wi2eKRc1ykFuG+yriJQ4qooNTR3+FdOulZz2p/y7EMWFi9Rvt1KdQ38RWbeU0cgRC9QQ==</DP>
<DQ>WinHb8ZOgvopu7Tol5+WCB583W1mDoAHu0SWkJrlABuDV7D2lWvXH4zeNkNytP0dDCl3Ow0mxfQAEQdRYpWU1w==</DQ>
<InverseQ>AoeuFI34f85KsjquyftG5bgCJspv8irZr4eJE+Ze7fDw1KqVAJK/pVf3AxmyrHODPuKTddKdzjQpqzT5wm8Z1w==</InverseQ>
<D>IC/VFcGvl7taT8bzfdtt+d3C+iASm9InDnScQff5Gz2zR3SS60MDWQCbPQZ1wRYB20xhjIs64KHDVKx+9TdYvmCDBFdRBACYcWzWHRaDF88ReXkDarXoi3FYIIZhWNB2XyoahXs92QI/AIzDVELSeXpsJyQ/xJhQ/gjTQTYnAqE=</D>
</RSAKeyValue>";
        public void CreateLicenseFile(LicenceDto dto, string fileName)
        {

            var ms = new MemoryStream();

            new XmlSerializer(typeof(LicenceDto)).Serialize(ms, dto);



            // Create a new CspParameters object to specify

            // a key container.



            // Create a new RSA signing key and save it in the container.

            RSACryptoServiceProvider rsaKey = new RSACryptoServiceProvider();

            rsaKey.FromXmlString(PrivateKey);



            // Create a new XML document.

            XmlDocument xmlDoc = new XmlDocument();



            // Load an XML file into the XmlDocument object.

            xmlDoc.PreserveWhitespace = true;

            ms.Seek(0, SeekOrigin.Begin);

            xmlDoc.Load(ms);



            // Sign the XML document.

            SignXml(xmlDoc, rsaKey);



            // Save the document.

            xmlDoc.Save(fileName);



        }



        // Sign an XML file.

        // This document cannot be verified unless the verifying

        // code has the key with which it was signed.

        public static void SignXml(XmlDocument xmlDoc, RSA Key)

        {

            // Check arguments.

            if (xmlDoc == null)

                throw new ArgumentException("xmlDoc");

            if (Key == null)

                throw new ArgumentException("Key");



            // Create a SignedXml object.

            SignedXml signedXml = new SignedXml(xmlDoc);



            // Add the key to the SignedXml document.

            signedXml.SigningKey = Key;



            // Create a reference to be signed.

            Reference reference = new Reference();

            reference.Uri = "";



            // Add an enveloped transformation to the reference.

            XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();

            reference.AddTransform(env);



            // Add the reference to the SignedXml object.

            signedXml.AddReference(reference);



            // Compute the signature.

            signedXml.ComputeSignature();



            // Get the XML representation of the signature and save

            // it to an XmlElement object.

            XmlElement xmlDigitalSignature = signedXml.GetXml();



            // Append the element to the XML document.

            xmlDoc.DocumentElement.AppendChild(xmlDoc.ImportNode(xmlDigitalSignature, true));



        }
    }
}


