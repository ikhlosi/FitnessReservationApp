using FitnessReservation.BL.Interfaces;
using FitnessReservation.DL.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessReservation.DL {
    internal class TimeSlotRepoADO : ITimeSlotRepository {
        private string connectionString;

        public TimeSlotRepoADO(string connectionString) {
            this.connectionString = connectionString;
        }

        private SqlConnection getConnection() {
            return new SqlConnection(this.connectionString);
        }

        public IReadOnlyList<string> SelectTimeSlots() {
            SqlConnection connection = getConnection();
            string query = "SELECT Slot FROM [dbo].[Timeslot]";
            List<string> slots = new List<string>();
            using (SqlCommand command = connection.CreateCommand()) {
                command.CommandText = query;
                connection.Open();
                try {
                    IDataReader reader = command.ExecuteReader(); //of SqlDataReader
                    while (reader.Read()) {
                        slots.Add((string)reader["Slot"]);
                    }
                    reader.Close();
                    return slots.AsReadOnly();
                }
                catch (Exception ex) {
                    throw new TimeSlotRepoADOException("SelectTimeSlots", ex);
                }
                finally {
                    connection.Close();
                }
            }
        } 
        
    }
}
