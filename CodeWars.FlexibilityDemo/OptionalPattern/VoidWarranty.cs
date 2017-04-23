using System;

namespace CodeWars.FlexibilityDemo.OptionalPattern
{
    class VoidWarranty : IWarranty
    {
        private static VoidWarranty instance;

        private VoidWarranty()
        {
            
        }

        public static VoidWarranty GetInstance
        {
            get
            {
                if(instance == null)
                    instance = new VoidWarranty();
                return instance;
            }
        }

        public void Claim(IWarranty defectDetectedOn, Action onValidClaim) {}
        public void Claim(DateTime now, Action onValidClaim)
        {
            throw new NotImplementedException();
        }
    }
}
