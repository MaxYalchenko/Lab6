using Lab6.Data;
using Lab6.Data;
using Lab6.Models;
using Lab6.ViewsModels;
using Microsoft.AspNetCore.Mvc;

namespace Lab6.Controllers
{
    [Route("api/{subdivisionPlan}")]
    public class SubdivisionPlanController : ControllerBase
    {
        private readonly Context _context;

        public SubdivisionPlanController(Context context)
        {
            _context = context;
        }
        [HttpGet]
        [Produces("application/json")]
        public IActionResult GetALL()
        {
            var subdivisionPlans = _context.SubdivisionPlans.ToList();
            var subdivisionPlansVM = ToView(subdivisionPlans);
            return Ok(subdivisionPlansVM);
        }

        [HttpPost]
        public IActionResult Post([FromBody] SubdivisionPlan subdivisionPlan)
        {
            _context.SubdivisionPlans.Add(subdivisionPlan);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut]
        public IActionResult Put([FromBody] SubdivisionPlan subdivisionPlan)
        {
            _context.Update(subdivisionPlan);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var subdivisionPlan = _context.SubdivisionPlans.FirstOrDefault(x => x.subdivisionPlanId == id);
            _context.SubdivisionPlans.Remove(subdivisionPlan);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet("peoplePlans")]
        [Produces("application/json")]
        public IActionResult GetPeoplePlans()
        {
            var peoplePlans = _context.PeoplePlans.ToList();
            return Ok(peoplePlans);
        }

        [HttpGet("subdivisions")]
        [Produces("application/json")]
        public IActionResult GetSubdivisions()
        {
            var subdivisions = _context.Subdivisions.ToList();
            return Ok(subdivisions);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            SubdivisionPlan subdivisionPlans = _context.SubdivisionPlans.FirstOrDefault(x => x.subdivisionPlanId == id);
            return new ObjectResult(subdivisionPlans);
        }

        public IEnumerable<SubdivisionPlanView> ToView(IEnumerable<SubdivisionPlan> subdivisionPlans)
        {
            IEnumerable<SubdivisionPlanView> vm = from sp in subdivisionPlans
                                          join s in _context.Subdivisions
                                          on sp.subdivisionId equals s.subdivisionId
                                          select new SubdivisionPlanView
                                          {
                                            subdivisionPlanId= sp.subdivisionPlanId,
                                            subdivisionName= s.subdivisionName,
                                            subdivisionPlanDate = sp.subdivisionPlanDate,
                                            subdivisionPlanIndex = sp.subdivisionPlanIndex
                                          };
            return vm;

        }
    }
}
