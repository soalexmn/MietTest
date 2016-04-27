using DbLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MietTest.Verification
{
    public class VerifyHelper
    {
        protected Dictionary<QuestionType, IAnswerVerificator> verificators = new Dictionary<QuestionType, IAnswerVerificator>();

        public VerifyHelper()
        {
            verificators.Add(QuestionType.One, new VerifyOneAnswerType());
            verificators.Add(QuestionType.Multi, new VerifyMultiAnswerType());
        }

        public TestResult SetIsCorrect(Test test, TestResult result)
        {
            foreach (var questionResult in result.QuestionResults)
            {
                var testQuestion = test.Questions.First(q => q.Id == questionResult.QuestionId);
                questionResult.IsCorrect = Verify(testQuestion, questionResult.Result);
            }
        }

        public bool Verify(Question question, string answer)
        {
            return verificators[question.QuestionType].Verify(question.Result, answer);
        }

        public bool Verify(QuestionType type,string correctAnswer, string answer)
        {
            return verificators[type].Verify(correctAnswer, answer);
        }
    }
}