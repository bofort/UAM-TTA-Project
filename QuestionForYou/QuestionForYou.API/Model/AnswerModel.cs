using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestionForYou.API.Model
{
    public class AnswerModel
    {
        public int? Id { get; set; }
        public int QuestionId { get; set; }        
        public string Text { get; set; }
        public bool IsCorrect { get; set; }

    }
}