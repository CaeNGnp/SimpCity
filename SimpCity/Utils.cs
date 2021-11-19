using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpCity {
    class Utils {
        public static string RepeatString(string s, int n) {
            string ret = "";
            for (int i = 0; i < n; i++) {
                ret += s;
            }
            return ret;
        }
    }
}
