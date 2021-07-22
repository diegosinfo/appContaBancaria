using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using appContaBancaria.Enum;

namespace appContaBancaria.Entidades
{
    class ContaBancaria
    {
       private TipoConta TipoConta { get; set; }
        
        private string Nome { get; set; }

        private double Saldo { get; set; }

        private double Credito { get; set; }

        public ContaBancaria(TipoConta tipoConta, string nome, double saldo, double credito)
        {
            TipoConta = tipoConta;
            Nome = nome;
            Saldo = saldo;
            Credito = credito;
        }
    }
}
