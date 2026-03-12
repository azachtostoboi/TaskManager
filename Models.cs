using System;

namespace TaskManager.Models;

public abstract class BaseTask
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public DateTime CreatedAt { get; init; } = DateTime.Now;
    public bool IsCompleted { get; protected set; }

    public delegate void TaskCompletedHandler(BaseTask task);
    public event TaskCompletedHandler? OnTaskCompleted;

    public void CompleteTask()
    {
        if (!IsCompleted)
        {
            IsCompleted = true;
            OnTaskCompleted?.Invoke(this);
        }
    }
}

public class BugReportTask : BaseTask
{
    public string SeverityLevel { get; set; } = "Low";
}

public class FeatureRequestTask : BaseTask
{
    public double EstimatedHours { get; set; }
}