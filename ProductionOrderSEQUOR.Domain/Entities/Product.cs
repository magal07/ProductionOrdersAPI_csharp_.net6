﻿using ProductionOrderSEQUOR.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProductionOrderSEQUOR.Domain.Entities
{
    public class Product
    {

        public int Id { get; private set; }
        public string ProductCode { get; private set; } 
        public string ProductDescription { get; private set; } 
        public string Image { get; private set; } 
        public decimal CycleTime { get;  set; }

        public ICollection<Production> Productions { get; set; }

        public Product() // vazio para dar continuidade 
        {

        }
        public Product(int id, string productCode, string productDescription, string image, decimal cycleTime)

        {
            DomainExceptionValidation.When(id < 0, "O Id do Cliente deve ser positivo.");

            ProductCode = productCode;
            ProductDescription = productDescription;
            Image = image;
            CycleTime = cycleTime;

            {
                Id = id;
                ValidateDomain(productCode, productDescription, image, cycleTime);
            }
        }

        public Product(string productCode, string productDescription, string image, decimal cycleTime)
        {
                ValidateDomain(productCode, productDescription, image, cycleTime);
        }

        public void Update(string productCode, string productDescription, string image, decimal cycleTime)
        {
            ValidateDomain(productCode, productDescription, image, cycleTime);  
        }
        public void ValidateDomain(string productCode, string productDescription, string image, decimal cycleTime)
        {
            DomainExceptionValidation.When(productCode.Length > 200, "O produto deve ter no máximo 200 caracteres");
            DomainExceptionValidation.When(productDescription.Length > 250, "A descrição do produto deve ter no máximo 250 caracteres");
            DomainExceptionValidation.When(image.Length > 500, "A imagem do produto deve ter no máximo '500' caracteres");
            DomainExceptionValidation.When(cycleTime <= 0, "O ciclo de tempo deve ser maior que zero.");

            ProductCode = productCode;
            ProductDescription = productDescription;
            Image = image;
            CycleTime = cycleTime;
        }
    }
}
