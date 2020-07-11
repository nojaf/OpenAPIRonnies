using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OpenAPIRonnies.Controllers
{
    public class Controller : IController
    {
        private readonly Domain.RonnyContext _ronnyContext;

        public Controller(Domain.RonnyContext ronnyContext)
        {
            _ronnyContext = ronnyContext;
        }

        public Task<SwaggerResponse<ICollection<Ronny>>> GetRonniesAsync()
        {
            var ronnies = _ronnyContext.Ronnies.Select(DbRonnyToReadRonny).ToList();
            var response = new SwaggerResponse<ICollection<Ronny>>(HttpStatusCode.OK, ronnies);
            return Task.FromResult(response);
        }

        public IQueryable GetRonniesOData => _ronnyContext.Ronnies.AsQueryable();

        public async Task<SwaggerResponse<Ronny>> CreateRonnyAsync(CreateOrUpdateRonny body)
        {
            var ronny = CreateOrUpdateRonnyToDbRonny(body);
            ronny.Created = DateTimeOffset.UtcNow;
            ronny.Id = Guid.NewGuid();
            await _ronnyContext.Ronnies.AddAsync(ronny);
            await _ronnyContext.SaveChangesAsync();
            return new SwaggerResponse<Ronny>(HttpStatusCode.Created,DbRonnyToReadRonny(ronny));
        }

        public async Task<SwaggerResponse<Ronny>> GetRonnyAsync(string ronnyId)
        {
            if (Guid.TryParse(ronnyId, out var id))
            {
                var ronny = await _ronnyContext.Ronnies.FindAsync(id);
                if (ronny != null)
                {
                    return new SwaggerResponse<Ronny>(HttpStatusCode.OK, DbRonnyToReadRonny(ronny));
                }
                else
                {
                    return new SwaggerResponse<Ronny>(HttpStatusCode.NotFound);
                }
            }
            else
            {
                return SwaggerResponse<Ronny>.BadRequest("Invalid PK format");
            }
        }

        public async Task<SwaggerResponse<Ronny>> UpdateRonnyAsync(CreateOrUpdateRonny body, string ronnyId)
        {
            if (Guid.TryParse(ronnyId, out var id))
            {
                var existingRonny =  await _ronnyContext.Ronnies.FindAsync(id);
                if (existingRonny != null)
                {
                    existingRonny.Name = body.Name;
                    existingRonny.Price = body.Price;
                    await _ronnyContext.SaveChangesAsync();
                    return new SwaggerResponse<Ronny>(HttpStatusCode.Accepted, DbRonnyToReadRonny(existingRonny));
                }
                else
                {
                    return new SwaggerResponse<Ronny>(HttpStatusCode.NotFound);
                }
            }
            else
            {
                return SwaggerResponse<Ronny>.BadRequest("Invalid PK format");
            }
        }

        public async Task<SwaggerResponse> DeleteRonnyAsync(string ronnyId)
        {
            if (Guid.TryParse(ronnyId, out var id))
            {
                var ronny = await _ronnyContext.Ronnies.FindAsync(id);
                _ronnyContext.Ronnies.Remove(ronny);
                await _ronnyContext.SaveChangesAsync();
                return new SwaggerResponse(HttpStatusCode.OK);
            }
            else
            {
                return SwaggerResponse<Ronny>.BadRequest("Invalid PK format");
            }
        }

        private Ronny DbRonnyToReadRonny(OpenAPIRonnies.Domain.Ronny r)
        {
            return new Ronny
            {
                Id = r.Id.ToString(),
                Created = r.Created,
                Name = r.Name,
                Price = r.Price
            };
        }

        private OpenAPIRonnies.Domain.Ronny CreateOrUpdateRonnyToDbRonny(CreateOrUpdateRonny createOrUpdateRonny)
        {
            return new Domain.Ronny
            {
                Name = createOrUpdateRonny.Name,
                Price = createOrUpdateRonny.Price
            };
        }
    }
}