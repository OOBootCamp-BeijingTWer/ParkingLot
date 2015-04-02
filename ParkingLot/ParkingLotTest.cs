using System.Collections.Generic;
using Xunit;

namespace ParkingLot
{
    public class ParkingLotTest
    {
        [Fact]
        public void should_be_able_to_pick_a_car_which_is_stroed_in_parking_lot()
        {
            var car = new Car();
            var parkingLot = new ParkingLot();

            var ticket = parkingLot.StoreCar(car);

            var pickedCar = parkingLot.Pick(ticket);
            Assert.Same(car, pickedCar);
        }

        [Fact]
        public void should_pick_two_cars_given_two_cars_stored_in_parking_lot()
        {
            var firstCar = new Car();
            var secondCar = new Car();
            var parkingLot = new ParkingLot();

            var firstTicket = parkingLot.StoreCar(firstCar);
            var secondTicket = parkingLot.StoreCar(secondCar);

            Assert.Same(firstCar, parkingLot.Pick(firstTicket));
            Assert.Same(secondCar, parkingLot.Pick(secondTicket));

        }

        [Fact]
        public void should_not_pick_one_car_twice_given_the_car_stored_in_parking_lot()
        {
            var car = new Car();
            var parkingLot = new ParkingLot();

            var ticket = parkingLot.StoreCar(car);
            parkingLot.Pick(ticket);

            Assert.Null(parkingLot.Pick(ticket));
        }

        [Fact]
        public void should_not_pick_any_car_from_parking_lot_given_unkonw_ticket()
        {
            var car = new Car();
            var ticket = new Ticket();
            var parkingLot = new ParkingLot(car, ticket);
            var unknowTicket = new Ticket();

            var pickedCar = parkingLot.Pick(unknowTicket);

            Assert.Null(pickedCar);
        }
    }

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

    public class Ticket
    {
    }

    public class Car
    {
    }
}
