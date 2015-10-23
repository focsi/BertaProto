using System.Data.Entity;

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
    }
}