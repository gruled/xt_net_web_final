using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public static class Variables
    {
        public static int UserId { get; set; }

        public static string GetMemory(int value)
        {
            int count = 0;
            int inputValue = value;
            while (inputValue/1024>0)
            {
                count++;
                inputValue = inputValue / 1024;
            }

            string res = "";
            switch (count)
            {
                case 0: res="byte";
                    break;
                case 1: res = "Kb";
                    break;
                case 2: res = "Mb";
                    break;
                case 3:
                    res = "Gb";
                    break;
                case 4:
                    res = "Tb";
                    break;
            }

            return $"{inputValue} {res}";
        }
    }
}
