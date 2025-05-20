using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateMethod.V2.Model;
using TemplateMethod.V2.Template;

namespace TemplateMethod.V2
{
    public class ColdVeggiePizzaBakingService : PanFoodServiceBaseTemplate<ColdVeggiePizza>
    {
        public ColdVeggiePizzaBakingService(LoggerAdapter logger) : base(logger)
        {
        }

        protected override void AddToppings()
        {
            _logger.Log("Add cream cheese, peppers, and veggies");

        }

        // there are a few ways to deal with optional behavior like this
        // 1. Override the default and do nothing
        // 2. Add conditional logic to the base template method
        // 3. Implement do-nothing hook method in base template; only override if you need to do something (see Cover)
        // protected override void Bake()
        // {
        //    // override default behavior
        // }

        protected override void PrepareCrust()
        {
            _logger.Log("Rolling out dough and press into pan");
        }

        protected override void Slice()
        {
            _logger.Log("Slice into squares");
        }
    }
}
