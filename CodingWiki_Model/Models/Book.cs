﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_Model.Models
{
	public class Book
	{
		[Key]
		public int IDBook { get; set; }
		public string Title { get; set; }
		[MaxLength(30)]
		[Required] 
		public string ISBN { get; set; }
		public decimal Price { get; set; }
		[NotMapped]
        public string PriceRange { get; set; }
    }
}