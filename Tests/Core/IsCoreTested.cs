﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Tests.Core
{
    [TestClass]
    public class IsCoreTested : AssemblyBaseTests
    {
        public IsCoreTested()
            : base($"{nameof(Training)}.{nameof(Training.Core)}") { }
    }
}
