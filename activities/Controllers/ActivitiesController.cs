using System.Runtime.InteropServices;
using domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using persistance;

namespace activities.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ActivitiesController : ControllerBase
	{
		public ActivitiesController(DataContext dataContext)
		{
			DataContext = dataContext;
		}

		public DataContext DataContext { get; }

		[HttpGet]
		public async Task<ActionResult<List<Activity>>> GetActivities()
		{
			return await DataContext.Set<Activity>().ToListAsync();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Activity>> GetActivity(Guid id)
		{
			return await DataContext.Activities.FindAsync(id);
		}
	}
}
