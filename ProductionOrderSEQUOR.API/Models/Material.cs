﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProductionOrderSEQUOR.API.Models
{
    public partial class Material
    {
        public Material()
        {
            ProductMaterial = new HashSet<ProductMaterial>();
            Production = new HashSet<Production>();
        }

        [Key]
        [StringLength(50)]
        [Unicode(false)]
        public string MaterialCode { get; set; }
        [Required]
        [StringLength(500)]
        [Unicode(false)]
        public string MaterialDescription { get; set; }
        [Column("idMaterial")]
        public int IdMaterial { get; set; }

        [InverseProperty("ProductCodeNavigation")]
        public virtual Product Product { get; set; }
        [InverseProperty("MaterialCodeNavigation")]
        public virtual ICollection<ProductMaterial> ProductMaterial { get; set; }
        [InverseProperty("MaterialCodeNavigation")]
        public virtual ICollection<Production> Production { get; set; }
    }
}