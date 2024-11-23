﻿using ProductionOrderSEQUOR.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionOrderSEQUOR.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public byte[] passwordHash { get; private set; }   
        public byte[] passwordSalt { get; private set; }

        public Usuario(int id, string name, string email)
        {
            DomainExceptionValidation.When(id < 0, "O id não pode ser negativo.");
            Id = id;
            ValidateDomain(name, email);
        }
        public Usuario(string name, string email)
        {
            ValidateDomain(name, email);
        }

        public void AlterarSenha(byte[] passwordHash, byte[] passwordSalt)
        {
            passwordHash = passwordHash;
            passwordSalt = passwordSalt;
        }

        private void ValidateDomain(string name, string email)

        {
            DomainExceptionValidation.When(name == null, "O nome é obrigatório.");
            DomainExceptionValidation.When(email == null, "O email é obrigatório.");
            DomainExceptionValidation.When(name.Length > 250, "O nome não pode ultrapassar 250 caracteres.");
            DomainExceptionValidation.When(email.Length > 200, "O email não pode ultrapassar 250 caracteres.");

            Name = name;
            Email = email;  
        }
    }
}
