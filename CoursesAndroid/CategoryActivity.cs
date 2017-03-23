using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CoursesLibrary;

namespace CoursesAndroid
{
//    [Activity(Label = "Courses", MainLauncher = true, Icon = "@drawable/icon")]

    public class CategoryActivity : ListActivity
    {
        CourseCategoryManager courseCategoryManager;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            //String[] categoryTitles = { "Category 1", "Category 2", "Category 3"};

            //ListAdapter =
            //    new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, categoryTitles);

            courseCategoryManager = new CourseCategoryManager();
            ListAdapter =
                new CourseCategoryManagerAdapter(this, Android.Resource.Layout.SimpleListItem1, courseCategoryManager);
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            Intent intent = new Intent(this, typeof(CourseActivity));

            courseCategoryManager.MoveTo(position);
            String categoryTitle = courseCategoryManager.Current.Title;

            intent.PutExtra(CourseActivity.DISPLAY_CATEGORY_TITLE_EXTRA, categoryTitle);

            StartActivity(intent);
        }

    }
}