
using CC_SchoolProject_RestApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CC_SchoolProject_RestApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;


namespace RestApi.NunitTests
{
    public static class InMemoryContext
    {
        public static CodeCrusaders_School_Management_DBContext Generated()
        {


            var _contextOptions = new DbContextOptionsBuilder<CodeCrusaders_School_Management_DBContext>()
                .UseInMemoryDatabase("ControllerTest")
                .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            return new CodeCrusaders_School_Management_DBContext(_contextOptions);
        }
    }

}
