using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using To_Do_List.Data;
using To_Do_List.Models;


namespace To_Do_List.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DatabaseContext _context;
        public TaskRepository(DatabaseContext databaseContext)
        {
            this._context = databaseContext;
        }

        public TaskModel Create(TaskModel task)
        {
            _context.Task.Add(task);
            _context.SaveChanges();
            return task;
        }

        public List<TaskModel> ListAll()
        {
            return _context.Task.ToList();
        }

        public TaskModel FindTask(int id)
        {
            return _context.Task.FirstOrDefault(x => x.Id == id);
        }

        public Boolean Delete(int id)
        {
            TaskModel taskModel = this.FindTask(id);
            if (taskModel == null) throw new Exception("Erro ao deletar tarefa");
            _context.Task.Remove(taskModel);
            _context.SaveChanges();
            return true;
        }

        public TaskModel Update(TaskModel task)
        {
            TaskModel taskModel = this.FindTask(task.Id);
            if(taskModel == null) throw new Exception("Erro ao atualizar tarefa");
            taskModel.Task = task.Task;
            taskModel.Status = task.Status;
            _context.Task.Update(taskModel);
            _context.SaveChanges();
            return task;
        }

        public TaskModel UpdateStatus(int id)
        {
            TaskModel taskModel = this.FindTask(id);
            if (taskModel == null) throw new Exception("Erro ao atualizar tarefa");
            taskModel.Status = "Completo";
            _context.Task.Update(taskModel);
            _context.SaveChanges();
            return taskModel;
        }

        public TaskModel PendingStatus(int id)
        {
            TaskModel taskModel = this.FindTask(id);
            if (taskModel == null) throw new Exception("Erro ao atualizar tarefa");
            taskModel.Status = "Pendente";
            _context.Task.Update(taskModel);
            _context.SaveChanges();
            return taskModel;
        }
    }
}
