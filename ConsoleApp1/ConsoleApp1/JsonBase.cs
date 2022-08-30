using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace ConsoleApp1
{
    internal class JsonBase
    {
        
        public void WriteJson(List<Project> Projects)
        {
            string fileName = @"C:\Users\улгас\Desktop\WeatherForecast.json";
            string jsonString = JsonSerializer.Serialize(Projects);
            File.WriteAllText(fileName, jsonString);

        }

        public List<Project> ReadJson(List<Project> Projects)
        {
            string fileName = @"C:\Users\улгас\Desktop\WeatherForecast.json";
            using FileStream openStream = File.OpenRead(fileName);
            Projects = JsonSerializer.Deserialize<List<Project>>(openStream);
            return Projects;
        }

    }

}
