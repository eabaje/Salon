using System;
using System.Collections.Generic;
using System.Text;

namespace Salon.Domain.Enumerations
{
    
    public enum Parameter
    {
        Shipper = 1,
        Broker = 2,
        Salon = 3
    }
    public enum LoadUnit
    {
        Kilo=1,
        Tonnes=2
       
    }

    public enum JourneyStatus
    {
        NotStarted ,
        InTransit ,
        Arrived,
        Delivered
    }
    public enum ShipmentType
    {
        FullContainer,
        PartContainer,
        Item
        
    }
    public enum SalonType
    {
        Air,
        Sea,
        Road
        

    }
    public enum FleetType
    {
        Vessel,
        Truck,
        Plane


    }
    public enum VesselType
    {
        Cargo,
        FishingBoat,
        Tanker


    }
    public enum LoadCapacity
    {
         HighCapacity=24000,
        LowCapacity=2000,
        HeavyCapacity=25000,
        
    }

    public enum VehicleType
    {
        SemiTrailer,
        StraightTruck,
        JumboTrailer,
        TailLiftTruck,
        TruckTrailer,
        FlatbedTruck,
        LowboyTrailer,
        RefrigeratedTrailers,
        MiniBus
    }
    public enum Roles
    {
        Administrator,
        Editor,
        User,
        Tester
    }
}
