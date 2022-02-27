using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string r_ModelName;
        private readonly string r_PlateNumber;
        private readonly byte r_NumberOfWheels;
        private float m_RemainingEnergyPercentage;
        private List<Wheel> m_VehicleWheelList;
        private Engine m_VehicleEngine;

        public Vehicle(string i_ModelName, string i_PlateNumber, Wheel i_Wheel, byte i_NumberOfWheels, Engine i_VehicleEngine)
        {
            this.r_ModelName = i_ModelName;
            this.r_PlateNumber = i_PlateNumber;
            this.r_NumberOfWheels = i_NumberOfWheels;
            this.m_VehicleEngine = i_VehicleEngine;
            this.m_VehicleWheelList = CreateWheelSetForVehicle(i_Wheel);
            UpdateRemainingEnergyPercentage();
        }

        // The method update vehicle remaining energy percentage
        // Parameters: None 
        // Return: void
        public void UpdateRemainingEnergyPercentage()
        {
            if (this.VehicleEngine != null)
            {
                this.m_RemainingEnergyPercentage = (this.VehicleEngine.EnergySourceQuantity() / this.VehicleEngine.MaxSourceQuantity) * 100;
            }
            else
            {
                throw new ArgumentNullException(LogicStringMessages.k_NoEngineMsg);
            }
        }

        // The method create the vehicle set of wheels
        // Parameters: Wheel - the wheel to create set of 
        // Return: List<Wheel> - the set of wheels
        public List<Wheel> CreateWheelSetForVehicle(Wheel i_Wheel)
        {
            if (i_Wheel != null)
            {
                List<Wheel> currentNewWheelsSet = new List<Wheel>();
                for (int i = 0; i < this.r_NumberOfWheels; i++)
                {
                    currentNewWheelsSet.Add(i_Wheel.ShallowCloneWheel());
                }

                return currentNewWheelsSet;
            }
            else
            {
                throw new ArgumentNullException(LogicStringMessages.k_NoWheelMsg);
            }
        }

        public string PlateNumber
        {
            get
            {
                return r_PlateNumber;
            }
        }

        public string ModelName
        {
            get
            {
                return r_ModelName;
            }
        }

        public float RemainingEnergyPercentage
        {
            get
            {
                return m_RemainingEnergyPercentage;
            }
        }

        public byte NumberOfWheels
        {
            get
            {
                return r_NumberOfWheels;
            }
        }

        public Engine VehicleEngine
        {
            get
            {
                return m_VehicleEngine;
            }

            set
            {
                m_VehicleEngine = value;
            }
        }

        public List<Wheel> VehicleWheelList
        {
            get
            {
                return m_VehicleWheelList;
            }

            set
            {
                m_VehicleWheelList = value;
            }
        }

        public abstract override string ToString();
    }
}