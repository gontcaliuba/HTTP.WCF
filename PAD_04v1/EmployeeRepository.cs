using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAD_04v1
{
    [Serializable]
    public class EmployeeRepository
    {
        public List<Employee> employees = new List<Employee>();
        
        public Employee Extract(int number)
        {
            if (employees[number] == null) return null;
            return employees[number];
        }
        public void Add(Employee emp)
        {
            if (emp == null) return;
            employees.Add(emp.Clone());
        }

        public void Add(EmployeeRepository rep)
        {
            for (int i = 0; i < rep.employees.Count; i++)
            {
                employees.Add(rep.employees[i]);
            }
        }

        public void Add(List<EmployeeRepository> rep_lst)
        {
            for (int i = 0; i < rep_lst.Count; i++)
            {
                Add(rep_lst[i]);
            }
        }

        public override string ToString()
        {
            if (employees.Count <= 0) return "Нет данных.\n";


            string str = "";
            foreach (Employee e in employees)
            {
                str += e.ToString() + "\n";
            }

            str += "\n";
            return str;
        }
    }
}
