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

            ContaBancaria minhaConta = new ContaBancaria(TipoConta.PessoaFisica, "Diego", 600, 100);


            minhaConta.Sacar(600.00);
            minhaConta.Sacar(1.5);
        }
    }
}
