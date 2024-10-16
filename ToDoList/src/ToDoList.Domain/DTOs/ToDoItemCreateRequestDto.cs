namespace ToDoList.Domain.DTOs;

using ToDoList.Domain.Models;

public record ToDoItemCreateRequestDto(string Name, string Description, bool IsCompleted) //specialni struktura, ktera se dokaze serializovat
{
    public ToDoItem ToDomain() {
        return new ToDoItem {
            Name = this.Name,
            Description = this.Description,
            IsCompleted = this.IsCompleted
        };
    }
}
