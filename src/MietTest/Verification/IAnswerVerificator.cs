using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MietTest.Verification
{
    public interface IAnswerVerificator
    {
        bool Verify(string correctAnswer, string answer)
    }
}