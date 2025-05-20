using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade.V2
{
    internal class BigClass
    {
        private int _i;

        public int GetValueA(){ return _i; }
        public string GetValueB() { return "Ball Of Mud"; }
        public void SetValue(int i) { _i = i; }
        public void IncrementI() { _i++; }
        public void DecrementI() { _i--; }
        public int GetI() { return _i; }
        public void AddToI(int numberToAdd)
        {
            _i = _i + numberToAdd;
        }
    }
}
