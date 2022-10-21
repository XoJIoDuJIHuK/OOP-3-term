class Container
{
    List<Vehicle> _listVehicle = new List<Vehicle>();
    public void Add(Vehicle? obj)
    {
        if (obj == null) throw new NullException("Add");
        _listVehicle.Add(obj);
    }
    public void Delete(Vehicle? obj)
    {
        if (obj == null) throw new NullException("Delete");
        _listVehicle.Remove(obj);
    }
    public void WriteList()
    {
        if (_listVehicle.Count == 0)
        {
            Console.WriteLine("empty");
        }
        else
        {
            foreach (var vehicle in _listVehicle)
            {
                Console.WriteLine(vehicle.ToString());
            }
        }
    }
    public int AverageDraught()
    {
        if (_listVehicle.Count == 0)
        {
            throw new ZeroCountException("AverageDraught");
        }
        int sum = 0;
        for (int i = 0; i < _listVehicle.Count; i++)
        {
            sum += _listVehicle[i]._Draught;
        }
        return sum / _listVehicle.Count;
    }
    public int AverageNumberOfPlaces()
    {
        if (_listVehicle.Count == 0)
        {
            throw new ZeroCountException("AverageNumberOfPlaces");
        }
        int sum = 0;
        for (int i = 0; i < _listVehicle.Count; i++)
        {
            int pas = _listVehicle[i]._PassengersCapacity;
            sum += _listVehicle[i]._PassengersCapacity;
        }
        return sum / _listVehicle.Count;
    }
    public void AllVehiclesBasedOnCaptains()
    {
        bool suchShipFound = false;
        for (int i = 0; i < _listVehicle.Count(); i++)
        {
            if (_listVehicle[i]._CaptainAge <= 35)
            {
                Console.WriteLine(_listVehicle[i].ToString());
                suchShipFound = true;
            }
        }
        if (!suchShipFound) Console.WriteLine("No such ships found");
    }
}