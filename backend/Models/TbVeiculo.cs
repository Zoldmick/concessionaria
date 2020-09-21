﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("tb_veiculo")]
    public partial class TbVeiculo
    {
        public TbVeiculo()
        {
            TbAgendamento = new HashSet<TbAgendamento>();
        }

        [Key]
        [Column("id_veiculo", TypeName = "int(11)")]
        public int IdVeiculo { get; set; }
        [Required]
        [Column("ds_modelo", TypeName = "varchar(255)")]
        public string DsModelo { get; set; }
        [Required]
        [Column("ds_placa", TypeName = "varchar(50)")]
        public string DsPlaca { get; set; }
        [Column("vl_valor_veiculo", TypeName = "decimal(10,2)")]
        public decimal VlValorVeiculo { get; set; }
        [Column("bt_carro_pcd")]
        public bool BtCarroPcd { get; set; }
        [Column("ds_adaptacao", TypeName = "varchar(255)")]
        public string DsAdaptacao { get; set; }
        [Required]
        [Column("ds_imagem", TypeName = "varchar(255)")]
        public string DsImagem { get; set; }
        [Column("dt_ano_modelo", TypeName = "date")]
        public DateTime DtAnoModelo { get; set; }
        [Required]
        [Column("ds_cor", TypeName = "varchar(55)")]
        public string DsCor { get; set; }
        [Required]
        [Column("ds_combustivel", TypeName = "varchar(100)")]
        public string DsCombustivel { get; set; }
        [Required]
        [Column("ds_marca", TypeName = "varchar(100)")]
        public string DsMarca { get; set; }
        [Column("bt_disponivel")]
        public bool? BtDisponivel { get; set; }

        [InverseProperty("IdVeiculoNavigation")]
        public virtual ICollection<TbAgendamento> TbAgendamento { get; set; }
    }
}