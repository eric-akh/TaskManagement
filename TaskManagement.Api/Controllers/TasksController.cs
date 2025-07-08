using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Api.Controllers;

/// <summary>
/// Handles HTTP requests related to tasks.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    /// <summary>
    /// Retrieves all tasks.
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tasks = await _taskService.GetAllTasksAsync();
        return Ok(tasks);
    }

    /// <summary>
    /// Retrieves a task by ID.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var task = await _taskService.GetTaskByIdAsync(id);
        if (task == null) return NotFound();
        return Ok(task);
    }

    /// <summary>
    /// Creates a new task.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Create(TaskItem task)
    {
        await _taskService.CreateTaskAsync(task);
        return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
    }

    /// <summary>
    /// Updates an existing task.
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, TaskItem task)
    {
        if (id != task.Id) return BadRequest("ID mismatch");
        await _taskService.UpdateTaskAsync(task);
        return NoContent();
    }

    /// <summary>
    /// Deletes a task by ID.
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _taskService.DeleteTaskAsync(id);
        return NoContent();
    }
}