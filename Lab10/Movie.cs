using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    public class Movie
    {
        public string Title;
        public string Category;

        public Movie(string title, string category)
        {
            Title1 = title;
            Category1 = category;
        }

        public string Title1
        {
            get
            {
                return Title;
            }

            set
            {
                Title = value;
            }
        }

        public string Category1
        {
            get
            {
                return Category;
            }

            set
            {
                Category = value;
            }
        }

        ////public bool findTitle(string title)
        //{
        //    if (title == Title1)
        //        return true;
        //        else return false;
        //    }

      
        
    }
}
