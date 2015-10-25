using System.Web.Http;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Description;
using BertaProto.Models;
using System.Linq;
using System;

namespace BertaProto.Controllers
{
    [Authorize]
    public class IgenyController : ApiController
    {
        private IgenyDBContext db = new IgenyDBContext();
        public IgenyController()
        {

        }
        protected override void Dispose(bool disposing)
        {
            if ( disposing )
            {
                this.db.Dispose();
            }

            base.Dispose(disposing);
        }

        [ResponseType(typeof(Igeny))]
        public async Task<IHttpActionResult> Get( int id )
        {
            var userId = User.Identity.Name;

            Igeny nextIgeny = await GetIgenyAsync( id );

            if (nextIgeny == null)
            {
                return this.NotFound();
            }

            return this.Ok(nextIgeny);
        }

        private async Task<Igeny> GetIgenyAsync(int id)
        {
            return  await this.db.Igenyek
                .Where( g => g.ID == id )
                .FirstOrDefaultAsync();
        }

        private async Task<Igeny> NextQuestionAsync(string userId)
        {
            var lastQuestionId = await this.db.Igenyek
                .Select(g => g.ID )
                .FirstOrDefaultAsync();

            var igenyekCount = await this.db.Igenyek.CountAsync();

            var nextId = (lastQuestionId ) + 1;
            return await this.db.Igenyek.FindAsync(CancellationToken.None, nextId);
        }

    }
}
