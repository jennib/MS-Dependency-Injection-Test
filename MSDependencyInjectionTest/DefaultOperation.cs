using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Guid;

namespace MSDependencyInjectionTest
{
    public class DefaultOperation :
        ITransientOperation,
        IScopedOperation,
        ISingletonOperation
    {
        public string OperationId { get; } = NewGuid().ToString()[^4..];
    }
}
