using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.IO;
using System.Threading.Tasks;

namespace TaskTrackerCLI
{
    public static class JsonHandler
    {
        public static readonly string filePath = "data.json";

        public static void SaveTask(List<TaskObj> tasks) 
        {
            string jsonString = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true});
            File.WriteAllText(filePath, jsonString);
        }

        public static List<TaskObj> LoadTask()
        {
            if (!File.Exists(filePath))
            {
                return new List<TaskObj>();
            }
            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<TaskObj>>(jsonString) ?? new List<TaskObj>();
        }
    }
}
