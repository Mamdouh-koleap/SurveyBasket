
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SurveyBasket.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PollsController(IPollService PollService) : ControllerBase
{
    private readonly IPollService _pollService= PollService;
   
     [HttpGet("")]
     public ActionResult GetAll()
     {
        var polls= _pollService.GetAll();

        var response = polls.Adapt<IEnumerable<PollResponse>>();

        return Ok(response);
     }

    [HttpGet("{id}")]
    public ActionResult Get(int id)
    {
        var poll = _pollService.Get(id);
        if (poll is null)
            return NotFound();
        var response = poll.Adapt<PollResponse>();
        return   Ok(response);
    }
    [HttpPost(template: "")]
    public ActionResult Add([FromBody]CreatePollRequest request) 
    {
        var newpoll=_pollService.Add(request.Adapt<Poll>());  
        return CreatedAtAction(nameof(Get),new { id= newpoll.Id},newpoll);
    }
    [HttpPut("{id}")]
    public ActionResult Update([FromRoute]int id, [FromBody] CreatePollRequest request)
    {
       var isUpdated= _pollService.Update(id,(request.Adapt<Poll>()));
       if (!isUpdated)
            return NotFound(); 
       
        return NoContent(); 
    }

    [HttpDelete("{id}")]
    public ActionResult Delete([FromRoute] int id)
    {

        var isDeleted = _pollService.Delete(id);
        if (!isDeleted)
            return NotFound();

        return NoContent();
    }
}

