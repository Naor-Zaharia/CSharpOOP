using System;

namespace Ex03.GarageLogic
{
    public class FuelEngine : Engine
    {
        private readonly LogicEnums.eFuelType? r_FuelType;
        private float m_EnergySourceQuantity;

        public FuelEngine(float i_CurrentAmountOfFuel, float i_MaxAmountOfFuel, LogicEnums.eFuelType? i_FuelType)
            : base(i_MaxAmountOfFuel)
        {
            this.r_FuelType = i_FuelType;
            this.m_EnergySourceQuantity = i_CurrentAmountOfFuel;
        }

        // The method fill up fuel in to engine
        // Parameters: AmountOfFuelToFill - the amount of fuel to fill in to engine
        //             FuelType - the fuel type
        // Return: void
        public override void FillUpEnergy(float i_AmountOfFuelToFill, LogicEnums.eFuelType i_FuelType)
        {
            if (this.m_EnergySourceQuantity + i_AmountOfFuelToFill <= this.MaxSourceQuantity && i_FuelType == r_FuelType)
            {
                this.m_EnergySourceQuantity += i_AmountOfFuelToFill;
            }
            else
            {
                if (i_FuelType != r_FuelType)
                {
                    throw new ArgumentException(LogicStringMessages.k_FillUpFuelInVehicleIncorrectException);
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
