namespace TaskManagement.Domain.Entities;

/// <summary>
/// Represents a task in the system.
/// </summary>
public class TaskItem
{
    /// <summary>
    /// Unique identifier for the task.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Title of the task.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Optional description for the task.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Date and time the task was created.
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Indicates whether the task is completed.
    /// </summary>
    public bool IsCompleted { get; set; } = false;

    /// <summary>
    /// Optional deadline for completing the task.
    /// </summary>
    public DateTime? DueDate { get; set; }
}