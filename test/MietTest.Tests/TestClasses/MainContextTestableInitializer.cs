using DbLayer.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace MietTest.Tests.TestClasses
{
    class MainContextTestableInitializer : DropCreateDatabaseAlways<MainContextTestable>
    {
        protected override void Seed(MainContextTestable context)
        {
            User us1 = new User
            {
                UserName = "Admin",
                Email = "aa@aa.ru",
            };
            var userManager = new UserManager<User>(new UserStore<User>(context));
            userManager.Create(us1, "sasasa");


            Test test = new Test
            {
                Title = "Заголовок",
                Description = "Описание теста",
                UserId = us1.Id
            };
            test.Questions.Add(new Question
            {
                Body = "Сколько ног у человека?",
                Result = "0",
                AnswerVariants = new List<AnswerVariant> { 
                    new AnswerVariant { Body = "2" }, 
                    new AnswerVariant { Body = "3" },
                    new AnswerVariant { Body = "4" }
                },
                QuestionType = QuestionType.One
            });

            test.Questions.Add(new Question
            {
                Body = "Сколько планет в солнечной системе?",
                Result = "1",
                AnswerVariants = new List<AnswerVariant> { 
                    new AnswerVariant { Body = "8" }, 
                    new AnswerVariant { Body = "9" },
                    new AnswerVariant { Body = "10" }
                }
            });

            base.Seed(context);
        }
    }
}
