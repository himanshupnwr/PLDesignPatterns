using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod.InhertinceExample
{
    public abstract class TemplateBase
    {
        private bool _importantSetting;
        //template method
        public void Do()
        {
            BeforeDoing();
            Initialize();
            AfterDone();
        }

        public virtual void BeforeDoing() { }
        public abstract void AfterDone();
        private void Initialize() { 
            _importantSetting = true;
        }
    }

    public class TemplateChild : TemplateBase
    {
        public override void AfterDone()
        {
            //do studd
            throw new NotImplementedException();    
        }
    }
}
