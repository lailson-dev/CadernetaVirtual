using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class ResponsavelDTO
    {
        List<String> _emailresponsavel = new List<String>();
        public List<String> EmailResponsavel
        {
            get { return this._emailresponsavel; }
            set { this._emailresponsavel = value; }
        }
    }
}
