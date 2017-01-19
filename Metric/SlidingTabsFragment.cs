using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V4.View;
using Java.Lang;
using System;
using Android.Content;

namespace Metric
{
    public class SlidingTabsFragment : Fragment
    {
        private SlidingTabScrollView mSlidingTabScrollView;
        private ViewPager mViewPager;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment

            return inflater.Inflate(Resource.Layout.fragment_sample, container, false);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            mSlidingTabScrollView = view.FindViewById<SlidingTabScrollView>(Resource.Id.sliding_tabs);
            mViewPager = view.FindViewById<ViewPager>(Resource.Id.viewpager);
            mViewPager.Adapter = new SamplePagerAdapter();
            mSlidingTabScrollView.ViewPager = mViewPager;
        }

        public class SamplePagerAdapter : PagerAdapter
        {
            List<string> items = new List<string>();


            public SamplePagerAdapter() : base()
            {
                items.Add("Cups");
                items.Add("Ounces");
                items.Add("Litres");
                items.Add("Cans");
            }

            public override int Count
            {
                get { return items.Count; }
            }

            public override bool IsViewFromObject(View view, Java.Lang.Object obj)
            {
                return view == obj;
            }

            public override Java.Lang.Object InstantiateItem(ViewGroup container, int position)
            {
                View view = LayoutInflater.From(container.Context).Inflate(Resource.Layout.page_item, container, false);
                container.AddView(view);

                ListView listView = view.FindViewById<ListView>(Resource.Id.listView);

                var dataService = new ConversionGroupService();

                var group = dataService.GetById(1);

                if(group != null)
                {
                    ConversionGroupListAdapter adapter = new ConversionGroupListAdapter(view.Context, group.Conversions);

                    listView.Adapter = adapter;
                }


                return view;
            }

            //public override Java.Lang.Object InstantiateItem(ViewGroup container, int position)
            //{
            //    View view = LayoutInflater.From(container.Context).Inflate(Resource.Layout.pager_item, container, false);
            //    container.AddView(view);

            //    TextView txtTitle = view.FindViewById<TextView>(Resource.Id.item_title);
            //    int pos = position + 1;

            //    txtTitle.Text = pos.ToString();

            //    return view;
            //}

            public string GetHeaderTitle(int position)
            {
                return items[position];
            }

            public override void DestroyItem(ViewGroup container, int position, Java.Lang.Object obj)
            {
                container.RemoveView((View)obj);
            }
        }
    }
}