﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList_App.Domain.Features.AddGoal;

public class AddGoalRequestModel
{
   
 
  public string GoalName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int T_Id { get; set; }
}
