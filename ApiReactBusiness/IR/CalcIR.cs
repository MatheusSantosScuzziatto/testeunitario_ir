using System;
using System.Collections.Generic;
using System.Text;

namespace ApiReactBusiness.IR
{
    public class CalcIR
    {
        public double calcula_percentual_inss(double meu_salario)
        {
            double desconto_inss = 0;

            if (meu_salario <= 1045)
            {
                desconto_inss = 7.5;
            }
            else if (meu_salario >= 1045.01 && meu_salario <= 2089.60)
            {
                desconto_inss = 9;
            }
            else if (meu_salario >= 2089.61 && meu_salario <= 3134.40)
            {
                desconto_inss = 12;
            }
            else if (meu_salario >= 3134.41 && meu_salario <= 6101.06)
            {
                desconto_inss = 14;
            }
            else
            {
                desconto_inss = 713.09;
            }

            return desconto_inss;
        }

        public double abater_inss(double meu_salario)
        {
            double desconto_inss = calcula_percentual_inss(meu_salario);
            double valor_inss = desconto_inss != 713.09 ? (meu_salario * desconto_inss) / 100 : 713.09;
            double meu_salario_liquidado = meu_salario - valor_inss;

            return meu_salario_liquidado;
        }

        public double[] calcula_faixa_aliquota(double meu_salario_liquidado)
        {
            double[] faixa_aliquota = new double[2];

            double percent_faixa = 0;
            double aliquota_faixa = 0;

            if(meu_salario_liquidado < 1903.99)
            {
                percent_faixa = 0;
                aliquota_faixa = 0;
            }
            else if (meu_salario_liquidado >= 1903.99 && meu_salario_liquidado <= 2826.65)
            {
                percent_faixa = 7.5;
                aliquota_faixa = 142.80;
            }
            else if (meu_salario_liquidado >= 2826.66 && meu_salario_liquidado <= 3751.05)
            {
                percent_faixa = 15;
                aliquota_faixa = 354.80;
            }
            else if (meu_salario_liquidado >= 3751.06 && meu_salario_liquidado <= 4664.68)
            {
                percent_faixa = 22.5;
                aliquota_faixa = 636.13;
            }
            else if (meu_salario_liquidado >= 4664.69)
            {
                percent_faixa = 27.5;
                aliquota_faixa = 869.36;
            }

            faixa_aliquota[0] = percent_faixa;
            faixa_aliquota[1] = aliquota_faixa;

            return faixa_aliquota;
        }

        public double calcula_ir(double meu_salario, int qt_dependentes)
        {
            //Abatimento de INSS e dedução dos dependentes legais
            double meu_salario_liquidado = abater_inss(meu_salario);
            meu_salario_liquidado -= (189.59 * qt_dependentes);

            //Definir percentual faixa e alíquota da base cálculo
            double[] faixa_aiquota = calcula_faixa_aliquota(meu_salario_liquidado);
            double percent_faixa = faixa_aiquota[0];
            double aliquota_faixa = faixa_aiquota[1];

            //IRRF
            double ir_retido = ((meu_salario_liquidado * percent_faixa) / 100) - aliquota_faixa;

            return ir_retido;
        }
    }
}
