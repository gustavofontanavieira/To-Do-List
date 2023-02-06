using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using To_Do_List.Models;

namespace To_Do_List.Repository
{
    public interface ITaskRepository
    {
        List<TaskModel> ListAll();
        TaskModel Create(TaskModel task);
        Boolean Delete(int id);
        TaskModel Update(TaskModel task);
        TaskModel FindTask(int id);
    }
}
