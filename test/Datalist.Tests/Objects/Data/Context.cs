﻿using System.Data.Entity;

namespace Datalist.Tests.Objects.Data
{
    public class Context : DbContext
    {
        public DbSet<TestModel> TestModels { get; set; }
    }
}
