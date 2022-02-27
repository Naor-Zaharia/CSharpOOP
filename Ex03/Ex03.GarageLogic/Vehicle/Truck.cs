namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private readonly float r_CargoCapacity;
        private bool m_IsDeliveryDangerousMaterials;

        public Truck(
            bool i_IsDeliveryDangerousMaterials,
            float i_CargoCapacity,
            string i_ModelName,
            string i_PlateNumber,
            Wheel i_Wheel,
            byte i_NumberOfWheels,
            Engine i_VehicleEngine)
            : base(i_ModelName, i_PlateNumber, i_Wheel, i_NumberOfWheels, i_VehicleEngine)
        {
            this.r_CargoCapacity = i_CargoCapacity;
            this.m_IsDeliveryDangerousMaterials = i_IsDeliveryDangerousMaterials;
        }

        public bool IsDeliveryDangerousMaterials
        {
            get
            {
                return this.m_IsDeliveryDangerousMaterials;
            }

            set
            {
                this.m_IsDeliveryDangerousMaterials = value;
            }
        }

        public float CargoCapacity
        {
            get
            {
                return this.r_CargoCapacity;
            }
        }

        public override string ToString()
        {
            string isDeliveryDangerousMaterials;
            if (this.IsDeliveryDangerousMaterials)
            {
                isDeliveryDangerousMaterials = LogicStringMessages.k_ToStringDoes;
            }
            else
            {
                isDeliveryDangerousMaterials = LogicStringMessages.k_ToStringDoesNot;
            }

            return string.Format(
 @" The truck {0} delivery dangerous materials
 Cargo capacity is: {1}",
 isDeliveryDangerousMaterials,
 this.CargoCapacity);
        }
    }
}
