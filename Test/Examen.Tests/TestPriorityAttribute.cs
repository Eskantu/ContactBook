using System;
using System.Collections.Generic;
using System.Text;

namespace ContactBook.Tests
{
    [AttributeUsage(AttributeTargets.Method,AllowMultiple =false)]
   public class TestPriorityAttribute:Attribute
    {
        public int Priority { get; set; }
        public TestPriorityAttribute(int priority) => Priority = priority;
    }
}
