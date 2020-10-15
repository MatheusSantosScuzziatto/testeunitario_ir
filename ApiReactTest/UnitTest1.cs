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
        public void TestInss1()
        {
            CalcIR calcIR = new CalcIR();
            double desconto_inss = calcIR.calcula_percentual_inss(1000.00);
            Assert.AreEqual(desconto_inss, 7.5);
        }

        [Test]
        public void TestInss2()
        {
            CalcIR calcIR = new CalcIR();
            double desconto_inss = calcIR.calcula_percentual_inss(2000.00);
            Assert.AreEqual(desconto_inss, 9);
        }

        [Test]
        public void TestInss3()
        {
            CalcIR calcIR = new CalcIR();
            double desconto_inss = calcIR.calcula_percentual_inss(3000.00);
            Assert.AreEqual(desconto_inss, 12);
        }

        [Test]
        public void TestInss4()
        {
            CalcIR calcIR = new CalcIR();
            double desconto_inss = calcIR.calcula_percentual_inss(4000.00);
            Assert.AreEqual(desconto_inss, 14);
        }

        [Test]
        public void TestInss5()
        {
            CalcIR calcIR = new CalcIR();
            double desconto_inss = calcIR.calcula_percentual_inss(7000.00);
            Assert.AreEqual(desconto_inss, 713.09);
        }

        [Test]
        public void TestAbatimentoInss1()
        {
            CalcIR calcIR = new CalcIR();
            double salario_inss_abatido = calcIR.abater_inss(1000.00);
            //1000 - ((1000 * 7.5) / 100) == 925
            Assert.AreEqual(salario_inss_abatido, 925);
        }

        [Test]
        public void TestAbatimentoInss2()
        {
            CalcIR calcIR = new CalcIR();
            double salario_inss_abatido = calcIR.abater_inss(2000.00);
            //2000 - ((2000 * 9) / 100) == 1820
            Assert.AreEqual(salario_inss_abatido, 1820);
        }

        [Test]
        public void TestAbatimentoInss3()
        {
            CalcIR calcIR = new CalcIR();
            double salario_inss_abatido = calcIR.abater_inss(3000.00);
            //3000 - ((3000 * 12) / 100) == 2640
            Assert.AreEqual(salario_inss_abatido, 2640);
        }

        [Test]
        public void TestAbatimentoInss4()
        {
            CalcIR calcIR = new CalcIR();
            double salario_inss_abatido = calcIR.abater_inss(4000.00);
            //4000 - ((4000 * 14) / 100) == 3440
            Assert.AreEqual(salario_inss_abatido, 3440);
        }

        [Test]
        public void TestAbatimentoInss5()
        {
            CalcIR calcIR = new CalcIR();
            double salario_inss_abatido = calcIR.abater_inss(7000.00);
            //7000 - 713.09 = 6286.91
            Assert.AreEqual(salario_inss_abatido, 6286.91);
        }

        [Test]
        public void TestFaixaAliquota1()
        {
            CalcIR calcIR = new CalcIR();
            double[] faixa_aliquota = calcIR.calcula_faixa_aliquota(1000.00);
            double faixa = faixa_aliquota[0];
            double aliquota = faixa_aliquota[1];
            Assert.AreEqual(faixa, 7.5);
            Assert.AreEqual(aliquota, 142.80);
        }

        [Test]
        public void TestFaixaAliquota2()
        {
            CalcIR calcIR = new CalcIR();
            double[] faixa_aliquota = calcIR.calcula_faixa_aliquota(2000.00);
            double faixa = faixa_aliquota[0];
            double aliquota = faixa_aliquota[1];
            Assert.AreEqual(faixa, 15);
            Assert.AreEqual(aliquota, 354.80);
        }

        [Test]
        public void TestFaixaAliquota3()
        {
            CalcIR calcIR = new CalcIR();
            double[] faixa_aliquota = calcIR.calcula_faixa_aliquota(3000.00);
            double faixa = faixa_aliquota[0];
            double aliquota = faixa_aliquota[1];
            Assert.AreEqual(faixa, 22.5);
            Assert.AreEqual(aliquota, 636.13);
        }

        [Test]
        public void TestFaixaAliquota4()
        {
            CalcIR calcIR = new CalcIR();
            double[] faixa_aliquota = calcIR.calcula_faixa_aliquota(6000.00);
            double faixa = faixa_aliquota[0];
            double aliquota = faixa_aliquota[1];
            Assert.AreEqual(faixa, 27.5);
            Assert.AreEqual(aliquota, 869.36);
        }

        [Test]
        public void TestCalcIr1()
        {
            //Usar aquele pra multiplos teste pra ficar bonito
            CalcIR calcIR = new CalcIR();
            double ir = calcIR.calcula_ir(3000.00, 0);
            Assert.AreEqual(ir, 78.38);
        }

        [TestCase(1000, 1, 0)]
        [TestCase(2000, 0, 0)]
        [TestCase(3000, 0, 55.20)]
        [TestCase(4000, 3, 75.88)]
        [TestCase(7000, 0, 859.54)]
        public void TestCalcIr1(double salario, int qt_dependentes, double result)
        {
            CalcIR calcIR = new CalcIR();
            double ir = calcIR.calcula_ir(salario, qt_dependentes);
            Assert.AreEqual(ir, result, "Incorreto");

            #region calc
            /*
            1000 - 1
            perc_inss = 7.5
            valor_inss = 75
            salario_liquidado = (1000 - 75) - (189.59 * 1)
            salario_liquidado = 735.41
            faixa = 0
            aliquota = 0
            ISENTO

            2000 - 0
            perc_inss = 9
            valor_inss = 180
            salario_liquidado = (2000 - 180) - 0
            salario_liquidado = 1820
            faixa = 0
            aliquota = 0
            ISENTO

            3000 - 0
            perc_inss = 12
            valor_inss = 360
            salario_liquidado = (3000 - 360) - 0
            salario_liquidado = 2640
            faixa = 7.5
            aliquota = 142.80
            ir_retido = ((2640 * 7.5) / 100) - 142.80
            ir_retido = 55.20

            4000 - 3
            perc_inss = 14
            valor_inss = 560
            salario_liquidado = (4000 - 560) - (189.59 * 3)
            salario_liquidado = 2871.23
            faixa = 15
            aliquota = 354.80
            ir_retido = ((2871.23 * 15) / 100) - 354.80
            ir_retido = 75.88

            7000 - 0
            perc_inss = 713.09
            valor_inss = 713.09
            salario_liquidado = (7000 - 713.09) - 0
            salario_liquidado = 6286.91
            faixa = 27.5
            aliquota = 869.36
            ir_retido = ((6286.91 * 27.5) / 100) - 869.36
            ir_retido = 859.54
            */
            #endregion
        }
    }
}