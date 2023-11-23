
using RailwayReservationJWT.Data;
using RailwayReservationJWT.Models;
using RailwayReservationJWT.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace RailwayReservationJWT.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]

    public class BookingController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RailwayContext context;
        public BookingController(UserManager<IdentityUser> userManager, RailwayContext context)
        {
            this._userManager = userManager;
            this.context = context;
        }
        [HttpPost]

        public async Task<IActionResult> Booking(TicketData ticketData)
        {
            string userId = "d286238b-4e22-467d-835e-8ee21f349593";
            //TrainDetail trainDetail = new TrainDetail();///just coz error 
            
                if (userId != null)
                {
                    int TId = ticketData.TrainNo;
                    TrainDetail trainDetail = context.trainDetail.FirstOrDefault(id => id.TrainNo == TId);
                    Ticket ticket = new Ticket();
                    ticket.UserName = ticketData.UserName;
                    ticket.Age = ticketData.Age;
                    ticket.Gender = ticketData.Gender;
                    ticket.UserId = userId;
                    ticket.TrainNo = TId;

                    if (ticketData.TicketType == "SL" && trainDetail.SeatCount_Slepper > 0)
                    {
                        ticket.SeatNo = "SL" + (trainDetail.SeatCount_Slepper - trainDetail.SeatCount_Slepper + 1);
                        trainDetail.SeatCount_Slepper -= 1;
                    }
                    else if (ticketData.TicketType == "AC1" && trainDetail.SeatCount_AC1tire > 0)
                    {
                        ticket.SeatNo = "AC1" + (trainDetail.SeatCount_AC1tire - trainDetail.SeatCount_AC1tire + 1);
                        trainDetail.SeatCount_AC1tire -= 1;
                    }
                    else if (ticketData.TicketType == "AC2" && trainDetail.SeatCount_AC2tire > 0)
                    {
                        ticket.SeatNo = "AC2" + (trainDetail.SeatCount_AC2tire - trainDetail.SeatCount_AC2tire + 1);
                        trainDetail.SeatCount_AC2tire -= 1;
                    }
                    else if (ticketData.TicketType == "AC3" && trainDetail.SeatCount_AC3tire > 0)
                    {
                        ticket.SeatNo = "AC3" + (trainDetail.SeatCount_AC3tire - trainDetail.SeatCount_AC3tire + 1);
                        trainDetail.SeatCount_AC3tire -= 1;
                    }
                    else
                    {
                        ticket.SeatNo = "G" + (trainDetail.SeatCount_SecoundSetting - trainDetail.SeatCount_SecoundSetting + 1);
                        trainDetail.SeatCount_SecoundSetting -= 1;
                    }

                    context.tickets.Add(ticket);
                    context.SaveChanges();
                    if (ticket.TicketNo != 0)
                    {
                        return Ok(new
                        {
                            Status = "Success",
                            Message = "Booking Successfull",
                            BookingId = ticket.TicketNo,
                            SeatNo = ticket.SeatNo
                        });
                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "User not signed in", Message = "Please Signin!" });
                }
                return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Unable to book the ticket", Message = "Please try again!" });
            }
            
      
            

       /* [HttpDelete("{TicketNo}",Name = "CancelTicket")]
        public async Task<IActionResult> CancelTicket(int TicketNo)
        {
            if (context.tickets == null)
            {
                return NotFound();
            }
            var booking = await context.tickets.FindAsync(TicketNo);
            if (booking == null)
            {
                return NotFound();
            }
            context.tickets.Remove(booking);
            await context.SaveChangesAsync();
            return Ok();
        }*/

        [HttpDelete("{TicketNo}", Name = "CancelTicket")]
        public async Task<IActionResult> CancelTicket(int TicketNo)
        {
            try
            {
                var booking = await context.tickets.FindAsync(TicketNo);

                if (booking == null)
                {
                    return NotFound(new Response { Status = "Error", Message = "Ticket not found." });
                }

                context.tickets.Remove(booking);
                await context.SaveChangesAsync();

                return Ok(new Response { Status = "Success", Message = "Ticket canceled successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "An error occurred while canceling the ticket."});
            }
        }



    }
}