using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication5
{
    class SensorDevice
    {
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
        Random rand = new Random();
        public double SimulatedTemp()
        {
            int maxres = (int)Math.Pow(2, Resolution);
            double R = rand.Next(1,maxres);
            return (R - 1) * (MaxRange - MinRange) / (maxres - 1) + MinRange;
        }
    }
}
