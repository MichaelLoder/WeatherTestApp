using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface ICacheFacade<key, value>
    {

        value Get(key key);
        void Add(key key, value value);
       
    }
}
