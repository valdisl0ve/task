using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo
{
    class Todo_table
    {
        public int id { get; set; }
        private string name, task, date;
        private int priority;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Task
        {
            get { return task; }
            set { task = value; }
        }

        public string Date
        {
            get { return date; }
            set { date = value; }
        }


        public int Priority
        {
            get { return priority; }
            set { priority = value; }
        }




        public Todo_table() { }



        public Todo_table(string name, string task, int priority)
        {

            this.name = name;
            this.task = task;
            this.priority = priority;

        }


        public Todo_table(string name, string task, string date, int priority) {

            this.name = name;
            this.task = task;
            this.date = date;
            this.priority = priority;
        
       }


    }
}
