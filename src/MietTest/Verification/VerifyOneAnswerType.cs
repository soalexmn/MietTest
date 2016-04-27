using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MietTest.Verification
{
    public class VerifyOneAnswerType : IAnswerVerificator
    {
        public bool Verify(string correctAnswer, string answer)
        {
            return correctAnswer.Trim() == answer.Trim();
        }
    }
}