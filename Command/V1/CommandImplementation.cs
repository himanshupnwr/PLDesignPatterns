namespace Command.V1
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Employee(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    public class Manager : Employee
    {
        public List<Employee> Employees { get; set; }
        public Manager(int id, string name) : base(id, name)
        {

        }
    }

    //interface of receiver
    public interface IEmployeeManagerRepository
    {
        void AddEmployee(int managerId, Employee employee);
        void RemoveEmployee(int managerId, Employee employee);
        bool HasEmployee(int managerId, Employee employee);
        void WriteDataStore();
    }

    // implementation of the interface by receiver
    public class EmployeeManagerRepository : IEmployeeManagerRepository
    {
        private List<Manager> _managers = new List<Manager>() { new Manager(1, "Katie"), new Manager(2, "Geoff") };

        public void AddEmployee(int managerId, Employee employee)
        {
            _managers.First(m => m.Id == managerId).Employees.Add(employee);
        }

        public bool HasEmployee(int managerId, Employee employee)
        {
            return _managers.First(m => m.Id == managerId).Employees.Any(e => e.Id == employee.Id);
        }

        public void RemoveEmployee(int managerId, Employee employee)
        {
            _managers.First(m => m.Id == managerId).Employees.Remove(employee);
        }

        public void WriteDataStore()
        {
            foreach (var manager in _managers)
            {
                Console.WriteLine($"Manager {manager.Id}, {manager.Name}");
                if (manager.Employees.Any())
                {
                    foreach (var employee in manager.Employees)
                    {
                        Console.WriteLine($"\t Employee {employee.Id}, {employee.Name}");
                    }
                }
                else
                {
                    Console.WriteLine($"\t No employee");
                }
            }
        }
    }

    public interface ICommand
    {
        void Execute();
        bool CanExecute();
        void Undo();
    }

    public class AddEmployeeToManagerList : ICommand
    {
        private readonly Employee? _employee;
        private readonly int _managerId;
        private readonly IEmployeeManagerRepository _employeeManagerRepository;


        public AddEmployeeToManagerList(IEmployeeManagerRepository employeeManagerRepository, int managerId, Employee? employee)
        {
            _employeeManagerRepository = employeeManagerRepository;
            _managerId = managerId;
            _employee = employee;
        }
        public bool CanExecute()
        {
            //employee shouldn't be null
            if (_employee == null)
            {
                return false;
            }
            //employee shouldn't be on the manager's list already
            if (_employeeManagerRepository.HasEmployee(_managerId, _employee))
            {
                return false;
            }

            return true;
        }
        public void Execute()
        {
            if (_employee == null)
            {
                return;
            }
            _employeeManagerRepository.AddEmployee(_managerId, _employee);
        }

        public void Undo()
        {
            if (_employee == null)
            {
                return;
            }
            _employeeManagerRepository.RemoveEmployee(_managerId, _employee);
        }
    }

    public class CommandManager
    {
        private readonly Stack<ICommand> _commands = new Stack<ICommand>();
        public void Invoke(ICommand command)
        {
            if (command.CanExecute())
            {
                command.Execute();
                _commands.Push(command);
            }
        }

        public void Undo()
        {
            if (_commands.Any())
            {
                _commands.Pop().Undo();
            }
        }

        public void UndoAll()
        {
            while (_commands.Any())
            {
                _commands.Pop()?.Undo();
            }
        }
    }
}
