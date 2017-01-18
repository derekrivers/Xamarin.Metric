namespace Metric
{
    public class SimpleTabColorizer : SlidingTabScrollView.TabColorizer
    {
        private int[] mIndicatorColors;
        private int[] mDivideColors;

        public int GetIndicatorColor(int position)
        {
            return mIndicatorColors[position % mIndicatorColors.Length];
        }

        public int GetDividerColors(int position)
        {
            return mDivideColors[position % mDivideColors.Length];
        }

        public int[] IndicatorColors
        {
            set { mIndicatorColors = value; }
        }

        public int[] DividerColors
        {
            set { mDivideColors = value; }
        }
    }
}