namespace TemperatureMonitor
{
    internal class ColorCalculator
    {
        public Color computeColor(double temp)
        {
            int low = 20;
            int max = 100;
            int mid = 60;
            int range = max - low;

            if (temp < 0)
            {
                return Color.FromArgb(255, 255, 255); // when all else fails
            }

            if (temp <= low)
            {
                return Color.FromArgb(0, 192, 0);
            }
            else if (temp >= max)
            {
                return Color.FromArgb(192, 0, 0);
            }
            else if (temp >= mid) // orangish
            {
                return Color.FromArgb(192, (int)(((((max - temp) / 10) / 4) * 255) * 0.75), 0);
            }
            else if (temp < mid) // yellowgreen
            {
                return Color.FromArgb((int)(((1 - (((mid - temp) / 10) / 4)) * 255) * 0.75), 192, 0);
            }
            else
            {
                return Color.FromArgb(255, 255, 255); // when all else fails
            }
        }
    }
}
