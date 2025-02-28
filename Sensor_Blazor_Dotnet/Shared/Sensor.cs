﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BlazorSensorApp.Shared
{

    public class Sensor
    {
        public static int Count {get; set;} = 0;
        public int No { get; set; }
        public string Id { get; set; }
        public double? Value { get; set; }

        //public int TemperatureF => 32 + (int)(Value / 0.5556);

        public bool State {get; set;}
        public List<double> Values { get; set; }
        public SensorType SensorType { get; set; }
        public long TimeStamp { get; set; }

    }

    public class AppSettings
    {
        public static string evIOTHUB_DEVICE_CONN_STRING { get; set; }
        public string IOTHUB_DEVICE_CONN_STRING { get; set; }
    }

    public enum SensorType {temperature,pressure,humidity,luminosity,accelerometer,environment,sswitch}
}
