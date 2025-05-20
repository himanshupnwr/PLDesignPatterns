using TemplateMethod.V2.Model;

namespace TemplateMethod.V2.Template
{
    public abstract class PanFoodServiceBaseTemplate<T> where T:PanFood, new()
    {
        protected readonly LoggerAdapter _logger;
        protected T _item;

        public PanFoodServiceBaseTemplate(LoggerAdapter logger)
        {
            _logger = new LoggerAdapter();
        }

        //The template method
        public T Prepare()
        {
            _item = new T();

            PrepareCrust();

            AddToppings();

            Cover();

            if (_item.RequiresBaking)
            {
                Bake();
            }

            Slice();

            return _item;
        }

        protected abstract void PrepareCrust();

        protected abstract void AddToppings();

        protected virtual void Bake()
        {
            _logger.Log("Bake the item.");
        }

        protected abstract void Slice();

        protected virtual void Cover()
        {
            // does nothing by default
        }
    }
}
