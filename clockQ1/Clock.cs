using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace clockQ1
{
    class Clock
    {
        private readonly string _time;

        public Clock(string Time)
        {
            _time = Time;
        }

        private bool VerifyTime()
        {
            return Regex.IsMatch(_time, "^(0[1-9]|1[0-2]):[0-5][0-9]$");
        }

        private float getAngle()
        {
            float hourBaseDegree = (float.Parse(_time.Substring(0, 2)) * 30) % 360;

            float hoursDeg = hourBaseDegree + (hourBaseDegree / 12);
            int minutesDeg = int.Parse(_time.Substring(3, 2)) * 6;

            float diffAngle = Math.Abs(hoursDeg - minutesDeg);

            if(diffAngle >= 180)
            {
                return 360 - diffAngle;
            }
            return diffAngle;
        }

        public void SolveAngle()
        {
            if(VerifyTime())
            {
                float solution = getAngle();
                Console.WriteLine("the answer is: " + solution.ToString());
            }
            else
            {
                Console.WriteLine("the time format you entered is not valid, check that you included \"0\" and \":\"");
            }
        }
    }
}
