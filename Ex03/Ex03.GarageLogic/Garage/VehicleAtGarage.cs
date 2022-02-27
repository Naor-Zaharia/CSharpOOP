using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleAtGarage
    {
        private readonly string r_OwnerName;
        private readonly string r_OwnerTelephone;
        private LogicEnums.eVehicleStatus m_VehicleStatus;
        private Vehicle m_Vehicle;

        public VehicleAtGarage(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerTelephone)
        {
            this.r_OwnerName = i_OwnerName;
            this.r_OwnerTelephone = i_OwnerTelephone;
            this.m_VehicleStatus = LogicEnums.eVehicleStatus.Processed;
            this.m_Vehicle = i_Vehicle;
        }

        public Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }

            set
            {
                m_Vehicle = value;
            }
        }

        public string OwnerName
        {
            get
            {
                return r_OwnerName;
            }
        }

        public string OwnerTelephone
        {
            get
            {
                return r_OwnerTelephone;
            }
        }

        public LogicEnums.eVehicleStatus VehicleStatus
        {
            get
            {
                return m_VehicleStatus;
            }

            set
            {
                m_VehicleStatus = value;
            }
        }

        public override string ToString()
        {
            if (this.Vehicle != null)
            {
                StringBuilder resultString = new StringBuilder();

                resultString.AppendFormat(
@" Details about vehicle with number plate: {0}
 Model Name: {1}
 Owner Name: {2}
 Vehicle status: {3}
 Current wheel air pressure: {4}
 Wheel manufacture: {5}
 Kind of fuel: {6}
 Energy Quantity that left: {7}
 Percentage of remaining energy: {8}
{9}
",
this.Vehicle.PlateNumber,                    
this.Vehicle.ModelName,
this.OwnerName,
this.VehicleStatus,
this.Vehicle.VehicleWheelList[0].CurrentAirPressure,
this.Vehicle.VehicleWheelList[0].ManufacturerName,
this.Vehicle.VehicleEngine.GetFuelType(),
this.Vehicle.VehicleEngine.EnergySourceQuantity(),
this.Vehicle.RemainingEnergyPercentage,
this.Vehicle.ToString());
               
                return resultString.ToString();
            }
            else
            {
                throw new ArgumentException(LogicStringMessages.k_NoVehicleObjMsg);
            }
        }
    }
}
