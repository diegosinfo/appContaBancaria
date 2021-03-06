using System;
using System.Collections.Generic;
using appContaBancaria.Entidades;
using appContaBancaria.Enum;

namespace appContaBancaria
{
    class Program
    {
        static List<ContaBancaria> listContas = new List<ContaBancaria>();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;

                    case "2":
                        InserirConta();
                        break;

                    case "3":
                        Transferencia();
                        break;

                    case "4":
                        Saque();
                        break;

                    case "5":
                        Deposito();
                        break;

                    case "C":
                        Console.Clear();
                        break;

                    default:
                        Console.WriteLine("Opcao invalida");
                        break;
                }


                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
        }

        private static void Transferencia()
        { 
            Console.Write("Digite a conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite a conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valor = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valor, listContas[indiceContaDestino]);
        }

        private static void Deposito()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valor = double.Parse(Console.ReadLine());

            listContas[indiceConta].Deposito(valor);
        }

        private static void Saque()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valor = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valor);

        }

        private static void ListarContas()
        {
            if(listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }

            for(int i = 0; i < listContas.Count; i++)
            {
                ContaBancaria conta = listContas[i];
                Console.WriteLine("#{0} - {1}", i, conta);
            }

        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.Write("Digite 1 para Conta Física ou 2 para Conta Juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());
         

            Console.Write("Digite o Nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o limite: ");
            double entradaLimite = double.Parse(Console.ReadLine());

            ContaBancaria novaConta = new ContaBancaria((TipoConta)entradaTipoConta, entradaNome, entradaSaldo, entradaLimite);

            listContas.Add(novaConta);

        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar Contas");
            Console.WriteLine("2- Inserir Nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }



    }




}
