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

        public int? GetReservationId(int id, DateTime date) { //returns -1 if none found
            if (id <= 0) {
                throw new ReservationRepoADOException("GetReservationId - no valid input");
            }

            SqlConnection conn = getConnection();
            string query = "SELECT ID from dbo.Reservation " +
                "WHERE Client_id=@id AND Reservation_date=@date";
            using (SqlCommand cmd = conn.CreateCommand()) {
                conn.Open();
                try {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.CommandText = query;
                    int? reservationId = (int?)cmd.ExecuteScalar();
                    //if (reservationId == null) {
                    //    return -1;
                    //}
                    //return (int)reservationId;
                    return reservationId;
                }
                catch (Exception ex) {

                    throw new ReservationRepoADOException("GetReservationId", ex);
                }
                finally {
                    conn.Close();
                }
            }
        }

        public int WriteReservationInDB(int id, DateTime date) {
            if (id <= 0) {
                throw new ReservationRepoADOException("WriteReservationInDB - no valid input");
            }
            SqlConnection conn = getConnection();
            string query = "INSERT INTO dbo.Reservation(Client_id,Reservation_date) "
                + "output INSERTED.ID VALUES(@id,@date)";
            try {
                using (SqlCommand cmd = conn.CreateCommand()) {
                    conn.Open();
                    cmd.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@date", System.Data.SqlDbType.Date));
                    cmd.Parameters["@id"].Value = id;
                    cmd.Parameters["@date"].Value = date;
                    cmd.CommandText = query;
                    int reservationID = (int)cmd.ExecuteScalar();
                    return reservationID;
                }
            }
            catch (Exception ex) {
                throw new ReservationRepoADOException("WriteReservationInDB", ex);
            }
            finally {
                conn.Close();
            }
        }

        public void WriteReservationDetailsInDB(int reservationID, int deviceID, int timeslotID) {
            if (reservationID <= 0 || deviceID <= 0 || timeslotID <= 0) {
                throw new ReservationRepoADOException("WriteReservationDetailsInDB - no valid input");
            }
            SqlConnection conn = getConnection();
            string query = "INSERT INTO dbo.Reservationdetails(Reservation_id,Device_id,Timeslot_id) "
                + "VALUES(@revid,@devid,@tsid)";
            try {
                using (SqlCommand cmd = conn.CreateCommand()) {
                    conn.Open();
                    cmd.Parameters.Add(new SqlParameter("@revid", System.Data.SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@devid", System.Data.SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@tsid", System.Data.SqlDbType.Int));
                    cmd.Parameters["@revid"].Value = reservationID;
                    cmd.Parameters["@devid"].Value = deviceID;
                    cmd.Parameters["@tsid"].Value = timeslotID;
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) {
                throw new ReservationRepoADOException("WriteReservationInDB", ex);
            }
            finally {
                conn.Close();
            }
        }
    }
}
