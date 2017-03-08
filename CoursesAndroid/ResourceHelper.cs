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
using System.Reflection;

namespace CoursesAndroid
{
    class ResourceHelper
    {
        static Dictionary<String, int> resourceDictionary = new Dictionary<string, int>();

        public static int TranslateDrawable(String drawableName)
        {
            int resourceValue = -1;

            switch (drawableName)
            {
                case "Chrysanthemum":
                    resourceValue = Resource.Drawable.Chrysanthemum;
                    break;
                case "Hydrangeas":
                    resourceValue = Resource.Drawable.Hydrangeas;
                    break;
                case "Icon":
                    resourceValue = Resource.Drawable.Icon;
                    break;
                case "Tulips":
                    resourceValue = Resource.Drawable.Tulips;
                    break;
            }

            return resourceValue;
        }

        public static int TranslateDrawableWithReflection(String drawableName)
        {
            int resourceValue = -1;

            if(resourceDictionary.ContainsKey(drawableName))
            {
                resourceValue = resourceDictionary[drawableName];
            }
            else
            {
                Type drawableType = typeof(Resource.Drawable);
                FieldInfo resourceFieldInfo = drawableType.GetField(drawableName);

                resourceValue = (int)resourceFieldInfo.GetValue(null);

                resourceDictionary.Add(drawableName, resourceValue);
            }

            return resourceValue;
        }
    }
}