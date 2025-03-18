using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList_App.Database.AppDbContextModels
{
    public class Goal
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public DateTime DateTime { get; set; }
        public int Duration { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int T_Id { get; set; }
    }
}
