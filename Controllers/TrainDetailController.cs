using RailwayReservationJWT.Data;
using RailwayReservationJWT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RailwayReservationJWT.ViewModels;

namespace RailwayReservationJWT.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]

    public class TrainDetailController : Controller
    {
        private readonly RailwayContext context;
        public TrainDetailController(RailwayContext context)
        {
            this.context = context;
        }

      
        [Route("GetAllTrains")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainDetail>>> GetTrainDetail()
        {
            try
            {
                var trainDetails = await context.trainDetail.ToListAsync();

                if (trainDetails == null || trainDetails.Count == 0)
                {
                    return NotFound(new Response { Status = "Error", Message = "No train details found." });
                }

                return trainDetails;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "An error occurred while fetching train details."});
            }
        }


         [HttpGet("id")]
          public async Task<ActionResult<TrainDetail>> GetTrainDetail(int id )
          {
              if (context.trainDetail == null)
              {
                  return NotFound();
              }
              var train = await context.trainDetail.FindAsync(id);
              if (train == null)
              {
                  return NotFound();
              }
              return train;
          }

        [HttpPost]
        public async Task<ActionResult<TrainDetail>> PostTrainDetail(TrainDetail train
            )
        {
            context.trainDetail.Add(train);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTrainDetail), new { id = train.TrainNo }, train);
        }
        

        [HttpPut]
        public async Task<IActionResult> PuTrainDetail(TrainDetail train)
        {

            context.Entry(train).State = EntityState.Modified;
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
            return Ok();
        }
        

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainDetail(int id)
        {
            try
            {
                var train = await context.trainDetail.FindAsync(id);

                if (train == null)
                {
                    return NotFound(new Response { Status = "Error", Message = "Train detail not found." });
                }

                context.trainDetail.Remove(train);
                await context.SaveChangesAsync();

                return Ok(new Response { Status = "Success", Message = "Train detail deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "An error occurred while deleting train details."});
            }
        }

    }
}