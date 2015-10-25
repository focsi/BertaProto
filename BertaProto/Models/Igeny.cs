using System.Data.Entity;
using System.Linq;

namespace BertaProto.Models
{
    public class Igeny
    {
        public int ID { get; set; }
        public string Megnevezes{ get; set; }
        public string Leiras { get; set; }
        public string Objektum { get; set; }
        public string ObjektumElnevezes { get; set; }
    }

    public class IgenyDBContext : DbContext
    {
        public DbSet<Igeny> Igenyek { get; set; }


        public class IgenyDBInitializer : CreateDatabaseIfNotExists<IgenyDBContext>
        {
            protected override void Seed(IgenyDBContext context)
            {
                base.Seed(context);

                // ID oszlopot automatikusan tölti
                for (int i = 1; i < 25; i++)
                {
                    context.Igenyek.Add(new Igeny() { Leiras = "Leírás " + i.ToString(), Megnevezes = "Megnevezés " + i.ToString(), Objektum = (90000000 + i).ToString() });
                }
                context.SaveChanges();
            }
        }
    }
}