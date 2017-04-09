using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LinqHotelsExercice
{

    //class DistinctItemComparer : IEqualityComparer<Room>
    //{
    //    public bool Equals(Room x, Room y)
    //    {
    //        return x.Types == y.Types &&
    //               x.Price == y.Price;
    //    }

    //    public int GetHashCode(Room objRoom)
    //    {
    //        return objRoom.Types.GetHashCode() ^
    //               objRoom.Price.GetHashCode();

    //    }
    //}

    class Program
    {
        static void Main(string[] args)
        {
            var hotels = new Hotel[]
            {
                new Hotel() {HotelNo = 1, Name = "The Pope", Address = "Vaticanstreet 1  1111 Bishopcity"},
                new Hotel() {HotelNo = 2, Name = "Lucky Star", Address = "Lucky Road 12  2222 Hometown"},
                new Hotel() {HotelNo = 3, Name = "Discount", Address = "Inexpensive Road 7 3333 Cheaptown"},
                new Hotel() {HotelNo = 4, Name = "deLuxeCapital", Address = "Luxury Road 99  4444 Luxus"},
                new Hotel() {HotelNo = 5, Name = "Discount", Address = "Inexpensive Road 7 3333 Cheaptown"},
                new Hotel() {HotelNo = 6, Name = "Prindsen", Address = "Algade 5, 4000 Roskilde"},
                new Hotel() {HotelNo = 7, Name = "Scandic", Address = "Algade 5, 4000 Roskilde"},
            };

            var rooms = new Room[]
            {
                new Room() {RoomNo = 1, Hotel=hotels[0], Types = 'D', Price = 200},
                new Room() {RoomNo = 2, Hotel=hotels[0], Types = 'D', Price = 200},
                new Room() {RoomNo = 3, Hotel=hotels[0], Types = 'D', Price = 200},
                new Room() {RoomNo = 4, Hotel=hotels[0], Types = 'D', Price = 200},
                new Room() {RoomNo = 11, Hotel=hotels[0], Types = 'S', Price = 150},
                new Room() {RoomNo = 12, Hotel=hotels[0], Types = 'S', Price = 150},
                new Room() {RoomNo = 13, Hotel=hotels[0], Types = 'S', Price = 150},
                new Room() {RoomNo = 21, Hotel=hotels[0], Types = 'F', Price = 220},
                new Room() {RoomNo = 22, Hotel=hotels[0], Types = 'F', Price = 220},
                new Room() {RoomNo = 23, Hotel=hotels[0], Types = 'F', Price = 220},
                new Room() {RoomNo = 1, Hotel=hotels[1], Types = 'D', Price = 230},
                new Room() {RoomNo = 2, Hotel=hotels[1], Types = 'D', Price = 230},
                new Room() {RoomNo = 3, Hotel=hotels[1], Types = 'D', Price = 230},
                new Room() {RoomNo = 4, Hotel=hotels[1], Types = 'D', Price = 230},
                new Room() {RoomNo = 11, Hotel=hotels[1], Types = 'S', Price = 180},
                new Room() {RoomNo = 12, Hotel=hotels[1], Types = 'S', Price = 180},
                new Room() {RoomNo = 21, Hotel=hotels[1], Types = 'F', Price = 300},
                new Room() {RoomNo = 22, Hotel=hotels[1], Types = 'F', Price = 300},
                new Room() {RoomNo = 1, Hotel=hotels[2], Types = 'D', Price = 175},
                new Room() {RoomNo = 2, Hotel=hotels[2], Types = 'D', Price = 180},
                new Room() {RoomNo = 11, Hotel=hotels[2], Types = 'S', Price = 100},
                new Room() {RoomNo = 21, Hotel=hotels[2], Types = 'S', Price = 100},
                new Room() {RoomNo = 31, Hotel=hotels[2], Types = 'F', Price = 200},
                new Room() {RoomNo = 32, Hotel=hotels[2], Types = 'F', Price = 230},
                new Room() {RoomNo = 1, Hotel=hotels[3], Types = 'D', Price = 500},
                new Room() {RoomNo = 2, Hotel=hotels[3], Types = 'D', Price = 550},
                new Room() {RoomNo = 3, Hotel=hotels[3], Types = 'D', Price = 550},
                new Room() {RoomNo = 11, Hotel=hotels[3], Types = 'S', Price = 350},
                new Room() {RoomNo = 12, Hotel=hotels[3], Types = 'S', Price = 360},
                new Room() {RoomNo = 1, Hotel=hotels[4], Types = 'D', Price = 250},
                new Room() {RoomNo = 2, Hotel=hotels[4], Types = 'D', Price = 170},
                new Room() {RoomNo = 11, Hotel=hotels[4], Types = 'S', Price = 150},
                new Room() {RoomNo = 21, Hotel=hotels[4], Types = 'F', Price = 300},
                new Room() {RoomNo = 22, Hotel=hotels[4], Types = 'F', Price = 310},
                new Room() {RoomNo = 23, Hotel=hotels[4], Types = 'F', Price = 320},
                new Room() {RoomNo = 24, Hotel=hotels[4], Types = 'F', Price = 320},
                new Room() {RoomNo = 1, Hotel=hotels[5], Types = 'D', Price = 290},// here
                new Room() {RoomNo = 11, Hotel=hotels[5], Types = 'S', Price = 185},
                new Room() {RoomNo = 21, Hotel=hotels[5], Types = 'F', Price = 360},
                new Room() {RoomNo = 22, Hotel=hotels[5], Types = 'F', Price = 370},
                new Room() {RoomNo = 23, Hotel=hotels[5], Types = 'F', Price = 380},
                new Room() {RoomNo = 24, Hotel=hotels[5], Types = 'F', Price = 380},//to here
                new Room() {RoomNo = 1, Hotel=hotels[6], Types = 'D', Price = 200},
                new Room() {RoomNo = 2, Hotel=hotels[6], Types = 'D', Price = 200},
                new Room() {RoomNo = 3, Hotel=hotels[6], Types = 'D', Price = 200},
                new Room() {RoomNo = 4, Hotel=hotels[6], Types = 'D', Price = 200},
                new Room() {RoomNo = 11, Hotel=hotels[6], Types = 'S', Price = 150},
                new Room() {RoomNo = 12, Hotel=hotels[6], Types = 'S', Price = 150},
                new Room() {RoomNo = 13, Hotel=hotels[6], Types = 'S', Price = 150},
                new Room() {RoomNo = 14, Hotel=hotels[6], Types = 'S', Price = 150},
                new Room() {RoomNo = 21, Hotel=hotels[6], Types = 'F', Price = 220},
                new Room() {RoomNo = 22, Hotel=hotels[6], Types = 'F', Price = 220},
                new Room() {RoomNo = 23, Hotel=hotels[6], Types = 'F', Price = 220},
                new Room() {RoomNo = 24, Hotel=hotels[6], Types = 'F', Price = 220}
            };

            //Exercise, use LINQ to retrive the following information about Hotels and Rooms:

            // // 1) List full details of all Hotels:
            Console.WriteLine("\n All hotels :");
            var hotelQuery =
                from hotel in hotels
                select hotel;
            Console.WriteLine();

            foreach (var hotel in hotelQuery)
            {
                Console.WriteLine("{0,1} ", hotel);
            }

            // 2) List full details of all hotels in Roskilde:
            Console.WriteLine("\n List of all hotels in Roskilde:");
            var hotelRoskilde =
                from hotel in hotels
                where (hotel.Address.Contains("Roskilde"))
                select hotel;

            Console.WriteLine();

            foreach (var hotel in hotelRoskilde)
            {
                Console.WriteLine("{0,1} ", hotel);
            }
            // 3) List the names of all hotels in Roskilde:

            Console.WriteLine("\n List of all hotels in Roskilde:");
            var hotelNamesRoskilde =
                from hotel in hotels
                where (hotel.Address.Contains("Roskilde"))
                select hotel;
            Console.WriteLine();

            foreach (var hotel in hotelRoskilde)
            {
                Console.WriteLine("{0,1} ", hotel.Name);
            }

            Console.WriteLine();

            // 4) List all double rooms with a price below 400 pr night:

            Console.WriteLine("\n List of all double rooms with price below 400:");
            var roomDouble =
                from room in rooms
                where (room.Types.Equals('D') && room.Price < 400)
                select room;
            Console.WriteLine();

            foreach (var room in roomDouble)
            {
                Console.WriteLine("{0,1} ", room);
            }
            Console.WriteLine();

            // 5) List all double or family rooms with a price below 400 pr night in ascending order of price:
            Console.WriteLine("\n List of all double /family rooms with price below 400 in ascending order :");
            var roomOrder =
                from room in rooms
                where (room.Price < 400 && room.Types.Equals('D') || room.Types.Equals('F'))
                orderby room.Price ascending
                select room;
            Console.WriteLine();
            // commented
            //foreach (var room in roomOrder)
            //{
            //    Console.WriteLine(room.Price);
            //}
            // stop comment

            foreach (var room in roomOrder)
            {
                Console.WriteLine("{0} ", room);
            }
            Console.WriteLine();

            // 6) List all hotels that starts with 'P':

            Console.WriteLine("\n List of all hotels that start with p :");
            var hotelPName =
                from hotel in hotels
                where (hotel.Name.StartsWith("P"))
                select hotel;
            Console.WriteLine();

            foreach (var hotel in hotelPName)
            {
                Console.Write("{0} ", hotel);
            }
            Console.WriteLine();

            // 7) List the number of hotels:

            Console.WriteLine("\n List number of hotels :");
            var hotelNr =
                from hotel in hotels
                select hotel;
            //comment
            // Console.WriteLine(hotelNr.Count());
            //int nr = 0;
            //foreach (var hotel in hotels)
            //{
            //    nr++;
            //}
            //Console.WriteLine("Number of hotels is : {0}",nr);
            // stop comment
            Console.WriteLine("Number of hotels is :{0}", hotelNr.Count());
            Console.WriteLine();


            // 8) List the number of hotels in Roskilde:

            Console.WriteLine("\n List number of hotels in Roskilde ");
            var hotel2 =
                from hotel in hotels
                where hotel.Address.Contains("Roskilde")
                select hotel;

            Console.WriteLine();
            Console.WriteLine("Number of hotels is :{0}", hotel2.Count());
            Console.WriteLine();


            // 9) what is the avarage price of rooms :

            Console.WriteLine("\n List of average prive of rooms :");
            var roomAverage =
                from room in rooms
                let price = room.Price
                select price;
            Console.WriteLine();
            double averageprice = roomAverage.Average();

            Console.Write(" The average price of rooms is {0,1} ", averageprice);

            Console.WriteLine();

            //10) what is the avarage price of a room at Hotel Scandic:

            Console.WriteLine("\n List of average price of rooms in Scandic  :");
            var roomAverage2 =
                from room in rooms
                where room.Hotel.Name.Equals("Scandic")
                let price = room.Price
                select price;
            Console.WriteLine();
            double averageprice2 = roomAverage2.Average();

            Console.Write(" The average price of rooms in hotel Scandic:  {0,1} ", averageprice2);

            Console.WriteLine();

            //11) what is the total revenue per night from all double rooms:

            Console.WriteLine("\n List of all double rooms revenue :");
            var roomRevenue =
                from room in rooms
                where (room.Types.Equals('D'))
                let totalprice = room.Price
                select room;
            int x = 0;
            foreach (var room in roomRevenue)
            {
                x = x + room.Price;
            }
            Console.WriteLine(" Double Rooms revenue is:{0}", x);

            //12) List price and type of all rooms at Hotel Prindsen:

            Console.WriteLine("\n List of prices and types for all rooms at Prindsen :");
            var roomPriceType =
                from room in rooms
                where (room.Hotel.Name.Equals("Prindsen"))
                select room;
            Console.WriteLine();
            Console.WriteLine("Room types are :");

            foreach (var room in roomPriceType)
            {

                Console.WriteLine(room.Types);

            }
            Console.WriteLine("Room prices are :");

            foreach (var room in roomPriceType)
            {
                Console.WriteLine(room.Price);
            }


            //13) List distinct price and type of all rooms at Hotel Prindsen:

            //int[] array1 = { 1, 2, 2, 3, 3, 4, 4, 5, 6, 6 };
            //var result = array1.Distinct();
            //foreach (int value in array1)
            //{
            //    Console.Write(value);
            //}
            //Console.WriteLine();
            //foreach (int value in result)
            //{
            //    Console.Write(value);
            //}



            //var roomPriceDis =
            //    (from room in rooms
            //     where (room.Hotel.Name.Equals("Prindsen"))
            //     select room.Price).Distinct();
            //Console.WriteLine("Prices");
            //foreach (var room in roomPriceDis)
            //{
            //    Console.Write(" " + room + " ");
            //}
            //var roomTypeDis =
            //    (from room in rooms
            //     where (room.Hotel.Name.Equals("Prindsen"))
            //     select room.Types).Distinct();
            //Console.WriteLine();
            //Console.WriteLine("Types");
            //foreach (var room in roomTypeDis)
            //{
            //    Console.Write(" " + room + " ");
            //}

            Console.WriteLine("\n List of distinct prices and types for all rooms at Prindsen :");
            var roomPriceDisctinct =
                from room in rooms
                where room.Hotel.Name == "Prindsen"
                select new {price = room.Price, type = room.Types};

            roomPriceDisctinct = roomPriceDisctinct.Distinct();

            foreach (var room in roomPriceDisctinct)
            {
                Console.WriteLine( room.price + " " + room.type);
            }

            Console.ReadLine();

        }
    }
}
