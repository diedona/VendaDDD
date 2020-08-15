﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VendaDDD.Shared.ValueObjects
{
    public class Email
    {
        public string Endereco { get; private set; }

        public Email(string endereco)
        {
            Endereco = endereco;
        }
    }
}