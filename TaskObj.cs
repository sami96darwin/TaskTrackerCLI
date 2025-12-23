using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTrackerCLI
{
    public class TaskObj
    {
        public int Id { get; set; }

        public string Description { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public TaskObj()
        {
        }

        public TaskObj(int id, string desc, string status)
        {
            Id = id;
            Description = desc;
            Status = status;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public string ShowTask()
        {
            string result = $"ID: {Id} \nDescription: {Description} \nStatus: {Status} \n"+
                $"Created: {CreatedAt} \nUpdated: {UpdatedAt}";
            return result;
        }

        public override string ToString()
        {
            return $"ID: {Id} \nDescription: {Description} \nStatus: {Status} \n" +
                $"Created: {CreatedAt} \nUpdated: {UpdatedAt}";
        }

        public static List<string> ShowTasksList(List<TaskObj> tasks) 
        {
            List<string> result = new List<string>();
            foreach (var task in tasks)
            {
                result.Add(task.ToString());
            }
            return result;
        }



    }
}
