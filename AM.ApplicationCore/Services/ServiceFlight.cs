using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : IServiceFlight
    {         
        public IList<Flight> Flights = new List<Flight>();  
       
        public IEnumerable<DateTime> GetFlightDates(string destination)
        {             
            //Foreach  : méthode classique 
            //IList<DateTime> result = new List<DateTime>();             //foreach (var item in Flights)             //    if (item.Destination.Equals(destination))             //    {
            //        result.Add(item.FlightDate);
            //    }             //return result; 
            //le langage Linq = langage de requetage couplé entre SQL et C#
            // Syntaxe 
            // var query = from instance in Source ( instance a, x, p )
            // where condition
            //select 
            // return query 
            // a = flight
            // linq
            // var query = from A in Flights
            //              where A.Destination.Equals(destination)
            //               select A.FlightDate;
            //  return query;    
            // lambda
            return Flights.Where(i => i.Destination.Equals(destination)).Select(f => f.FlightDate);
        }                 

        public void ShowFlightDetails(Plane plane)
        {
            //linq
            //var query = from a in Flights
            //            where a.Plane.Equals(plane)
            //            select new { a.Destination, a.FlightDate };
            //lambda             var query =plane.Flights.Select(i => new { i.Destination, i.FlightDate }); 
            foreach (var item in query)
            {
                Console.WriteLine("FlightDate" +item.FlightDate + "Destination "+item.Destination );
            } 
        }         

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            //linq
            //var query = from a in Flights
            //            where (startDate - a.FlightDate).TotalDays < 7
            //            select a;
            //return query.Count();
            //lambda
            return Flights.Where(a => (startDate - a.FlightDate).TotalDays < 7).Count();         
        }         
        
        public double DurationAverage(string destination)
        {
            //linq
            //return
            //     (from a in Flights
            //      where a.Destination == destination
            //  select a.EstimatedDuration
            //  ).Average();
            //lambda
            //return Flights.Where(i => i.Destination == destination).Select(a => a.EstimatedDuration).Average();             return Flights.Where(i => i.Destination == destination).Average(a => a.EstimatedDuration); 
        }

        public IEnumerable<Flight> OrderedDurationFlights()
        {
            var query = from a in Flights
                        orderby a.EstimatedDuration descending
                        select a;
            return query;         
        } 
               
        IEnumerable<Traveller> SeniorTravellers(Flight flight)
        {
            //linq
            //var query = from a in flight.Passengers.OfType<Traveller>()
            //            orderby a.BirthDate
            //            select a;
            //return query.Take(3);
            //lambda
            return flight.Passengers.OfType<Traveller>().OrderBy(f => f.BirthDate).Take(3);
        }    
     
        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        {
            //linq
            //var query = from a in Flights
            //            group a by a.Destination;
            //lambda
            var query = Flights.GroupBy(i => i.Destination);
            foreach (var item in query)
            {
                Console.WriteLine("Destination" + item.Key);
                foreach( var i in item)
                {
                    Console.WriteLine("Décollage : " + i.FlightDate);
                }
            }
            return query;
        }
    }
}
