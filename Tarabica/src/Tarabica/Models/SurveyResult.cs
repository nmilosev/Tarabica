using System;
using System.Collections.Generic;

namespace Tarabica
{
    public class SurveyResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public DateTime Date {get; set; }
        public int Mark { get;set; }

        public static void Save(string name, string comment, int mark) 
        {
            //nasty haxor
            var s = new SurveyResult() { 
                Name = name, 
                Comment = comment, 
                Date = DateTime.UtcNow.AddHours(2),
                Mark = mark 
            };

            Console.WriteLine("-------------");
            Console.WriteLine("SURVEY RESULT");
            Console.WriteLine($"Name: {s.Name}");
            Console.WriteLine($"Comment: {s.Comment}");
            Console.WriteLine($"Date: {s.Date}");
            Console.WriteLine($"Mark: {s.Mark}");
            Console.WriteLine("-------------");

            using(var db = new LiteDB.LiteDatabase("db.litedb"))
            {
                var col = db.GetCollection<SurveyResult>("surveyresults");
                col.Insert(s);
            }
        }        
    }
}

