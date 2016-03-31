using DbLayer.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MietTest.Tests.TestClasses
{
    public class MainContextTestable : MainContext
    {
        public MainContextTestable()
            : base("DefaultTestConnection")
        {

        }

        static MainContextTestable()
        {
            Database.SetInitializer<MainContextTestable>(new MainContextTestableInitializer());
        }
    }
}
