using Xunit;

namespace ParkingLot
{
    public class ParkingLotTest
    {
        [Fact]
        public void should_be_able_to_pick_a_car_which_is_stroed_in_parking_lot()
        {
            var car = new Car("NB1234");
            var parkingLot = new ParkingLot(5);

            var ticket = parkingLot.StoreCar(car);

            var pickedCar = parkingLot.Pick(ticket);
            Assert.Same(car, pickedCar);
        }

        [Fact]
        public void should_pick_two_cars_given_two_cars_stored_in_parking_lot()
        {
            var firstCar = new Car("NB1234");
            var secondCar = new Car("NB5678");
            var parkingLot = new ParkingLot(5);

            var firstTicket = parkingLot.StoreCar(firstCar);
            var secondTicket = parkingLot.StoreCar(secondCar);

            Assert.Same(firstCar, parkingLot.Pick(firstTicket));
            Assert.Same(secondCar, parkingLot.Pick(secondTicket));
        }

        [Fact]
        public void should_not_pick_one_car_twice_given_the_car_stored_in_parking_lot()
        {
            var car = new Car("NB1234");
            var parkingLot = new ParkingLot(5);

            var ticket = parkingLot.StoreCar(car);
            parkingLot.Pick(ticket);

            Assert.Null(parkingLot.Pick(ticket));
        }

        [Fact]
        public void should_not_pick_any_car_from_parking_lot_given_unkonw_ticket()
        {
            var car = new Car("NB1234");
            var parkingLot = new ParkingLot(5);
            parkingLot.StoreCar(car);
            var unknowTicket = new Ticket();

            var pickedCar = parkingLot.Pick(unknowTicket);

            Assert.Null(pickedCar);
        }

        [Fact]
        public void should_not_store_car_when_parking_lot_is_full()
        {
            var parkingLot = new ParkingLot(1);
            parkingLot.StoreCar(new Car("NB1234"));

            var storeFailed = parkingLot.StoreCar(new Car("NB5678"));

            Assert.Null(storeFailed);
        }

        [Fact]
        public void should_not_store_one_car_twice()
        {
            var parkingLot = new ParkingLot(5);
            var car = new Car("NB1234");
            parkingLot.StoreCar(car);

            var ticket = parkingLot.StoreCar(car);

            Assert.Null(ticket);
        }

        [Fact]
        public void should_not_store_two_cars_with_same_carNumber()
        {
            var parkingLot = new ParkingLot(5);
            parkingLot.StoreCar(new Car("NB1234"));

            var ticket = parkingLot.StoreCar(new Car("NB1234"));

            Assert.Null(ticket);
        }
    }
}
