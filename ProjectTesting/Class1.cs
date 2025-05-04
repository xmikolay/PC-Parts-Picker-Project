using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OODProject;

namespace ProjectTesting
{
    public class Class1
    {
        [TestCase("€199.99", 199.99)]
        [TestCase("$0.00", 0.00)]
        [TestCase("  €50.25", 50.25)]
        [TestCase("300", 300.00)]
        [TestCase("invalid", 0.00)]
        public void ReturnsCorrectPrice(string input, decimal expected)
        {
            var result = ParsePrice.GetPrice(input);
            Assert.That(expected, Is.EqualTo(result));
        }


        [TestCase("Intel i9", "RTX 4080", "32GB", true)]
        [TestCase("Intel i5", "", "32GB", false)]
        [TestCase("", "RTX 4090", "64GB", false)]
        [TestCase("Ryzen 7", "RX 7900XTX", "", false)]
        public void IsBuildComplete(string cpu, string gpu, string ram, bool expected)
        {
            var build = new ComponentNames
            {
                CPU = cpu,
                GPU = gpu,
                RAM = ram
            };

            var result = BuildValidator.IsComplete(build);
            Assert.That(expected, Is.EqualTo(result));
        }

        [TestCase("AM5", "AM5", true)]
        [TestCase("AM5", "LGA1700", false)]
        public void ArePartsCompatible(string socket1, string socket2, bool compatible)
        {
            var currentBuild = new CurrentBuild
            {
                CPUPlatform = socket1,
                MBPlatform = socket2
            };

            var result = CompatibilityChecker.AreCompatible(currentBuild);
            Assert.That(result, Is.EqualTo(compatible));
        }

        public static class ParsePrice
        {
            public static decimal GetPrice(string textBlock)
            {
                decimal price = 0;
                if (decimal.TryParse(textBlock.Replace("€", "").Replace("$", ""), out price))
                {
                    return price;
                }
                else
                {
                    return 0;
                }
            }
        }

        public static class BuildValidator
        {
            public static bool IsComplete(ComponentNames build)
            {
                if (string.IsNullOrEmpty(build.CPU) || string.IsNullOrEmpty(build.GPU) || string.IsNullOrEmpty(build.RAM))
                {
                    return false;
                }
                return true;
            }
        }

        public static class CompatibilityChecker
        {
            public static bool AreCompatible(CurrentBuild currentBuild)
            {
                if (currentBuild.CPUPlatform != currentBuild.MBPlatform)
                {           
                    return false;
                }
                else
                { return true; }                
            }
        }
    }
}