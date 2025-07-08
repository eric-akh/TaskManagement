using TaskManagement.Domain.Entities;

namespace TaskManagement.Domain.Interfaces;

/// <summary>
/// Interface for accessing and managing TaskItem entities in the data store.
/// </summary>
public interface ITaskRepository
{
    /// <summary>
    /// Retrieves all tasks.
    /// </summary>
    Task<IEnumerable<TaskItem>> GetAllAsync();

    /// <summary>
    /// Retrieves a task by its unique ID.
    /// </summary>
    Task<TaskItem?> GetByIdAsync(Guid id);

    /// <summary>
    /// Adds a new task.
    /// </summary>
    Task AddAsync(TaskItem task);

    /// <summary>
    /// Updates an existing task.
    /// </summary>
    Task UpdateAsync(TaskItem task);

    /// <summary>
    /// Deletes a task by its ID.
    /// </summary>
    Task DeleteAsync(Guid id);
}