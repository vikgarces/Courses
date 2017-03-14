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
    class CourseCategoryManagerAdapter : BaseAdapter<CourseCategory>
    {
        Context context;
        int layoutResourceId;
        CourseCategoryManager courseCategoryManager;

        public CourseCategoryManagerAdapter(Context context,
            int layoutResourceId, CourseCategoryManager courseCategoryManager)
        {
            this.context = context;
            this.layoutResourceId = layoutResourceId;
            this.courseCategoryManager = courseCategoryManager;
        }

        public override CourseCategory this[int position]
        {
            get
            {
                courseCategoryManager.MoveTo(position);
                return courseCategoryManager.Current;
            }
        }

        public override int Count
        {
            get
            {
                return courseCategoryManager.Length; 
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
            {
                LayoutInflater inflater = 
                    context.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;
                view = inflater.Inflate(layoutResourceId, null);
            }

            TextView textView = view.FindViewById<TextView>(Android.Resource.Id.Text1);

            textView.Text = this[position].Title;

            return view;
        }
    }
}