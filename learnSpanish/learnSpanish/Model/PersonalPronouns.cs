using SQLite;
using SQLiteNetExtensions.Attributes;

namespace learnSpanish.Model
{
    [Table("Personal_Pronouns")]
    public class PersonalPronouns
    {
        public PersonalPronouns()
        {
        }

        public PersonalPronouns(string yo, string tu, string usted, string nosotros, string vosotros, string ustedes)
        {
            Yo = yo;
            Tu = tu;
            Usted = usted;
            Nosotros = nosotros;
            Vosotros = vosotros;
            Ustedes = ustedes;
        }

        public PersonalPronouns(int id, string yo, string tu, string usted, string nosotros, string vosotros,
            string ustedes)
        {
            Id = id;
            Yo = yo;
            Tu = tu;
            Usted = usted;
            Nosotros = nosotros;
            Vosotros = vosotros;
            Ustedes = ustedes;
        }

        [PrimaryKey, AutoIncrement, Column("personal_pronouns_id")]
        public int Id { get; set; }

        [NotNull, Column("personal_pronouns_yo")]
        public string Yo { get; set; }

        [NotNull, Column("personal_pronouns_tu")]
        public string Tu { get; set; }

        [NotNull, Column("personal_pronouns_usted")]
        public string Usted { get; set; }

        [NotNull, Column("personal_pronouns_nosotros")]
        public string Nosotros { get; set; }

        [NotNull, Column("personal_pronouns_vosotros")]
        public string Vosotros { get; set; }

        [NotNull, Column("personal_pronouns_ustedes")]
        public string Ustedes { get; set; }
        
        [OneToOne(CascadeOperations = CascadeOperation.All, ReadOnly = false)]
        public Indicative Indicative { get; set; }  
    }
}