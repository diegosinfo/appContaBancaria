using appContaBancaria.Enum;
using System;


namespace appContaBancaria.Entidades
{
    class ContaBancaria
    {
        private TipoConta TipoConta { get; set; }
        private string Nome { get; set; }
        private double Saldo { get; set; }
        private double Limite { get; set; }

        private double LimiteUtilizado { get; set; }
     

        public ContaBancaria(TipoConta tipoConta, string nome, double saldo, double limite)
        {
            TipoConta = tipoConta;
            Nome = nome;
            Saldo = saldo;
            Limite = limite;
            LimiteUtilizado = 0;
        }

        private void ImprimiSaldo()
        {
            Console.WriteLine("Saldo atual da conta de {0} é {1} - Limite Disponivel: {2}", Nome,
                                   LimiteUtilizado == 0.00 ? Saldo.ToString("C") : ((-1) * LimiteUtilizado).ToString("C"), (Limite - LimiteUtilizado).ToString("C"));
        }

        public bool Sacar(double valorSaque)
        {
            bool operacaoRealizada = false;

            //Se há saldo suficiente, não precisa utilizar o limite.
            if(valorSaque <= Saldo)
            {
                Saldo -= valorSaque;
                operacaoRealizada = true;
        
            }
            else if(valorSaque <= (Saldo + (Limite - LimiteUtilizado)))
            {
                if (Saldo > 0.00 && Saldo <= valorSaque)
                {
                    valorSaque -= Saldo;
                    Saldo = 0.00;
                }

                if(valorSaque <= (Limite - LimiteUtilizado))
                {
                    LimiteUtilizado += valorSaque;
                    operacaoRealizada = true;
                }
                else
                {
                    operacaoRealizada = false;
                }
            }


            if (operacaoRealizada)
            {
                ImprimiSaldo();
            }
            else
            {
                Console.WriteLine("Saldo insuficiente!");
            }

            return operacaoRealizada;
        }


        public void Deposito(double valorDepositado)
        {
            if(LimiteUtilizado != 0.00)
            {
                if(valorDepositado >= LimiteUtilizado)
                {
                    valorDepositado -= LimiteUtilizado;
                    LimiteUtilizado = 0.00;
                }
                else
                {
                    LimiteUtilizado -= valorDepositado;
                    valorDepositado = 0.00;
                }
            }

            Saldo += valorDepositado;

            ImprimiSaldo();
        }

        public void Transferir(double valorTransferencia, ContaBancaria contaDestino)
        {
            if(Sacar(valorTransferencia))
            {
                contaDestino.Deposito(valorTransferencia);
            }
        }


        public override string ToString()
        {
            string infoConta = "";

            infoConta += "TipoConta: " + TipoConta + " | ";
            infoConta += "Nome: " + Nome + " | ";
            infoConta += "Saldo: " + (LimiteUtilizado == 0.00 ? Saldo.ToString("C") : ((-1) * LimiteUtilizado).ToString("C")) + " | ";
            infoConta += "Limite: " + Limite.ToString("C");

            return infoConta;
        }
    }


    
}
