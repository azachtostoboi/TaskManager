using System;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;
using TaskManager.Repositories;

namespace TaskManager.Controllers;

[ApiController]
[Route("api/[controller]")] 
public class TasksController : ControllerBase
{
    private readonly ITaskRepository _repository;

    
    public TasksController(ITaskRepository repository)
    {
        _repository = repository;
    }

    
    [HttpGet]
    public IActionResult GetAllTasks()
    {
        return Ok(_repository.GetAllTasks());
    }

    
    [HttpPost("bug")]
    public IActionResult CreateBugReport([FromBody] BugReportTask bug)
    {
        _repository.AddTask(bug);
        return Ok(bug); 
    }

    
    [HttpPut("{id}/complete")]
    public IActionResult CompleteTask(Guid id)
    {
        var task = _repository.GetTaskById(id);
        if (task == null)
            return NotFound("Task not found.");

        
        task.OnTaskCompleted += (t) => 
        {
            Console.WriteLine($"\n--- СОБЫТИЕ СРАБОТАЛО: Задача {t.Id} выполнена! ---\n");
        };

        
        task.CompleteTask();

        return Ok(task);
    }
}