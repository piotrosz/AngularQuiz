﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularQuiz.Core.Model
{
    [AttributeUsage(AttributeTargets.Property, Inherited=true, AllowMultiple=false)]
    public class SecretAttribute : Attribute
    {
    }
}
