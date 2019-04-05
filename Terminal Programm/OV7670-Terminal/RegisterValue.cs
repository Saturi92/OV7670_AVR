using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OV7670_Terminal
{
    public class RegisterValue
    {
        //Variable
        private Byte Value;

        //Konstruktor
        public RegisterValue()
        {
            Value = 0;
        }
        //Destructor
        ~RegisterValue()
        {

        }

        //Properties

        //Methods
        public string getHex()
        {
            string result;
            result = Value.ToString("X2");
            return result;
        }
        public void setHex(string newValue)
        {
            Byte Calculate=0;
            if((char)newValue[0]>=48 && (char)newValue[0]<=57)
            {
                Calculate = (byte) (((char)newValue[0]-48)<<4);
            }
           else if((char)newValue[0] >= 65 && (char)newValue[0] <= 70)
            {
                Calculate = (byte)(((char)newValue[0] - 55) << 4);
            }

            if ((char)newValue[1] >= 48 && (char)newValue[1] <= 57)
            {
                Calculate |= (byte)(((char)newValue[1] - 48));
            }
            else if ((char)newValue[1] >= 65 && (char)newValue[1] <= 70)
            {
                Calculate |= (byte)(((char)newValue[1] - 55));
            }
            
            Value = Calculate;
        }

        public void setDez(string newValue)
        {
            Value = (Byte) Convert.ToInt16(newValue);
        }
        public string getDez()
        {
            String result;
            result = Value.ToString();
            return result;
        }

        public void setBin(string newValue)
        {
            Byte Result = 0;
            for(int i = 0; i < 8; i++)
            {
                Result |= (byte) ((newValue[i]-48)<<(7-i));
                Value = Result;
            }
        }
        public string getBin()
        {
            string result="";
            for(int i=0;i<8;i++)
            {
                result = ((Value >> i) & (0x01)) + result; 
            }

            return result;
        }

        public Byte getByte()
        {
            return Value;
        }
        public void setByte(Byte newByte)
        {
            Value = newByte;
        }

        public string toString()
        {
            return Value.ToString();
        }

        public string toStringHex()
        {
            return string.Format("{0:X2}", Value);
        }
       
        
    }
}
