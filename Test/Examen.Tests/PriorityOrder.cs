using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Examen.Tests
{
    public class PriorityOrder : ITestCaseOrderer
    {
        public IEnumerable<TTestCase> OrderTestCases<TTestCase>(IEnumerable<TTestCase> testCases) where TTestCase : ITestCase
        {
            string assemblyName = typeof(TestPriorityAttribute).AssemblyQualifiedName!;
            var sortedMethods = new SortedDictionary<int, List<ITestCase>>();
            foreach (ITestCase testCase in testCases)
            {
                int priority = testCase.TestMethod.Method.GetCustomAttributes(assemblyName).FirstOrDefault()?.GetNamedArgument<int>(nameof(TestPriorityAttribute.Priority)) ?? 0;
                GetOrCreate(sortedMethods, priority).Add(testCase);

            }
            foreach (TTestCase testCase in
                sortedMethods.Keys.SelectMany(
                    priority => sortedMethods[priority].OrderBy(
                        testCase => testCase.TestMethod.Method.Name)))
            {
                yield return testCase;
            }
        }

        private static TValue GetOrCreate<TKey, TValue>(IDictionary<TKey, TValue> dictionary, TKey priority) where TKey : struct where TValue : new() => dictionary.TryGetValue(priority, out TValue result) ?
                 result
                 : (dictionary[priority] = new TValue());
    }
}
