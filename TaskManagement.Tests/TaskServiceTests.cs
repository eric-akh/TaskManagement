using Moq;
using TaskManagement.Application.Services;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;
using Xunit;

namespace TaskManagement.Tests;

public class TaskServiceTests
{
    private readonly Mock<ITaskRepository> _mockRepo;
    private readonly TaskService _service;

    public TaskServiceTests()
    {
        _mockRepo = new Mock<ITaskRepository>();
        _service = new TaskService(_mockRepo.Object);
    }

    [Fact]
    public async Task GetAllTasksAsync_ReturnsTasks()
    {
        // Arrange
        var mockTasks = new List<TaskItem>
        {
            new() { Id = Guid.NewGuid(), Title = "Test Task 1" },
            new() { Id = Guid.NewGuid(), Title = "Test Task 2" }
        };

        _mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(mockTasks);

        // Act
        var result = await _service.GetAllTasksAsync();

        // Assert
        Assert.Equal(2, result.Count());
        Assert.Contains(result, t => t.Title == "Test Task 1");
    }

    [Fact]
    public async Task CreateTaskAsync_CallsAddAsyncOnce()
    {
        // Arrange
        var task = new TaskItem { Id = Guid.NewGuid(), Title = "New Task" };

        // Act
        await _service.CreateTaskAsync(task);

        // Assert
        _mockRepo.Verify(r => r.AddAsync(task), Times.Once);
    }
}