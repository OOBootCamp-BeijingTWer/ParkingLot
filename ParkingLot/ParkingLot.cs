using System.Collections.Generic;

namespace ParkingLot
{
    public class ParkingLot
    {
        private Dictionary<Ticket, Car> cars = new Dictionary<Ticket, Car>();

        public ParkingLot(Car car, Ticket ticket)
        {
            cars.Add(ticket, car);
        }

        public ParkingLot()
        {
        }

        public Ticket StoreCar(Car car)
        {
            var ticket = new Ticket();
            cars.Add(ticket, car);
            return ticket;
        }

        public Car Pick(Ticket ticket)
        {
            if (cars.Count == 0 || !cars.ContainsKey(ticket)) return null;

            var pickedCar = cars[ticket];
            cars.Remove(ticket);
            return pickedCar;
        }
    }
}