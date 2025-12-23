using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.IO.Pipes;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TaskTrackerCLI
{
    public class TaskService
    {
        public List<TaskObj> tasks = new List<TaskObj>();


        public TaskService(List<TaskObj> existingTasks)
        {
            tasks = existingTasks;
        }

        public int GetHighestId()
        {
            if (tasks.Count == 0)
            {
                return 0;
            }
            return tasks.Max(t => t.Id);
        }

        public string AddTask(string description)
        {

            int id = GetHighestId() + 1;
            TaskObj newTask = new TaskObj(id, description, "todo");
            tasks.Add(newTask);
            return $"task added with description: {description} (Todo)";
        }

        public string UpdateTask(int id, string description)
        {
            var updateItem = tasks.SingleOrDefault(u => u.Id == id);

            if (updateItem != null)
            {

                updateItem.Description = description;
                updateItem.UpdatedAt = DateTime.Now;
            }
            else
            {
                return $"The task with that {id} doesnt exist please try again";
            }

            return $"Task with id: {id} has been updated with new Description: {description}";
        }

        public string DeleteTask(int id)
        {
            var removeItem = tasks.SingleOrDefault(r => r.Id == id);

            if (removeItem != null)
            {
                tasks.Remove(removeItem);
                return $"Task with id: {id} has been deleted succesfully";
            }
            else
            {
                return $"Task with id: {id} has not been deleted.";
            }
        }

        public string MarkInProgress(int id)
        {
            var progress = tasks.SingleOrDefault(i => i.Id == id);
            if (progress != null)
            {
                progress.Status = "in-progress";
                progress.UpdatedAt = DateTime.Now;
            }
            else
            {
                return $"The task id does not exist or you have put in wrong task id please try again";
            }
            return $"The task with ID:{id} has been marked as 'in-progress'";
        }

        public string MarkDone(int id)
        {
            var done = tasks.SingleOrDefault(d => d.Id == id);
            if (done != null)
            {
                done.Status = "done";
                done.UpdatedAt = DateTime.Now;
            }
            else
            {
                return $"The task id does not exist or you have put in wrong task id please try again";
            }

            return $"The task with ID:{id} has been marked as 'done'";
        }

        public List<string> ListByStatus(string status)
        {
            status = status.ToLower();
            List<string> result = new List<string>();

            if (status == "todo")
            {
                var findtodo = tasks.
                     Where(s => s.Status == "todo")
                     .Select(s => s);

                foreach (var item in findtodo)
                {
                    result.Add(item.ToString());
                }
            }
            else if (status == "in-progress")
            {
                var findinprogress = tasks.
                    Where(a => a.Status == "in-progress")
                    .Select(a => a);

                foreach (var item in findinprogress)
                {
                    result.Add(item.ToString());
                }
            }
            else if (status == "done")
            {
                var finddone = tasks.
                     Where(d => d.Status == "done")
                     .Select(d => d);

                foreach (var item in finddone)
                {
                    result.Add(item.ToString());
                }
            }
            else if (status == "not-done")
            {
                var findnotdone = tasks.
                     Where(n => n.Status != "done")
                     .Select(n => n);

                foreach (var item in findnotdone)
                {
                    result.Add(item.ToString());
                }
            }

            return result;

        }

        public int IdCheacker(string id)
        {
            int newId;
            bool idIsInt = int.TryParse(id, out newId);
            if (idIsInt == false)
            {
                throw new ArgumentException("Invalid id format. Please provide a numeric id.");
            }
            else
            {
                return newId;
            }
        }


    }
}
