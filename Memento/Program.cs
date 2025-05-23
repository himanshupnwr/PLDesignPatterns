using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Command Pattern";
            CommandManager commandManager = new();
            IEmployeeManagerRepository employeeManagerRepository = new EmployeeManagerRepository();
            commandManager.Invoke(new AddEmployeeToManagerList(employeeManagerRepository, 1, new Employee(111, "Kevin")));
            employeeManagerRepository.WriteDataStore();

            commandManager.Undo();
            employeeManagerRepository.WriteDataStore();

            commandManager.Invoke(new AddEmployeeToManagerList(employeeManagerRepository, 1, new Employee(222, "Clara")));
            employeeManagerRepository.WriteDataStore();

            commandManager.Invoke(new AddEmployeeToManagerList(employeeManagerRepository, 2, new Employee(333, "Tom")));
            employeeManagerRepository.WriteDataStore();

            commandManager.Invoke(new AddEmployeeToManagerList(employeeManagerRepository, 2, new Employee(333, "Tom")));
            employeeManagerRepository.WriteDataStore();

            commandManager.UndoAll();
            employeeManagerRepository.WriteDataStore();
        }
    }
}
