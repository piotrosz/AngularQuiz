using Newtonsoft.Json;
using SimpleQuiz.Core.Model;
using SimpleQuiz.Core.Model.Questions;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleQuiz.Core.Model
{
    public class Quiz : Entity
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string View { get; set; }

        public virtual ICollection<TestQuestion> TestQuestions { get; set; }
        
        public virtual ICollection<SortQuestion> SortQuestions { get; set; }

        public virtual ICollection<OpenQuestion> OpenQuestions { get; set; }

        public virtual ICollection<CategoryQuestion> CategoryQuestions { get; set; }

        public int QuestionCount
        {
            get { return AllQuestions.Count; }
        }

        public List<IQuestion> AllQuestions
        {
            get
            {
                var result = new List<IQuestion>();
                if(TestQuestions != null) { result.AddRange(TestQuestions); }
                if (SortQuestions != null) { result.AddRange(SortQuestions); }
                if (OpenQuestions != null) { result.AddRange(OpenQuestions); }
                if (CategoryQuestions != null) { result.AddRange(CategoryQuestions); }
                return result;
            }
        }

        public int QuizPackageId { get; set; }

        [JsonIgnore]
        public virtual QuizPackage QuizPackage { get; set; }
    }
}
