using System.Web.Http;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Description;
using BertaProto.Models;
using System.Linq;

namespace BertaProto.Controllers
{
    [Authorize]
    public class IgenyController : ApiController
    {
        private IgenyDBContext db = new IgenyDBContext();
        public IgenyController()
        {
            if ( db.Igenyek.Count() == 0 )
            {
                for (int i = 0; i < 25; i++)
                {
                    db.Igenyek.Add(new Igeny() { ID = i, Leiras = "Leírás " + i.ToString(), Megnevezes = "Megnevezés " + i.ToString(), Objektum = (90000000 + i).ToString() });
                }
            }
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
        public async Task<IHttpActionResult> Get()
        {
            var userId = User.Identity.Name;

            Igeny nextIgeny = await this.NextQuestionAsync(userId);

            if (nextIgeny == null)
            {
                return this.NotFound();
            }

            return this.Ok(nextIgeny);
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
