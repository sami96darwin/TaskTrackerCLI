# TaskTrackerCLI

A simple **Command-Line Interface (CLI)** application for managing tasks.  
You can add, update, delete, mark tasks as in-progress or done, and list tasks based on their status.  
All tasks are saved in a JSON file (`data.json`) to ensure persistence between sessions.

---

## Features

- Add a task with a description
- Update a task description by ID
- Delete a task by ID
- Mark tasks as in-progress or done
- List tasks by status (`todo`, `in-progress`, `done`, `not-done`) or all tasks
- Persistent storage in a JSON file (`data.json`)
- Help command to display all available commands

---

## Installation

### 1. Clone the repository:

```bash
git clone <repository-url>
```
### 2. Open the project in Visual Studio, Rider, or VS Code with C# extensions.

### 3. Build the project:

```bash
dotnet build
```
### 4.Run the application:

```bash
dotnet run -- <command> [arguments]
```

---

## Usage

### General Syntax

```bash
dotnet run -- <command> [arguments]
```

### Commands

- `add` — Add a new task with the given description  
- `update <id>` — Update the task with the specified ID  
- `delete <id>` — Delete the task with the specified ID  
- `mark-in-progress` — Mark the task with the specified ID as in-progress  
- `mark-done` — Mark the task with the specified ID as done  
- `list` — List all tasks  
- `list todo` — List all tasks with status todo  
- `list in-progress` — List all tasks with status in-progress  
- `list done` — List all tasks with status done  
- `list not-done` — List all tasks that are not done (todo or in-progress)  
- `help` — Display the help message

### Examples

```bash
Add a task:
dotnet run -- add "Finish C# project"

Update a task description:
dotnet run -- update 1 "Finish C# project with README"

Mark a task as in-progress:
dotnet run -- mark-in-progress 1

Mark a task as done:
dotnet run -- mark-done 1

List all tasks:
dotnet run -- list

List tasks with status todo:
dotnet run -- list todo
```

---

## File Structure

```graphql
TaskTrackerCLI/
├── Program.cs        # Main CLI entry point
├── TaskService.cs    # Task management logic
├── TaskObj.cs        # Task model
├── JsonHandler.cs    # JSON load/save logic
├── data.json         # Stores tasks persistently
└── README.md         # Project documentation
```
---

## Notes

- **Automatic Task IDs:** Each task is assigned a unique ID automatically, which increments with every new task.  
- **Centralized Output:** All program output is managed through the `Main` method in `Program.cs` for consistency.  
- **Persistent Storage:** If `data.json` does not exist, it will be created automatically the first time a task is added, ensuring your tasks are saved between sessions.

---

https://roadmap.sh/projects/task-tracker
