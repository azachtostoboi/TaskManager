using System;
using System.Collections.Generic;
using System.Linq;
using TaskManager.Models;

namespace TaskManager.Repositories;


public interface ITaskRepository
{
    IEnumerable<BaseTask> GetAllTasks();
    void AddTask(BaseTask task);
    BaseTask? GetTaskById(Guid id);
}


public class FakeTaskRepository : ITaskRepository
{
    
    private readonly List<BaseTask> _tasks = new();

    public IEnumerable<BaseTask> GetAllTasks() => _tasks;

    public void AddTask(BaseTask task)
    {
        _tasks.Add(task);
    }

    public BaseTask? GetTaskById(Guid id)
    {
        return _tasks.FirstOrDefault(t => t.Id == id);
    }
}