﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Consulta_CNPJ.Models
{
    public class CNPJ_DADOS
    {
        [Key]
        public int Id { get; set; }
        public string CNPJ { get; set; }
        public string Nome { get; set; }
        public string Situacao { get; set; }
        public string Tipo { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Municipio { get; set; }
        public string Bairro { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

 
    }

}
