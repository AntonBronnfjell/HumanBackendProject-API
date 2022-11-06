using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HumanAPI.Models;

namespace HumanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumanController : ControllerBase
    {
        /// <summary>
        /// A sort of fake data for the database.
        /// 
        /// Fake data from.
        /// <seealso cref="https://www.mockaroo.com/"/>
        /// </summary>
        private static readonly List<Human> _humans = new List<Human>
            {
                new Human
                {
                    Id =  Guid.Parse("9044e84b-90ac-411c-b513-c0f4ef4a0db8"),
                    Name = "Darryl Threadgold",
                    Gender = "M",
                    Age = 57,
                    Height = 154.5,
                    Weight = 76.3
                },
                  new Human
                  {
                      Id = Guid.Parse("a95f9fa6-f169-4f21-8720-923d7ae8c785"),
                      Name = "Adler Ramshaw",
                      Gender = "M",
                      Age = 45,
                      Height = 175.7,
                      Weight = 110.4
                  },
                  new Human
                  {
                      Id = Guid.Parse("79028c96-11d8-43fb-89a2-197fdc34147e"),
                      Name = "Sigismund Foxten",
                      Gender = "M",
                      Age = 36,
                      Height = 168.8,
                      Weight = 107.0
                  },
                  new Human
                  {
                      Id = Guid.Parse("645e01c6-73d3-4eb3-9c2a-cb72d7eec77a"),
                      Name = "Anna-diana Pennazzi",
                      Gender = "F",
                      Age = 56,
                      Height = 197.6,
                      Weight = 104.9
                  },
                  new Human
                  {
                      Id = Guid.Parse("d7daa1f7-55a9-4cd2-bff0-6bb551eef109"),
                      Name = "Loralie Normanvell",
                      Gender = "F",
                      Age = 41,
                      Height = 173.6,
                      Weight = 120.4
                  },
                  new Human
                  {
                      Id = Guid.Parse("c425bd56-b64a-4e7c-bebb-4548a38b4762"),
                      Name = "Shayne Thorns",
                      Gender = "F",
                      Age = 54,
                      Height = 173.6,
                      Weight = 101.4
                  },
                  new Human
                  {
                      Id = Guid.Parse("75f94598-9ac2-4d9e-a8f6-20ea5432cd31"),
                      Name = "Gilberto Baude",
                      Gender = "M",
                      Age = 40,
                      Height = 169.2,
                      Weight = 63.1
                  },
                  new Human
                  {
                      Id = Guid.Parse("e93e392a-0035-478b-a9bc-305ff11cb985"),
                      Name = "Selle Urlich",
                      Gender = "F",
                      Age = 20,
                      Height = 162.8,
                      Weight = 115.1
                  },
                  new Human
                  {
                      Id = Guid.Parse("37b5b6c2-488c-4f6d-9a2a-d4a9294e3ec7"),
                      Name = "Paxton Tindall",
                      Gender = "M",
                      Age = 40,
                      Height = 174.5,
                      Weight = 111.4
                  },
                  new Human
                  {
                      Id = Guid.Parse("70f3efb5-b6cd-49f5-b76b-f7831f8eba03"),
                      Name = "Elnore Crewther",
                      Gender = "F",
                      Age = 40,
                      Height = 172.7,
                      Weight = 63.7
                  }
        };
        private readonly DataContext _context;

        public HumanController(DataContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Array of humans object.
        /// </summary>
        /// <returns>Array of objects type Human.</returns>
        [HttpGet]
        public ActionResult<List<Human>> Get() => Ok(_context.Humans.ToArray());

        /// <summary>
        /// Get a specifict Human object.
        /// </summary>
        /// <param name="id">The GUID that identifies the human.</param>
        /// <returns>Human Object.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Human>> Get(int id)
        {
            var human = await _context.Humans.FindAsync(id);
            if (human == null)
                return BadRequest("Human not found.");
            return Ok(human);
        }

        /// <summary>
        /// Creates the Human and adds it to the database.
        /// </summary>
        /// <param name="human">The Human params.</param>
        /// <returns>Confirmation that has been saved.</returns>
        [HttpPost]
        public async Task<ActionResult<List<Human>>> AddHuman(Human human)
        {
            _context.Humans.Add(human);
            await _context.SaveChangesAsync();
            return Ok(await _context.Humans.ToListAsync());
        }

        /// <summary>
        /// Edits a human via GUID.
        /// </summary>
        /// <param name="request">The id that identifies the human.</param>
        /// <returns>Confirmation that has been saved.</returns>
        [HttpPut]
        public async Task<ActionResult> PutHuman(Human request)
        {
            var human = await _context.Humans.FindAsync(request.Id);
            if (human == null)
                return BadRequest("Human not found.");

            human.Name = request.Name;
            human.Gender = request.Gender;
            human.Age = request.Age;
            human.Height = request.Height;
            human.Weight = request.Weight;

            await _context.SaveChangesAsync();

            return Ok(await _context.Humans.ToListAsync());
        }

        /// <summary>
        /// Deletes a Human.
        /// </summary>
        /// <param name="id">The GUID that identifies the human.</param>
        /// <returns>Confirmation that has been saved.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Human>>> Delete(int id)
        {
            var human = await _context.Humans.FindAsync(id);
            if (human == null)
                return BadRequest("Human not found.");

            _context.Humans.Remove(human);

            await _context.SaveChangesAsync();

            return Ok(await _context.Humans.ToListAsync());
        }

        /// <summary>
        /// Generates a soft of fake data and adds it to the database.
        /// </summary>
        /// <returns>Confirmation that has been saved.</returns>
        [HttpPost]
        [Route("api/[controller]/Generate")]
        public async Task<ActionResult<List<Human>>> GenerateHuman()
        {
            foreach (Human _human in _humans)
            {
                _context.Humans.Add(_human);
            }
            await _context.SaveChangesAsync();
            return Ok(await _context.Humans.ToListAsync());
        }

        /// <summary>
        /// Generates a table of all Humans.
        /// </summary>
        /// <returns>A table of Humans</returns>
        [HttpGet]
        [Route("api/[controller]/Table")]
        public ActionResult<List<Human>> GetTable() => Ok(_context.Humans.ToList());
    }
}
