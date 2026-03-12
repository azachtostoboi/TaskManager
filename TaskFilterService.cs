using System.Collections.Generic;
using System.Linq;
using TaskManager.Models;

namespace TaskManager.Services;

public static class TaskFilterService
{
    public static IEnumerable<BugReportTask> GetHighPriorityBugs(IEnumerable<BaseTask> tasks)
    {
        return tasks
            .OfType<BugReportTask>()
            .Where(t => !t.IsCompleted && t.SeverityLevel == "High")
            .OrderByDescending(t => t.CreatedAt);
    }

    public static double GetTotalEstimatedHours(IEnumerable<BaseTask> tasks)
    {
        return tasks
            .OfType<FeatureRequestTask>()
            .Where(t => !t.IsCompleted)
            .Sum(t => t.EstimatedHours);
    }
}