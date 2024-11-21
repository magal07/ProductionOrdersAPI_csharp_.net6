﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProductionOrderSEQUOR.API.Models
{
    public partial class Production
    {
        [Key]
        [Column("idProduction")]
        public int IdProduction { get; set; }
        [Required]
        [StringLength(100)]
        [Unicode(false)]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        [Unicode(false)]
        public string Order { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal Quantity { get; set; }
        [Required]
        [StringLength(50)]
        [Unicode(false)]
        public string MaterialCode { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal CycleTime { get; set; }

        public virtual User idNavigation { get; set; } // pois foi cadastrado o Email como 
        [ForeignKey("MaterialCode")]
        [InverseProperty("Production")]
        public virtual Material MaterialCodeNavigation { get; set; }
        [ForeignKey("Order")]
        [InverseProperty("Production")]
        public virtual Order OrderNavigation { get; set; }
    }
}