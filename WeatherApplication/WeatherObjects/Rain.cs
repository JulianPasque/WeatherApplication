using System;
using System.Runtime.Serialization;

namespace WeatherObjects
{
    public class Rain
    {
        [DataMember(Name = "3h")]
        public int ThreeHours { get; set; }
    }
}
