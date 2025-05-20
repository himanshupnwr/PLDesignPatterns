using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade.V2
{
    public class BigClassFacade
    {
        private readonly BigClass _bigClass;

        public BigClassFacade()
        {
            _bigClass = new BigClass();
            _bigClass.SetValue(0);
        }

        public void IncreaseBy(int numberToAdd)
        {
            _bigClass.AddToI(numberToAdd);
        }

        public void DecreaseBy(int numberToRemove)
        {
            _bigClass.AddToI(-numberToRemove);
        }

        public int GetCurrentValue()
        {
            return _bigClass.GetValueA();
        }
    }
}
