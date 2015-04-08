using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    public class ParkingLot
    {
        private Dictionary<Ticket, Car> cars = new Dictionary<Ticket, Car>();
        private int capacity = 10;

        public ParkingLot(Car car, Ticket ticket)
        {
            cars.Add(ticket, car);
        }

        public ParkingLot(int capacity)
        {
            this.capacity = capacity;
        }

        public Ticket StoreCar(Car car)
        {
            if (cars.Count == capacity) return null;
            if (cars.ContainsValue(car)) return null;
            if (cars.Values.Any(c => c.carNumber == car.carNumber)) return null;
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