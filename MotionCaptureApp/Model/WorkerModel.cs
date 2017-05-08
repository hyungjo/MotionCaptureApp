using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionCaptureApp.Model
{
    class WorkerModel : ModelInterface
    {
        public string Name { get; set; }
        public byte Age { get; set; }
        public bool Gender { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }

        public WorkerModel(string name, byte age, bool gender, float height, float weight)
        {
            Name = name;
            Age = age;
            Gender = gender;
            Height = height;
            Weight = weight;
        }

        public string toInsertQueryString()
        {
            return string.Format("INSERT INTO ProcessModel (name, age, gender, height, weight) " +
                "VALUES ({0}, {1}, {2}, {3}, {4})", Name, Age, Gender, Height, Weight);
        }
    }
}
