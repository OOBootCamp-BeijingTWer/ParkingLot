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

            parkingLot.StoreCar(car);

            var pickedCar = parkingLot.Pick(car);
            Assert.Same(car, pickedCar);
        }

        [Fact]
        public void should_pick_two_cars_given_two_cars_stored_in_parking_lot()
        {
            var firstCar = new Car();
            var secondCar = new Car();
            var parkingLot = new ParkingLot();

            parkingLot.StoreCar(firstCar);
            parkingLot.StoreCar(secondCar);

            Assert.Same(firstCar, parkingLot.Pick(firstCar));
            Assert.Same(secondCar, parkingLot.Pick(secondCar));

        }

        [Fact]
        public void should_not_pick_one_car_twice_given_the_car_stored_in_parking_lot()
        {
            var car = new Car();
            var parkingLot = new ParkingLot();

            parkingLot.StoreCar(car);
            parkingLot.Pick(car);

            Assert.Null(parkingLot.Pick(car));

        }
    }

    public class ParkingLot
    {
        public void StoreCar(Car car)
        {
        }

        public Car Pick(Car car)
        {
            return car;
        }
    }

    public class Car
    {
    }
}
