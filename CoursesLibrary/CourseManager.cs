using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesLibrary
{
    public class CourseManager
    {
        private readonly Course[] courses;
        int currentIndex = 0;
        private readonly int lastIndex;
        public CourseManager()
        {
            courses = InitCourses();
            lastIndex = courses.Length -1;
        }

        private Course[] InitCourses()
        {
            var initCourses = new Course[] {
                new Course()
                {
                    Title = "Android for .NET Developers",
                    Description = "Provides an overview of the tools used in the Android " +
                    "development process including the newly released Android Studio.",
                    Image = "Tulips"
                },

                new Course()
                {
                    Title = "Android Dreams, Widgets, Notifications",
                    Description = "Provide users with a rich and interactive experience " +
                    "without ever requiring them to open your app.",
                    Image = "Chrysanthemum"
                },
                new Course()
                {
                    Title = "Android Photo/Video Programming",
                    Description = "Learn how to capitalize on the Android camera " +
                    "within your apps to capture still photos and video.",
                    Image = "Hydrangeas"
                },
                new Course()
                {
                    Title = "Android Location-Based Apps",
                    Description = "Cover the wide range of Android location capabilities " +
                    "including determining user location, power management, and " +
                    "translating location data to human-readable addresses.",
                    Image = "Icon"
                }

            };

            return initCourses;
        }

        public int Length
        {
            get { return courses.Length; }
        }

        public void MoveFirst()
        {
            currentIndex = 0;
        }

        public void MovePrev()
        {
            if(currentIndex > 0)
                --currentIndex;
        }

        public void MoveNext()
        {
            if (currentIndex < lastIndex)
                ++currentIndex;
        }

        public void MoveTo(int position)
        {
            if (position >= 0 && position <= lastIndex)
                currentIndex = position;
            else
                throw new IndexOutOfRangeException(
                    String.Format("{0} is an invalid position. Must be between 0 and {1}",
                    position, lastIndex));
        }

        public Course Current
        {
            get { return courses[currentIndex]; }
        }

        public Boolean CanMovePrev
        {
            get { return currentIndex > 0; }
        }

        public Boolean CanMoveNext
        {
            get { return currentIndex < lastIndex; }
        }
    }
}
