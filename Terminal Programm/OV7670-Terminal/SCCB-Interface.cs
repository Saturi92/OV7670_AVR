using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OV7670_Terminal
{
    class SCCB_Interface
    {
        private RegisterValue readRegister = new RegisterValue();
        private RegisterValue receiveValue = new RegisterValue();
        private RegisterValue writeRegister = new RegisterValue();
        private RegisterValue writeValue = new RegisterValue();

        public SCCB_Interface ()
        {

        }
        
        //properties
        public RegisterValue ReadRegister
        {
            get { return readRegister; }
            set { readRegister = value; }
        }
        public RegisterValue WriteRegister 
        {
            get { return writeRegister; }
            set { writeRegister = value; }
        }
        public RegisterValue WriteValue
        {
            get { return writeValue; }
            set { writeValue = value; }
        }
        public RegisterValue ReceivedValue
        {
            get { return receiveValue; }
            set { receiveValue = value; }
        }
    }
}
