using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OV7670_Terminal
{
    class SccbRegister
    {
        public RegisterValue MyAddress { get; set; }
        public RegisterValue Value { get; set; }

        public SccbRegister(byte sAddress){
            MyAddress= new RegisterValue();
            MyAddress.setByte(sAddress);
            Value = new RegisterValue();
        }
        public SccbRegister(RegisterValue nAddress)
        {
            MyAddress = nAddress;
            Value = new RegisterValue();
        }
        public SccbRegister(byte sAddress, RegisterValue sValue){
            MyAddress = new RegisterValue();
            MyAddress.setByte(sAddress);
            Value = sValue;
        }
        public SccbRegister(RegisterValue nAddress, RegisterValue nValue)
        {
            MyAddress = nAddress;
            Value = nValue;
        }

        public override string ToString()
        {
            var output = MyAddress.toString().ToString() + ";" + Value.toString();
            return output;
        }

        public string ToStringHex()
        {
            var output = "0x"+MyAddress.toStringHex() + "\t" + "0x"+Value.toStringHex();
            return output;
        }

        public string ToStringHexCSV()
        {
            var output = "0x" + MyAddress.toStringHex() + ";" + "0x" + Value.toStringHex();
            return output;
        }

        public string ToStructHex()
        {
            var output ="{ "+ "0x" + MyAddress.toStringHex() + ", " + "0x" + Value.toStringHex()+" },";
            return output;
        }

        public bool AddAndValueEquals(SccbRegister other)
        {
            if ((MyAddress.getByte() == other.MyAddress.getByte()) && (Value.getByte() == other.Value.getByte()))
               return true;
            else
                return false;
        }
        
    }
}
