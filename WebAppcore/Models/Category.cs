﻿using System.ComponentModel.DataAnnotations;

namespace WebAppcore.Models
{
    public class Category
    {
        [Key  ]
      
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
		public override string ToString()
		{
			return "Name : " +Name;
		}
	}
}
