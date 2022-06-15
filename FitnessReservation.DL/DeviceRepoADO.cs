using FitnessReservation.BL.Domain;
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
    internal class DeviceRepoADO : IDeviceRepository {
        private string connectionString;

        public DeviceRepoADO(string connectionString) {
            this.connectionString = connectionString;
        }

        private SqlConnection getConnection() {
            return new SqlConnection(this.connectionString);
        }

        public IReadOnlyList<string> SelectDevices() {
            SqlConnection connection = getConnection();
            string query = "SELECT DISTINCT Type FROM [dbo].[Device] WHERE Is_usable=1";
            List<string> devices = new List<string>();
            using (SqlCommand command = connection.CreateCommand()) {
                command.CommandText = query;
                connection.Open();
                try {
                    IDataReader reader = command.ExecuteReader(); //of SqlDataReader
                    while (reader.Read()) {
                        devices.Add((string)reader["Type"]);
                    }
                    reader.Close();
                    return devices.AsReadOnly();
                }
                catch (Exception ex) {
                    throw new DeviceRepoADOException("SelectDevices", ex);
                }
                finally {
                    connection.Close();
                }
            }
        }

        public IReadOnlyList<Device> GetAllDevices() {
            List<Device> devices = new List<Device>();
            SqlConnection conn = getConnection();
            string query = "SELECT * FROM [dbo].[Device]";
            using (SqlCommand command = conn.CreateCommand()) {
                command.CommandText = query;
                conn.Open();
                try {
                    IDataReader reader = command.ExecuteReader(); //of SqlDataReader
                    while (reader.Read()) {
                        int id = (int)reader["ID"];
                        string type = (string)reader["Type"];
                        bool availability = (bool)reader["Is_usable"];
                        Device d = new Device(id, type, availability);
                        devices.Add(d);
                    }
                    reader.Close();
                    return devices.AsReadOnly();
                }
                catch (Exception ex) {
                    throw new DeviceRepoADOException("GetAllDevices", ex);
                }
                finally {
                    conn.Close();
                }
            }
        }

        public IReadOnlyList<Device> GetDevicesOfType(string selectedItem) {
            List<Device> devices = new List<Device>();
            SqlConnection conn = getConnection();
            string query = "SELECT * FROM [dbo].[Device] WHERE Type=@type";
            using (SqlCommand command = conn.CreateCommand()) {
                command.CommandText = query;
                conn.Open();
                try {
                    command.Parameters.AddWithValue("@type", selectedItem);
                    IDataReader reader = command.ExecuteReader(); //of SqlDataReader
                    while (reader.Read()) {
                        int id = (int)reader["ID"];
                        string type = (string)reader["Type"];
                        bool availability = (bool)reader["Is_usable"];
                        Device d = new Device(id, type, availability);
                        devices.Add(d);
                    }
                    reader.Close();
                    return devices.AsReadOnly();
                }
                catch (Exception ex) {
                    throw new DeviceRepoADOException("GetDeviceOfType", ex);
                }
                finally {
                    conn.Close();
                }
            }
        }

        public void RemoveDevice(int deviceID) {
            SqlConnection conn = getConnection();
            string query = "DELETE FROM [dbo].[Device] WHERE ID=@id";
            using (SqlCommand command = conn.CreateCommand()) {
                command.CommandText = query;
                conn.Open();
                try {
                    command.Parameters.AddWithValue("@id", deviceID);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex) {
                    throw new DeviceRepoADOException("RemoveDevice", ex);
                }
                finally {
                    conn.Close();
                }
            }
        }

        public void MarkDeviceAvailable(int iD) {
            SqlConnection conn = getConnection();
            string query = "UPDATE [dbo].[Device] " +
                "SET Is_usable=1 " +
                "WHERE ID=@id";
            using (SqlCommand command = conn.CreateCommand()) {
                command.CommandText = query;
                conn.Open();
                try {
                    command.Parameters.AddWithValue("@id", iD);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex) {
                    throw new DeviceRepoADOException("RemoveDevice", ex);
                }
                finally {
                    conn.Close();
                }
            }
        }

        public void MarkDeviceUnAvailable(int iD) {
            SqlConnection conn = getConnection();
            string query = "UPDATE [dbo].[Device] " +
                "SET Is_usable=0 " +
                "WHERE ID=@id";
            using (SqlCommand command = conn.CreateCommand()) {
                command.CommandText = query;
                conn.Open();
                try {
                    command.Parameters.AddWithValue("@id", iD);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex) {
                    throw new DeviceRepoADOException("RemoveDevice", ex);
                }
                finally {
                    conn.Close();
                }
            }
        }

        public void AddDevice(string type) {
            SqlConnection conn = getConnection();
            string query = "INSERT INTO [dbo].[Device](Type,Is_usable) " +
                "VALUES(@type,1)";
            using (SqlCommand command = conn.CreateCommand()) {
                command.CommandText = query;
                conn.Open();
                try {
                    command.Parameters.AddWithValue("@type", type);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex) {
                    throw new DeviceRepoADOException("RemoveDevice", ex);
                }
                finally {
                    conn.Close();
                }
            }

        }
    }
}
