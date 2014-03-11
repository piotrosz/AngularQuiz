using Newtonsoft.Json;
using SimpleQuiz.Core.Model;
using SimpleQuiz.Core.Model.Questions;
using System;
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
            get 
            {
                int count = 0;
                if (TestQuestions != null) { count += TestQuestions.Count; }
                if (SortQuestions != null) { count += SortQuestions.Count; }
                if (OpenQuestions != null) { count += OpenQuestions.Count; }
                if (CategoryQuestions != null) { count += CategoryQuestions.Count; }
                return count;
            } 
        }

        public int QuizPackageId { get; set; }

        [JsonIgnore]
        public virtual QuizPackage QuizPackage { get; set; }
    }
}
