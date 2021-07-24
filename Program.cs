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
            ContaBancaria outraConta = new ContaBancaria(TipoConta.PessoaFisica, "Rose", 0, 1000);

            Console.WriteLine(minhaConta);


            minhaConta.Sacar(200.00);

            minhaConta.Deposito(105);

            minhaConta.Transferir(105, outraConta);

            Console.WriteLine(minhaConta);
            Console.WriteLine(outraConta);
        }
    }
}
