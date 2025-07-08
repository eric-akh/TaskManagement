using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Interfaces;

/// <summary>
/// Application service for managing tasks and implementing business logic.
/// </summary>
public interface ITaskService
{
    Task<IEnumerable<TaskItem>> GetAllTasksAsync();
    Task<TaskItem?> GetTaskByIdAsync(Guid id);
    Task CreateTaskAsync(TaskItem task);
    Task UpdateTaskAsync(TaskItem task);
    Task DeleteTaskAsync(Guid id);
}