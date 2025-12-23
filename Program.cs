using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTrackerCLI;

List<TaskObj> exisitngTasks = JsonHandler.LoadTask();

TaskService a = new TaskService(exisitngTasks);




if (args.Length == 0)
{
    Console.WriteLine("No commands provided. Use 'help' to see command options");
    return;
}

string output = "";
string command = args[0].ToLower();

switch (command)
{
    case "add":
        if (args.Length < 2)
        {
            output = "Please provide a description for the task.";
        }
        else
        {
            string fulldescription = string.Join(" ", args.Skip(1));
            string response = a.AddTask(fulldescription);
            output = response;
        }
        break;

    case "update":
        if (args.Length < 3)
        {
            output = "Please provide id and new description";
        }
        else
        {
            string item = args[1];
            int id;
            bool itemtoInt = int.TryParse(item, out id);
            if (itemtoInt == false)
            {
                output = "Invalid id format. Please provide a numeric id.";
            }
            else 
            {
                string fulldescription = "";
                for (int i = 2; i < args.Length; i++)
                {
                    fulldescription += args[i] + " ";
                }
                string response = a.UpdateTask(id,fulldescription);
                output = response;
            }
        }
        break;

    case "delete":
        if (args.Length < 2)
        {
           output = "Please provide an id!";
        }
        else
        {
            string item = args[1];
            int id;
            bool itemtoInt = int.TryParse(item, out id);
            if(itemtoInt == false)
            {
                output = "please enter a number for the ID";
            }
            else
            {
                string response = a.DeleteTask(id);
                output = response;
            }
        }
        break;

    case "mark-in-progress":
        if (args.Length < 2)
        {
            output = "please provide an id!";
        }
        else
        {
            string item = args[1];
            int id;
            bool itemtoInt = int.TryParse(item, out id);
            if (itemtoInt == false)
            {
                output = "Please enter a number for the ID";
            }
            else
            {
                string response = a.MarkInProgress(id);
                output = response;
            }
        }
        break;

    case "mark-done":
        if (args.Length < 2)
        {
            output = "please provide an id!";
        }
        else
        {
            string item = args[1];
            int id;
            bool itemtoInt = int.TryParse(item, out id);
            if (itemtoInt == false)
            {
                output = "Please enter a number for the ID";
            }
            else
            {
                string response = a.MarkDone(id);
                output = response;
            }
        }
        break;

    case "list":
        if (args.Length == 1)
        {
            var showlist = TaskObj.ShowTasksList(exisitngTasks);
            output = string.Join("\n\n", showlist);
        }
        else if (args.Length == 2)
        {
            if (args[1].ToLower() == "todo")
            {
                var showlist = a.ListByStatus("todo");
                output = string.Join("\n\n", showlist);
            }
            else if (args[1].ToLower() == "in-progress")
            {
                var showlist = a.ListByStatus("in-progress");
                output = string.Join("\n\n", showlist);
            }
            else if (args[1].ToLower() == "done")
            {
                var showlist = a.ListByStatus("done");
                output = string.Join("\n\n", showlist);
            }
            else if (args[1].ToLower() == "not-done")
            {
                var showlist = a.ListByStatus("not-done");
                output = string.Join("\n\n", showlist);
            }
            else
            {
                output = "Invalid status. Use 'todo', 'in-progress', or 'done'.";
            }
        }
        else
        {
            output = "Invalid command. Write 'help' for all commands";
        }
        break;

    case "help":
        output = "Available commands:\n" +
                    "add <description> - Add a new task with the given description.\n" +
                    "update <id> <new description> - Update the task with the given id.\n" +
                    "delete <id> - Delete the task with the given id.\n" +
                    "mark-in-progress <id> - Mark the task with the given id as in-progress.\n" +
                    "mark-done <id> - Mark the task with the given id as done.\n" +
                    "list - List all tasks.\n" +
                    "list todo - List all tasks with status 'todo'.\n" +
                    "list in-progress - List all tasks with status 'in-progress'.\n" +
                    "list done - List all tasks with status 'done'.\n" +
                    "list not-done - List all tasks with status 'todo' and 'in-progress'.\n" +
                    "help - Show this help message.";
        break;

}

Console.WriteLine(output);

JsonHandler.SaveTask(exisitngTasks);
