using TemplateMethod.V2.Model;
using TemplateMethod.V2.Template;

namespace TemplateMethod.V2
{
    public class PieBakingService : PanFoodServiceBaseTemplate<Pie>
    {
        public PieBakingService(LoggerAdapter logger) : base(logger)
        {
        }

        protected override void PrepareCrust()
        {
            _logger.Log("Rolling out crust and pressing into pie pan");
        }

        protected override void AddToppings()
        {
            _logger.Log("Adding pie filling");
        }

        protected override void Cover()
        {
            _logger.Log("Adding lattice top");
        }

        protected override void Bake()
        {
            _logger.Log("Baking for 45 minutes");
        }

        protected override void Slice()
        {
            _logger.Log("Cutting into 6 slices.");
        }

    }
}
