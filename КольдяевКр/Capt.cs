using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КольдяевКр
{
    class Capt
    {
        public static string CRCapt()
        {
            string charc = "ABCDEFGHJKLMNPQRSTUWXYZ123456789";
            var random = new Random();
            var result = new char[4];

            for (int i = 0; i < 4; i++)
            {
                result[i] = charc[random.Next(charc.Length)];
            }
            return new string(result);
        }
    }
}
