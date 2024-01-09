﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_Model.Models
{
	public class Genre
	{
		[Key]
		public int GenreID { get; set; }
		public string GenreName { get; set; }
		public int DisplayOrder { get; set; }

	}
}
