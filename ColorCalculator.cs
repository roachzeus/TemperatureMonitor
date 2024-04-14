namespace TemperatureMonitor
{
    public class ColorCalculator
    {
        public const string DarkLevelInvalid = "Dark level should be between 0 and 1";

        private float darkLevel = 0.25F; // default one fourth

        // percent of how much is subtracted from 255 (256)
        // 0 being 255 - 0 = 255
        // 1 being 255 - 255 = 0
        public void SetDarkLevel(float darkLevel)
        {
            if (darkLevel < 0 || darkLevel > 1) 
            {
                throw new ArgumentException(DarkLevelInvalid);
            }

            this.darkLevel = darkLevel;
        }

        public Color ComputeTemperatureColor(double temp)
        {
            return Compute(temp, 20, 100);
        }
        public Color ComputeLoadColor(double load)
        {
            return Compute(load, 0, 100);
        }
        public Color White()
        {
            return Color.FromArgb((int)(255 * (1 - darkLevel)),
                (int)(255 * (1 - darkLevel)),
                (int)(255 * (1 - darkLevel)));
        }

        public Color ComputeFanSpeedColor(double rpm)
        {
            return Compute(rpm, 200, 2000);
        }
        private Color Compute(double value, int min, int max)
        {
            float mid = (min + max) / 2;
            float inc = max - mid;
            if (value < 0)
            {
                return Color.FromArgb(255, 255, 255); // for value such as -1
            }

            if (value <= min)
            {
                return Color.FromArgb(0, (int)(255 * (1 - darkLevel)), 0);
            }
            else if (value >= max)
            {
                return Color.FromArgb((int)(255 * (1 - darkLevel)), 0, 0);
            }
            else if (value >= mid) // orangish
            {
                return Color.FromArgb((int)(255 * (1 - darkLevel)),
                    (int)((max - value) / inc * 255 * (1 - darkLevel)),
                    0);
            }
            else if (value < mid) // yellowgreen
            {
                return Color.FromArgb((int)((1 - ((mid - value) / inc)) * 255 * (1 - darkLevel)),
                    (int)(255 * (1 - darkLevel)),
                    0);
            }
            else
            {
                return Color.FromArgb(0, 0, 0); // should never come here
            }
        }
    }
}
