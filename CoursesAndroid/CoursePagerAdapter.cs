using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using CoursesLibrary;

namespace CoursesAndroid 
{
    class CoursePagerAdapter :  FragmentStatePagerAdapter
    {
        public CoursePagerAdapter(FragmentManager fm, CourseManager courseManager)
            :base(fm)
        {
            this.courseManager = courseManager;
        }

        CourseManager courseManager;

        public override Android.Support.V4.App.Fragment GetItem(int position)
        {
            courseManager.MoveTo(position);
            CourseFragment courseFragment = new CourseFragment();
            courseFragment.Course = courseManager.Current;

            return courseFragment;
        }

        public override int Count
        {
            get { return courseManager.Length; }
        }

        

    }
}