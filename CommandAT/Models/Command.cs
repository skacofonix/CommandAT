using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CommandAT.Models
{
    public class Command
    {
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string name = string.Empty;

        public string Content
        {
            get { return content; }
            set { content = value; }
        }
        private string content = string.Empty;

        public bool EnableLoop
        {
            get { return enableLoop; }
            set { enableLoop = value; }
        }
        private bool enableLoop = false;

        public int NumberOfLoop
        {
            get { return numberOfLoop; }
            set { numberOfLoop = value; }
        }
        private int numberOfLoop = 0;

        public int DelayBetweenLoop
        {
            get { return delayBetweenLoop; }
            set { delayBetweenLoop = value; }
        }
        private int delayBetweenLoop = 1000;

        public override string ToString()
        {
            return Name;
        }
    }
}