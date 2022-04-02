using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawler
{
    public class Processor
    {
        public static IEnumerable<Question> GetQuestions()
        {
            var web = new HtmlWeb()
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.UTF8
            };

            var result = new List<Question>();
            for(int i = 1; i < 20; i++)
            {
                var document = web.Load($"{Contants.Page}{i}");
                var questions = document.DocumentNode
                    .QuerySelectorAll("div#questions > div.question-summary").ToList();

                foreach (var question in questions)
                {
                    var votes = int.Parse(question.QuerySelectorAll("div.statscontainer > div.stats > div.vote > div.votes > span")
                        .FirstOrDefault().InnerText);
                    var anws = int.Parse(question.QuerySelectorAll("div.statscontainer > div.stats > div.status > strong").FirstOrDefault().InnerText);


                    var views = int.Parse(question.QuerySelectorAll("div.statscontainer > div.views")
                        .FirstOrDefault().Attributes[1].Value.Split(' ')[0]);

                    var content = question.QuerySelectorAll("div.summary > div.excerpt")
                        .FirstOrDefault().ChildNodes[0].InnerText.Replace("\r\n", "").Trim();

                    var title = question.QuerySelectorAll("div.summary > h3").FirstOrDefault().InnerText;
                    
                    result.Add(new Question()
                    {
                        Answers = anws,
                        Summary = content,
                        Title = title,
                        Views = views,
                        Votes = votes
                    });

                    Console.WriteLine(title);
                }
            }

            return result;
        }
    }
}
