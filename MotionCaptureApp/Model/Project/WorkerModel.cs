using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionCaptureApp.Model.Project
{
    public class WorkerModel : ModelInterface
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Gender { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string ProcessGrouop { get; set; }

        public WorkerModel(string name, int age, int gender, double height, double weight, string processGroup)
        {
            Name = name;
            Age = age;
            Gender = gender;
            Height = height;
            Weight = weight;
            ProcessGrouop = processGroup;
        }

        public string toInsertQueryString()
        {
            return string.Format("INSERT INTO WorkerModel (name, age, gender, height, weight) " +
                "VALUES ('{0}', {1}, {2}, {3}, '{4}')", Name, Age, Gender, Height, Weight);
        }
    }
}
