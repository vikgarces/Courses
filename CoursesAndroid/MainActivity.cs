using Android.App;
using Android.Widget;
using Android.OS;
using System;
using CoursesLibrary;
using CoursesAndroid;

namespace Courses
{
    //[Activity(Label = "Courses", MainLauncher = true, Icon = "@drawable/icon")]

    public class MainActivity : Activity
    {
        Button buttonPrev;
        Button buttonNext;
        TextView textTitle;
        ImageView imageCourse;
        TextView textDescription;
        CourseManager courseManager;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            buttonPrev = FindViewById<Button>(Resource.Id.buttonPrev);
            buttonNext = FindViewById<Button>(Resource.Id.buttonNext);
            textTitle = FindViewById<TextView>(Resource.Id.textTitle);
            imageCourse = FindViewById<ImageView>(Resource.Id.imageCourse);
            textDescription = FindViewById<TextView>(Resource.Id.textDescription);

            buttonNext.Click += buttonNext_Click;
            buttonPrev.Click += buttonPrev_Click;

            courseManager = new CourseManager();
            courseManager.MoveFirst();
            UpdateUI();
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            courseManager.MovePrev();
            UpdateUI();
            //textTitle.Text = "Prev Clicked";
            //textDescription.Text = "The description that appears when Prev is clicked";
            //imageCourse.SetImageResource(Resource.Drawable.Tulips);
            //throw new NotImplementedException();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            courseManager.MoveNext();
            UpdateUI();
            //textTitle.Text = "Next Clicked";
            //textDescription.Text = "The description that appears when Next is clicked";
            //imageCourse.SetImageResource(Resource.Drawable.Hydrangeas);
            //throw new NotImplementedException();
        }

        private void UpdateUI()
        {
            textTitle.Text = courseManager.Current.Title;
            textDescription.Text = courseManager.Current.Description;
            imageCourse.SetImageResource(
                ResourceHelper.TranslateDrawableWithReflection(courseManager.Current.Image));
            buttonPrev.Enabled = courseManager.CanMovePrev;
            buttonNext.Enabled = courseManager.CanMoveNext;
        }
    }
}

