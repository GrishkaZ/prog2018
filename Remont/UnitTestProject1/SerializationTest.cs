using System;
using System.Collections.Generic;
using System.IO;
using Remont;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class SerializationTests
    {
        [TestMethod]
        public void End2EndSerializationTest()
        {
            var dto = new OrderRequestDto
            {
                Filled = new TimeOfRepair()
                {
                    Filled = DateTime.Today,
                },
                FullName = "Grigoriy Zalyatskiy",
                DescriptionOfBreakageDevice = new Device()
                {
                    BrokenDevice = Apparat.Kettle,
                    Breakage = new List<Breakage>()
                    {
                       new Breakage()
                       {
                           BreakageType = DamageType.Burned,
                           Description = "Cгорел датчик температуры"
                       },
                      new Breakage()
                       {
                           BreakageType = DamageType.Physical,
                           Description = "Оторвалась крышка"
                       },
                    }
                },
                Price = new Payment()
                {
                    Currency = Currency.Bitcoins,
                    Price = 0.002,
                },
                Repair = new AdditionalRequirements()
                {
                    TimeOfRepair = new TimeOfRepair() { Days = 7, },
                    BuySomeDetailsYourself = false,
                    AdditionalRequests = "Почините, пожалуйста чайник, приходится кипятить воду в кастрюльке без него :("
                }
            };

            var tempFileName = Path.GetTempFileName();
            try
            {
                RideDtoHelper.WriteToFile(tempFileName, dto);
                var readDto = RideDtoHelper.LoadFromFile(tempFileName);
                Assert.AreEqual(dto.FullName, readDto.FullName);
                Assert.AreEqual(dto.Price.Price, readDto.Price.Price);
            }
            finally
            {
                File.Delete(tempFileName);
            }
        }
    }
}
