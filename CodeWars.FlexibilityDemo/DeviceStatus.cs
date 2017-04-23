using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.FlexibilityDemo
{
   
    //no comparison or deriving.
    sealed class DeviceStatus : IEquatable<DeviceStatus>
    {
        
       [Flags]
       private enum StatusRepresentation
       {
            AllFine = 0,
            NotOperational = 1,
            VisiblyDamaged = 2,
            CircuitryFailed = 3
        }

        private  StatusRepresentation Representation { get; }

        //private because we do not want any clients knowing about representations
        //Encapsulation
         private DeviceStatus(StatusRepresentation representation)
         {
             this.Representation = representation;
         }

        //Entry point.
        public static DeviceStatus AllFine() =>
            new DeviceStatus(StatusRepresentation.AllFine);

        public DeviceStatus WithVisibleDamage() =>
            new DeviceStatus(this.Representation | StatusRepresentation.VisiblyDamaged);

        public DeviceStatus NotOperational() =>
            new DeviceStatus(this.Representation | StatusRepresentation.NotOperational);

        public DeviceStatus Repaired () =>
            new DeviceStatus(this.Representation & ~StatusRepresentation.NotOperational);

        public DeviceStatus CircuitryFailed()=>
            new DeviceStatus(this.Representation | StatusRepresentation.CircuitryFailed);

        public DeviceStatus CircuitryReplaced()=>
            new DeviceStatus(this.Representation & ~StatusRepresentation.CircuitryFailed);


        //Mandatory Equals Methods - This makes class a proper VALUE class. Like integers or enums are already behaving.
        public override int GetHashCode() => (int) this.Representation;

        public override bool Equals(object obj) => this.Equals(obj as DeviceStatus);

        public bool Equals(DeviceStatus other) => other != null && this.Representation == other.Representation;

        public static bool operator ==(DeviceStatus a, DeviceStatus b) =>
            (object.ReferenceEquals(a, null) && object.ReferenceEquals(b, null)) ||
            (!object.ReferenceEquals(a, null) && a.Equals(b));

        public static bool operator !=(DeviceStatus a, DeviceStatus b) => !(a == b);
    }
}
