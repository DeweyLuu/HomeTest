using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTest
{
    public class DataObject : object
    {
        public DataObject(string passraw)
        {
            var returnLine = passraw.Split(',');
            TimeStamp = returnLine[0];
            Type = returnLine[1];
            Gesture = returnLine[4];
            Packet = new string(returnLine[5].Skip(4).ToArray());

            var temp = returnLine[5].Take(4).ToArray();
            var tempNum = new List<byte>();
            for (int i = 0; i < temp.Length; i += 2)
            {
                tempNum.Add(Convert.ToByte((temp[i].ToString() + temp[i+1].ToString()), 16));
            }

            this.Header = BitConverter.ToUInt16(tempNum.ToArray(), 0);
        }
        public string TimeStamp { get; set; }
        public string Type { get; set; }
        public string Gesture { get; set; }
        public string Packet { get; set; }

        public ushort Header { get; set; }
 
    }


}
