﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RailwayReservationJWT.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
       

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        [RegularExpression("[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Invalid Email Address.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Address is Required")]
        public string Email { get; set; }


        
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is Required")]
        public string AdminName { get; set; }


        [StringLength(50, MinimumLength = 8)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}