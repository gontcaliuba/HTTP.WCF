using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAD_04v1
{
    public class Calculator
    {
        public EmployeeRepository empRepository = new EmployeeRepository();
        public Calculator(EmployeeRepository empRepository)
        {
            this.empRepository = empRepository;
        }

        public EmployeeRepository filterBy()
        {
            float avgSalary = 0;
            for (int i = 0; i < empRepository.employees.Count(); i++)
                avgSalary += empRepository.employees[i].salary;
            if (empRepository.employees.Count() > 0)
                avgSalary /= empRepository.employees.Count();


            EmployeeRepository filteredEmp = new EmployeeRepository();
            int count = empRepository.employees.Count();
            if (count <= 0) return filteredEmp;

            for (int i = 0; i < count; i++)
            {
                Employee e = empRepository.Extract(i);
                if (e == null) continue;
                if (e.salary > avgSalary)
                {
                    filteredEmp.Add(e);
                }
            }
            return filteredEmp;
        }

        public List<EmployeeRepository> groupBy()
        {
            var groupedDepartmetList = empRepository.employees
                .GroupBy(e => e.department)
                .Select(grp => grp.ToList())
                .ToList();

            List<EmployeeRepository> res = new List<EmployeeRepository>();
            foreach (List<Employee> emp in groupedDepartmetList)
            {
                EmployeeRepository r = new EmployeeRepository();
                r.employees = emp;
                res.Add(r);
            }
            return res;
        }

        public EmployeeRepository sortBy()
        {
            EmployeeRepository sortedEmp = new EmployeeRepository();
            sortedEmp.employees = empRepository.employees;

            sortedEmp.employees.Sort(delegate(Employee x, Employee y)
            {
                if (x.department == null && y.department == null) return 0;
                else if (x.department == null) return -1;
                else if (y.department == null) return 1;
                else return x.department.CompareTo(y.department);
            });
            return sortedEmp;
        }


    }
}
