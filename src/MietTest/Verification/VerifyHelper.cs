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
            result.QuestionResults = result.QuestionResults.Where(qr => qr != null).ToList();

            foreach (var questionResult in result.QuestionResults)
            {
                    var testQuestion = test.Questions.First(q => q.Id == questionResult.QuestionId);
                    questionResult.IsCorrect = Verify(testQuestion, questionResult.Result);
            }

            var addedAnswers = result.QuestionResults.Select(qr => qr.QuestionId).ToArray();
            var notAnswered = test.Questions.Where(q => addedAnswers.Contains(q.Id) == false);
            foreach (var item in notAnswered)
            {
                result.QuestionResults.Add(new QuestionResult { IsCorrect = false, QuestionId = item.Id });
            }
            
            return result;
        }

        public bool Verify(Question question, string answer)
        {
            return verificators[question.QuestionType].Verify(question.Result, answer);
        }

        public bool Verify(QuestionType type, string correctAnswer, string answer)
        {
            return verificators[type].Verify(correctAnswer, answer);
        }
    }
}