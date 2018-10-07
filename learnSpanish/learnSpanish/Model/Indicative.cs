using SQLite;
using SQLiteNetExtensions.Attributes;

namespace learnSpanish.Model
{
    public class Indicative
    {
        [PrimaryKey, AutoIncrement, Column("indicative_id")]
        public int Id { get; set; }

        [ForeignKey(typeof(PersonalPronouns)), NotNull, Column("indicative_present")]
        [Indexed(Name = "IndicativeId", Order = 1, Unique = true)]
        public int IdPresent { get; set; }

        [ForeignKey(typeof(PersonalPronouns)), NotNull, Column("indicative_preterite_imperfect")]
        [Indexed(Name = "IndicativeId", Order = 1, Unique = true)]
        public int IdPreteriteImperfect { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.All, ReadOnly = false)]
        public PersonalPronouns Present { get; set; }
        
        [OneToOne(CascadeOperations = CascadeOperation.All, ReadOnly = false)]
        public PersonalPronouns PreteriteImperfect { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.All, ReadOnly = false)]
        public Word Word { get; set; }
    }
}