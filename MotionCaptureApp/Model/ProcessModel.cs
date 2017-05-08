using MotionCaptureApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MotionCaptureApp.Model
{
    class ProcessModel : ModelInterface
    {
        public string Name { get; set; }
        public string Explanation { get; set; }
        
        public ProcessModel(string name, string explanation)
        {
            Name = name;
            Explanation = explanation;
        }

        public string toInsertQueryString()
        {
            return string.Format("INSERT INTO ProcessModel (name, explanation) " +
                "VALUES ({0}, {1})", Name, Explanation);
        }

    }
}
