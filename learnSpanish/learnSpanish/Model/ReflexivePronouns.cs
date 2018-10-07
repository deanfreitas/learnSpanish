using SQLite;
using SQLiteNetExtensions.Attributes;

namespace learnSpanish.Model
{
    [Table("reflexive_pronouns")]
    public class ReflexivePronouns
    {
        public ReflexivePronouns()
        {
        }

        public ReflexivePronouns(string me, string te, string seSingular, string nos, string os, string sePlural)
        {
            Me = me;
            Te = te;
            SeSingular = seSingular;
            Nos = nos;
            Os = os;
            SePlural = sePlural;
        }

        public ReflexivePronouns(int id, string me, string te, string seSingular, string nos, string os,
            string sePlural)
        {
            Id = id;
            Me = me;
            Te = te;
            SeSingular = seSingular;
            Nos = nos;
            Os = os;
            SePlural = sePlural;
        }

        [PrimaryKey, AutoIncrement, Column("reflexive_pronouns_id")]
        public int Id { get; set; }

        [NotNull, Column("reflexive_pronouns_me")]
        public string Me { get; set; }

        [NotNull, Column("reflexive_pronouns_te")]
        public string Te { get; set; }

        [NotNull, Column("reflexive_pronouns_se_singular")]
        public string SeSingular { get; set; }

        [NotNull, Column("reflexive_pronouns_nos")]
        public string Nos { get; set; }

        [NotNull, Column("reflexive_pronouns_os")]
        public string Os { get; set; }

        [NotNull, Column("reflexive_pronouns_se_plural")]
        public string SePlural { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.All, ReadOnly = false)]
        public Word Word { get; set; }
    }
}