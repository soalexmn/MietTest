using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MietTest.Verification
{
    public class VerifyMultiAnswerType : IAnswerVerificator
    {
        public bool Verify(string correctAnswer, string answer)
        {
            var corrAnswers = correctAnswer.Trim().Split(',');
            var answers = answer.Trim().Split(',');

            if (corrAnswers.Length != answers.Length) return false;

            for (int i = 0; i < answers.Length; i++)
            {
                if (corrAnswers.Any(a => a == answers[i]) == false) return false;
            }
            return true;
        }
    }
}