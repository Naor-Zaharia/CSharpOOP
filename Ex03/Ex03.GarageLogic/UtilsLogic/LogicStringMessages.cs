namespace Ex03.GarageLogic
{
    internal class LogicStringMessages
    {
        // Logical String Msg
        public const string k_FillUpElectricityInBatteryIncorrectException = "Did not fill electricity into engine since you tried to insert incorrect energy source";
        public const string k_FillUpFuelInVehicleIncorrectException = "Did not fill fuel into engine since you tried to insert incorrect fuel source";
        public const string k_InsertVehicleToGarageException = "The requsted vehicle does not exist in the garage";
        public const string k_NoEngineMsg = "There is no engine, please assemble an engine";
        public const string k_NoWheelMsg = "There is no wheel to assemble, please insert wheel argument";
        public const string k_NoVehicleObjMsg = "This current vehicle at garage, does not contain vehicle object";
        public const string k_ToStringDoesNot = "does not";
        public const string k_ToStringDoes = "does";
        public const string k_VehicleOperationException = "The following operation can not preformed this vehicle";
        public const string k_InsertVehicleToGarageUnsupportedException = "This kind of vehicle not supported in the garage";
    }
}
