using Examen.Core.COMMON.Interfaces;
using Examen.Core.COMMON.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Examen.Tests.UnitTests
{
    public class GenericTest<T> where T : class
    {
        protected readonly IGenericRepository<T> _repository;

        public GenericTest(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public bool Create(SpParametros spParametros) => _repository.Create(spParametros);
        public bool Delete(SpParametros spParametros) => _repository.Delete(spParametros);
        public bool Update(SpParametros spParametros) => _repository.Update(spParametros);
        public List<T> Read(SpParametros spParametros) => _repository.Read(spParametros);


    }
}
