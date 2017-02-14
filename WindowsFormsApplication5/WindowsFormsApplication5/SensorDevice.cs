using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication5
{
    class SensorDevice
    {
        static Random rand = new Random();
        public int Resolution { get; set; }
        public double MinRange { get; set; }
        public double MaxRange { get; set; }
        public int SensorID { get; set; }

        public SensorDevice(int res, double minR, double maxR)
        {
            Resolution = res;
            MinRange = minR;
            MaxRange = maxR;
            
        }

        /// <summary>
        /// This Method Helps in simulation of Random Temperature
        /// </summary>
        /// <returns></returns>
        public double SimulatedTemp()
        {
            int maxRes = (int)Math.Pow(2, Resolution);
            double R = rand.Next(1,maxRes);
            return Math.Round((R - 1) * (MaxRange - MinRange) / (maxRes - 1) + MinRange, 3);
        }
    }
}
