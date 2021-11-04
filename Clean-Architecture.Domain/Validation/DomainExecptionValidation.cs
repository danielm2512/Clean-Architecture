using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Domain.Validation
{
    public class DomainExecptionValidation : Exception
    {
        public DomainExecptionValidation(string error) : base(error)
        {}

        public static void When(bool hasError, string error)
        {
            if (hasError)
                throw new DomainExecptionValidation(error);
        }
    }
}
