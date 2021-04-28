using System;
using System.Collections.Generic;
using System.Text;

namespace MobEye.Models
{
    public class Device
    {
        private int id;
        private String deviceName;
        private String commandText;
        private Command command;

        /// <summary>
        /// ID property
        /// </summary>
        public int ID
        {
            get;
            set;
        }

        /// <summary>
        /// Device name property
        /// </summary>
        public String DeviceName
        {
            get;
            set;
        }

        public String CommandText
        {
            get;
            set;
        }

        /// <summary>
        /// Door command property
        /// </summary>
        public Command Command
        {
            get;
            set;
        }

        /// <summary>
        /// Device constructor
        /// </summary>
        public Device()
        {

        }

        /// <summary>
        /// Constructor for devices
        /// </summary>
        /// <param name="id"></param>
        /// <param name="deviceName"></param>
        /// <param name="command"></param>
        public Device(int id, String deviceName, String commandText, Command command)
        {
            this.ID = id;
            this.DeviceName = deviceName;
            this.CommandText = commandText;
            this.Command = command;
        }

        public override string ToString()
        {
            return "id:" + this.ID + " device name:" + this.DeviceName + " command text" + this.CommandText + " command:" + this.Command;
        }
    }
}
