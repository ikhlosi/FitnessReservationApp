// See https://aka.ms/new-console-template for more information
using FitnessReservation.BL.Managers;
using FitnessReservation.DL;

Console.WriteLine("Hello, World!");

string connectionString = @"Data Source=DESKTOP-QT687QR\SQLEXPRESS;Initial Catalog=FitnessCentre;Integrated Security=True";

ClientManager m = new ClientManager(new ClientRepoADO(connectionString));

Console.WriteLine(m.GetClientFname(1, null));
Console.WriteLine(m.GetClientFname(null, "ibra@khlosi.com"));
