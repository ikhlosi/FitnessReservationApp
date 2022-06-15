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
    }
}
