﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList_App.Database.AppDbContextModels;

public class Task
{
    public int Id { get; set; }
    public string TaskName { get; set; }
    public DateTime dateTime { get; set; }
    public string Status { get; set; }
    public string Priority { get; set; }
    public int C_Id { get; set; }
}
