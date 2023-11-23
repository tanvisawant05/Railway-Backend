﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace RailwayReservationJWT.Models
{
    public class Ticket
    {
         [Key]
         public int TicketNo { get; set; }


         [Column(TypeName = "VARCHAR")]
         [StringLength(50)]
         [Required(AllowEmptyStrings = false, ErrorMessage = "UserName is Required")]
         public string UserName { get; set; }


         [Required(AllowEmptyStrings = false, ErrorMessage = "User's Age is Required")]
         [Range(0, 120, ErrorMessage = "Age Should Must Be in Range of 0 to 120")]
         public int Age { get; set; }


         [Column(TypeName = "VARCHAR")]
         [StringLength(10)]
         [Required(AllowEmptyStrings = false, ErrorMessage = "User's Gender is Required")]
         public string Gender { get; set; }


         [Column(TypeName = "VARCHAR")]
         [StringLength(10)]
         public string SeatNo { get; set; }


         [Column(TypeName = "NVARCHAR")]
         [StringLength(450)]
         public string UserId { get; set; }


         [ForeignKey("UserId")]
         public IdentityUser User { get; set; }


         public int TrainNo { get; set; }


         [ForeignKey("TrainNo")]
         public TrainDetail TrainDetail { get; set; }
     
    }
}