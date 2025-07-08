using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;

namespace TaskManagement.Application.Services;

/// <summary>
/// Implementation of the task management business logic.
/// </summary>
public class TaskService : ITaskService
{
    private readonly ITaskRepository _repository;

    public TaskService(ITaskRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<TaskItem>> GetAllTasksAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<TaskItem?> GetTaskByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task CreateTaskAsync(TaskItem task)
    {
        await _repository.AddAsync(task);
    }

    public async Task UpdateTaskAsync(TaskItem task)
    {
        await _repository.UpdateAsync(task);
    }

    public async Task DeleteTaskAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}