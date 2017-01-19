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

namespace Metric
{
 

    public class ConversionGroupListAdapter : BaseAdapter<Conversion>
    {

        private List<Conversion> mItems;
        private Context mContext;


        public ConversionGroupListAdapter(Context context, List<Conversion> items)
        {
            mContext = context;
            mItems = items;
        }

        public override Conversion this[int position]
        {
            get
            {
                return mItems[position];
            }
        }

        public override int Count
        {
            get
            {
                return mItems.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.listview_row, null, false);

                TextView txtMetric = row.FindViewById<TextView>(Resource.Id.txtMetric);
                TextView txtConversion = row.FindViewById<TextView>(Resource.Id.txtConversion);

                txtMetric.Text = mItems[position].Metric;
                txtConversion.Text = mItems[position].ConversionValue;


            }

            return row;
        }
    }
}