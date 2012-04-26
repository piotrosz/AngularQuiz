using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace SimpleQuiz
{
    public class QuizCollectionHttpImporter : IQuizCollectionImporter
    {
        public string Uri { get; set; }

        public IEnumerable<Quiz> Import()
        {
            string contents = "";

            using (WebClient client = new WebClient())
            {
                contents = client.DownloadString(Uri);
            }

            return new QuizCollectionTextParser()
                .Parse(contents.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None));
        }
    }
}
