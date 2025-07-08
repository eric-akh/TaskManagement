using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        try
        {
            var tasks = await _taskService.GetAllTasksAsync();
            return Ok(tasks);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Unexpected error", detail = ex.Message });
        }
    }

    /// <summary>
    /// Retrieves a task by ID.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        try
        {
            var task = await _taskService.GetTaskByIdAsync(id);
            if (task == null)
                return NotFound(new { message = $"Task with ID {id} not found." });

            return Ok(task);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Unexpected error", detail = ex.Message });
        }
    }

    /// <summary>
    /// Creates a new task.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Create(TaskItem task)
    {
        try
        {
            await _taskService.CreateTaskAsync(task);
            return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
        }
        catch (DbUpdateException ex) when (ex.InnerException?.Message.Contains("PRIMARY KEY") == true)
        {
            return Conflict(new { message = "Task with the same ID already exists." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Unexpected error", detail = ex.Message });
        }
    }

    /// <summary>
    /// Updates an existing task.
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, TaskItem task)
    {
        if (id != task.Id)
            return BadRequest(new { message = "ID in URL does not match ID in payload." });

        try
        {
            await _taskService.UpdateTaskAsync(task);
            return NoContent();
        }
        catch (DbUpdateConcurrencyException)
        {
            return NotFound(new { message = $"Task with ID {id} not found or already deleted." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Unexpected error", detail = ex.Message });
        }
    }

    /// <summary>
    /// Deletes a task by ID.
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await _taskService.DeleteTaskAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Unexpected error", detail = ex.Message });
        }
    }
}