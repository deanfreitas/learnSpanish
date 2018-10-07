using SQLite;
using SQLiteNetExtensions.Attributes;

namespace learnSpanish.Model
{
    public class Dictionary
    {
        public Dictionary()
        {
        }

        public Dictionary(string english, string spanish, string portuguese)
        {
            English = english;
            Spanish = spanish;
            Portuguese = portuguese;
        }

        public Dictionary(int id, string english, string spanish, string portuguese)
        {
            Id = id;
            English = english;
            Spanish = spanish;
            Portuguese = portuguese;
        }

        [PrimaryKey, AutoIncrement, Column("dictionary_id")]
        public int Id { get; set; }

        [NotNull, Column("dictionary_english")]
        [Indexed(Name = "WordId", Order = 1, Unique = true)]
        public string English { get; set; }

        [NotNull, Column("dictionary_spanish")]
        [Indexed(Name = "WordId", Order = 1, Unique = true)]
        public string Spanish { get; set; }

        [NotNull, Column("dictionary_portuguese")]
        [Indexed(Name = "WordId", Order = 1, Unique = true)]
        public string Portuguese { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.All, ReadOnly = false)]
        public Word Word { get; set; }
    }
}