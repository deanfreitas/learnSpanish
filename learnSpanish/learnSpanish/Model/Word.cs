using SQLite;
using SQLiteNetExtensions.Attributes;

namespace learnSpanish.Model
{
    public class Word
    {
        public Word()
        {
        }

        [PrimaryKey, AutoIncrement, Column("word_id")]
        public int Id { get; set; }

        [NotNull, Column("word_name")]
        [Indexed(Name = "WordId", Order = 1, Unique = true)]
        public string WordName { get; set; }

        [ForeignKey(typeof(Indicative)), NotNull, Column("word_indicative")]
        [Indexed(Name = "WordId", Order = 2, Unique = true)]
        public int IdIndicative { get; set; }

        [ForeignKey(typeof(Dictionary)), NotNull, Column("word_dictionary")]
        [Indexed(Name = "WordId", Order = 3, Unique = true)]
        public int IdDictionary { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.All, ReadOnly = false)]
        public Indicative Indicative { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.All, ReadOnly = false)]
        public Dictionary Dictionary { get; set; }
    }
}