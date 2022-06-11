

// See https://aka.ms/new-console-template for more information
using FitnessReservation.BL.Domain;

Console.WriteLine("Hello, World!");

Client c = new Client(1, "tom@vdwiel.be", "Tom", "VDW");
Device d = new Device(2, "loopband");
Reservation r = new Reservation(3, new DateTime(2009, 1, 1, 0, 0, 0, DateTimeKind.Utc), c);
TimeSlot t = new TimeSlot(4);
r.AddSession(t.ID,d.ID);

Console.WriteLine(c.FirstName);
Console.WriteLine(t.ID);
Console.WriteLine(r.ReservationDate);
