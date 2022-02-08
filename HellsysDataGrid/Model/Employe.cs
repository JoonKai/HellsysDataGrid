using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellsysDataGrid.Model
{
    public class Employe
    {
        #region Public Constructors

        public Employe()
        {
        }

        public Employe(string lastName, string firstName, double? salary, int? age, DateTime? startDate, bool? manager = false)
        {
            LastName = lastName;
            FirstName = firstName;
            Salary = salary;
            Age = age;
            StartDate = startDate;
            Manager = manager;
        }

        #endregion Public Constructors

        #region Public Properties

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? Manager { get; set; }
        public double? Salary { get; set; }
        public int? Age { get; set; }

        public DateTime? StartDate { get; set; }

        #endregion Public Properties
    }
}
