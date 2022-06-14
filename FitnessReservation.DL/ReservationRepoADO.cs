using FitnessReservation.BL.Domain;
using FitnessReservation.BL.DTO;
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
    internal class ReservationRepoADO : IReservationRepository {
        private string connectionString;

        public ReservationRepoADO(string connectionString) {
            this.connectionString = connectionString;
        }

        private SqlConnection getConnection() {
            return new SqlConnection(this.connectionString);
        }

        public IReadOnlyList<ReservationInfoDTO> GetReservations(int id) {
            if (id <= 0) {
                throw new ReservationRepoADOException("GetReservations - invalid ID");
            }
            List<ReservationInfoDTO> reservations = new List<ReservationInfoDTO>();
            SqlConnection conn = getConnection();
            string query = "SELECT r.Reservation_date, Slot, Type " +
                "FROM Reservation r " +
                "INNER JOIN Reservationdetails rd ON r.ID=rd.Reservation_id " +
                "INNER JOIN Timeslot t ON t.ID=rd.Timeslot_id " +
                "INNER JOIN Device d ON d.ID=rd.Device_id " +
                "WHERE r.Client_id=@id";

            using (SqlCommand cmd = conn.CreateCommand()) {
                conn.Open();
                try {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.CommandText = query;
                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) {
                        DateTime date = (DateTime)reader["Reservation_date"];
                        string slot = (string)reader["Slot"];
                        string type = (string)reader["Type"];
                        reservations.Add(new ReservationInfoDTO(date, slot, type));
                    }
                    return reservations.AsReadOnly();
                }
                catch (Exception ex) {
                    throw new ReservationRepoADOException("GetReservations", ex);
                }
                finally {
                    conn.Close();
                }
               
            }
        }
    }
}
