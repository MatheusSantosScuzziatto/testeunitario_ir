using NUnit.Framework;
using ApiReactBusiness.IR;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            CalcIR calcIR = new CalcIR();
            double ir = calcIR.calcula_ir(3000.00);
            Assert.AreEqual(ir, 78.38);
        }
    }
}