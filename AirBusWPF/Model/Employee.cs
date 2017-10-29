using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBusWPF.Model
{
    public class Employee: ObservableObject
    {
        private int id;
        private string name;
        private int age;
        private decimal salary;

        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                base.Set<int>(() => this.ID, ref id, value);
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                Set<string>(() => this.Name, ref name, value);
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                Set<int>(() => this.Age, ref age, value);
            }
        }

        public decimal Salary
        {
            get
            {
                return salary;
            }
            set
            {
                Set<decimal>(() => this.Salary, ref salary, value);
            }
        }

        public ObservableCollection<Employee> GetSampleEmployees()
        {
            ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
            for (int i = 0; i < 20; i++)
            {
                employees.Add(
                  new Employee
                    {
                        ID = i + 1,
                    Name = "Name" + i.ToString(),
                    Age = 11 + i,
                    Salary = 2000 + i * 15
                    }
                    );
            }

            return employees;
        }

    }
}
