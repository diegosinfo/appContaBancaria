using System;
using appContaBancaria.Entidades;
using appContaBancaria.Enum;

namespace appContaBancaria
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ContaBancaria minhaConta = new ContaBancaria(TipoConta.PessoaFisica, "Diego", 100, 100);


            minhaConta.Sacar(200.00);

            minhaConta.Deposito(105);

        }
    }
}
