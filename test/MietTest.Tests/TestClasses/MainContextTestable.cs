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
        static string dbDir = @"";
        public MainContextTestable()
            : base(@"Data Source=(LocalDb)\v11.0;AttachDbFilename=" + dbDir + @"\dbtest.mdf;Initial Catalog=dbtest;Integrated Security=false")
        {
            
        }

        static MainContextTestable()
        {
            Database.SetInitializer<MainContextTestable>(new MainContextTestableInitializer());
        }
    }
}
