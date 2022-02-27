using System;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        private readonly LogicEnums.eFuelType? r_FuelType;
        private float m_EnergySourceQuantity;

        public ElectricEngine(float i_QuantityOfEnergySource, float i_MaxQuantityOfEnergySource, LogicEnums.eFuelType? i_FuelType)
            : base(i_MaxQuantityOfEnergySource)
        {
            this.r_FuelType = i_FuelType;
            this.m_EnergySourceQuantity = i_QuantityOfEnergySource;
        }

        // The method fill up electricity in to engine battery
        // Parameters: QuantityOfEnergySource - the amount of electricity to fill in to engine
        //             FuelType - the fuel type
        // Return: void
        public override void FillUpEnergy(float i_QuantityOfEnergySource, LogicEnums.eFuelType i_FuelType)
        {
            if (this.m_EnergySourceQuantity + i_QuantityOfEnergySource <= this.MaxSourceQuantity && i_FuelType == r_FuelType)
            {
                this.m_EnergySourceQuantity += i_QuantityOfEnergySource;
            }
            else
            {
                if (i_FuelType != r_FuelType)
                {
                    throw new ArgumentException(LogicStringMessages.k_FillUpElectricityInBatteryIncorrectException);
                }
                else
                {
                    throw new ValueOutOfRangeException(0, this.MaxSourceQuantity);
                }
            }
        }

        public override float EnergySourceQuantity()
        {
            return this.m_EnergySourceQuantity;
        }

        public override LogicEnums.eFuelType? GetFuelType()
        {
            return this.r_FuelType;
        }
    }
}
