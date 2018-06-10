﻿using System.ComponentModel.DataAnnotations;

namespace DuchTreat.ViewModels
{
    public class OrderItemViewModel
    {

        public int Id { get; set; }

        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public int ProductID { get; set; }

        public string ProductCategory { get; set; }
        public string ProductSize { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductTitle { get; set; }
        public string ProductArtDescription { get; set; }
        public string ProductArtDating { get; set; }
        public string ProductArtId { get; set; }
        public string ProductArtist { get; set; }

    }
}