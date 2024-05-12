namespace TemperatureMonitor.Util
{
    public class FanSpeedCalculator
    {
        // Y axis
        private int spdMin;
        private int spdMid;
        private int spdMax;

        // X axis
        private int tempMin;
        private int tempMid;
        private int tempMax;

        public FanSpeedCalculator()
        {
            spdMin = 0;
            spdMid = 50;
            spdMax = 100;
            tempMin = 0; 
            tempMid = 50;
            tempMax = 100;
        }
        public int CalculateLinearSpeed(int x)
        {
            // slope = (y2 - y1)/(x2 - x1)
            // then f(x) = mx + b, where m is slope
            // substitue points, y2 & x2 or y1 & x1 to get b
            float m;
            if (x < tempMin)
            {
                return spdMin;
            }
            else if (x >= tempMin && x <= tempMid)
            {
                m = (float) (spdMid - spdMin) / (float) (tempMid - tempMin);
            }
            else if (x > tempMid && x <= tempMax)
            {
                m = (float)(spdMax - spdMid) / (float)(tempMax - tempMid);
            }
            else
            {
                return spdMax;
            }

            // y = mx + b
            // b = y - mx
            float b = (float)spdMid - (m * (float)tempMid);

            return (int)((m * x) + b);
            //return (int)Math.Round((m * x) + b, 0);
        }

        public int CalculateExponentalSpeed(int x)
        {
            if (x < tempMin)
            {
                return spdMin;
            }
            else if (x > tempMax)
            {
                return spdMax;
            } else
            {
                return (int) Math.Pow(x, 2)/100;
            }
        }
        public int CalculateSinSilentSpeed(int x)
        {
            if (x < tempMin)
            {
                return spdMin;
            }
            else if (x > tempMax)
            {
                return spdMax;
            }
            else
            {
                return (int) (100 * Math.Sin((double)x / 200 * Math.PI + 300.02) + 100);
            }
        }
        public int CalculateArcSinSpeed(int x)
        {
            if (x < tempMin)
            {
                return spdMin;
            }
            else if (x > tempMax)
            {
                return spdMax;
            }
            else
            {
                return (int)(100 * Math.PI / 5 * Math.Asin((double)x / 100));
            }
        }
        // SETTERS

        public void SetSpeedMin(int spdMin)
        {
            this.spdMin = spdMin;
        }
        public void SetSpeedMid(int spdMid)
        {
            this.spdMid = spdMid;
        }
        public void SetSpeedMax(int spdMax)
        {
            this.spdMax = spdMax;
        }
        public void SetTempMin(int tempMin)
        {
            this.tempMin = tempMin;
        }
        public void SetTempMid(int tempMid)
        {
            this.tempMid = tempMid;
        }
        public void SetTempMax(int tempMax)
        {
            this.tempMax = tempMax;
        }

        // GETTERS

        public int GetSpeedMin()
        {
            return spdMin;
        }
        public int GetSpeedMid()
        {
            return spdMid;
        }
        public int GetSpeedMax()
        {
            return spdMax;
        }
        public int GetTempMin()
        {
            return tempMin;
        }
        public int GetTempMid()
        {
            return tempMid;
        }
        public int GetTempMax()
        {
            return tempMax;
        }

    }
}
