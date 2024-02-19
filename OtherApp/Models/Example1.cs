using OtherApp.Classes;
using System.ComponentModel;

namespace OtherApp.Models;

    // before C# 5
    internal class Example1
    {
        [DefaultValue(true)]
        public bool Active { get; set; }
        [DefaultValue("Good")]
        public string Mood { get; set; }
        [DefaultValue(1)]
        public int Rating { get; set; }

        public Example1()
        {
            this.ApplyDefaultValues();
        }
    }

    // Afterwards
    internal class Example2
    {
        public bool Active { get; set; } = true;
        public string Mood { get; set; } = "Good";
        public int Rating { get; set; } = 1;
    }


