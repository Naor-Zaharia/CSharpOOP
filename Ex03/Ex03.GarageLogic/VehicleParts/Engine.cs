namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        private readonly float r_MaxSourceQuantity;

        protected Engine(float i_MaxSourceQuantity)
        {
            this.r_MaxSourceQuantity = i_MaxSourceQuantity;
        }

        public abstract void FillUpEnergy(float i_QuantityOfEnergySource, LogicEnums.eFuelType i_FuelType);

        public abstract LogicEnums.eFuelType? GetFuelType();

        public abstract float EnergySourceQuantity();

        public float MaxSourceQuantity
        {
            get
            {
                return r_MaxSourceQuantity;
            }
        }
    }
}
