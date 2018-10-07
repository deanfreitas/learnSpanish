using System;
using System.Collections.Generic;
using System.Linq;
using learnSpanish.Model;
using learnSpanish.Sqlite;

namespace learnSpanish.ApplicationService
{
    public class Start
    {
        private readonly SqliteTable _sqliteTable;
        private readonly SqliteService _sqliteService;

        public Start()
        {
            _sqliteTable = new SqliteTable();
            _sqliteService = new SqliteService();
        }

        public void CreateTables()
        {
            try
            {
                _sqliteTable.CreateTable<Login>();
                _sqliteTable.CreateTable<User>();
                _sqliteTable.CreateTable<Word>();
                _sqliteTable.CreateTable<Indicative>();
                _sqliteTable.CreateTable<PersonalPronouns>();
                _sqliteTable.CreateTable<Dictionary>();
            }
            catch (Exception e)
            {
                Logs.Logs.Error($"Error init application: {e.Message}");
            }
        }

        public async void InsertTables()
        {
        }

        private List<Indicative> CreateIndicative()
        {
            var indicatives = new List<Indicative>();

            return indicatives;
        }
        
        private List<PersonalPronouns> CreatePersonalPronounsPresent()
        {
            var personalPronounses = new List<PersonalPronouns>();

            var personalPronounsePresentOne = new PersonalPronouns
            {
                // correr
                Yo = "corro",
                Tu = "corres",
                Usted = "corre",
                Nosotros = "corremos",
                Vosotros = "corréis",
                Ustedes = "corren"
            };

            var personalPronounsePresentTwo = new PersonalPronouns
            {
                // andar
                Yo = "ando",
                Tu = "andas",
                Usted = "anda",
                Nosotros = "andamos",
                Vosotros = "andáis",
                Ustedes = "andan"
            };

            personalPronounses.Append(personalPronounsePresentOne);
            personalPronounses.Append(personalPronounsePresentTwo);

            return personalPronounses;
        }

        private List<PersonalPronouns> CreatePersonalPronounsPreteriteImperfect()
        {
            var personalPronounses = new List<PersonalPronouns>();

            var personalPronounsePreteriteImperfectOne = new PersonalPronouns
            {
                Yo = "corría",
                Tu = "corrías",
                Usted = "corría",
                Nosotros = "corríamos",
                Vosotros = "corríais",
                Ustedes = "corrían"
            };

            var personalPronounsePreteriteImperfectTwo = new PersonalPronouns
            {
                Yo = "andaba",
                Tu = "andabas",
                Usted = "andaba",
                Nosotros = "andábamos",
                Vosotros = "andabais",
                Ustedes = "andaban"
            };

            personalPronounses.Append(personalPronounsePreteriteImperfectOne);
            personalPronounses.Append(personalPronounsePreteriteImperfectTwo);

            return personalPronounses;
        }
    }
}