using System;

class RoomBookingSystem
{
    public string BookRoom() => "Номер забронирован";
    public string CancelRoom() => "Бронирование номера отменено";
    public string CheckAvailability() => "Проверка доступности номеров";
}

class RestaurantSystem
{
    public string ReserveTable() => "Стол забронирован";
    public string OrderFood() => "Еда заказана";
    public string CallTaxi() => "Такси вызвано";
}

class EventManagementSystem
{
    public string BookConferenceRoom() => "Конференц-зал забронирован";
    public string OrderEquipment() => "Оборудование заказано";
}

class CleaningService
{
    public string ScheduleCleaning() => "Уборка запланирована";
    public string PerformCleaning() => "Уборка выполнена";
}

class HotelFacade
{
    private RoomBookingSystem roomBooking = new RoomBookingSystem();
    private RestaurantSystem restaurant = new RestaurantSystem();
    private EventManagementSystem eventManagement = new EventManagementSystem();
    private CleaningService cleaningService = new CleaningService();

    public string BookRoomWithService()
    {
        return $"{roomBooking.BookRoom()}, {restaurant.OrderFood()}, {cleaningService.ScheduleCleaning()}";
    }

    public string OrganizeEventWithRooms()
    {
        return $"{eventManagement.BookConferenceRoom()}, {eventManagement.OrderEquipment()}, {roomBooking.BookRoom()}";
    }

    public string ReserveRestaurantTableWithTaxi()
    {
        return $"{restaurant.ReserveTable()}, {restaurant.CallTaxi()}";
    }

    public string CancelRoomBooking()
    {
        return roomBooking.CancelRoom();
    }

    public string RequestCleaning()
    {
        return cleaningService.PerformCleaning();
    }
}

// Клиентский код
class Program
{
    static void Main()
    {
        var hotelFacade = new HotelFacade();
        Console.WriteLine(hotelFacade.BookRoomWithService());
        Console.WriteLine(hotelFacade.OrganizeEventWithRooms());
        Console.WriteLine(hotelFacade.ReserveRestaurantTableWithTaxi());
        Console.WriteLine(hotelFacade.CancelRoomBooking());
        Console.WriteLine(hotelFacade.RequestCleaning());
    }
}
