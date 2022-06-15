using FitnessReservation.BL.Interfaces;
using FitnessReservation.BL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using FitnessReservation.DL.Exceptions;

namespace FitnessReservation.DL {
    internal class ClientRepoADO : IClientRepository {
        private string connectionString;

        public ClientRepoADO(string connectionString) {
            this.connectionString = connectionString;
        }

        private SqlConnection getConnection() {
            return new SqlConnection(this.connectionString);
        }

        public string FindClient(int? id, string email) {
            if ((!id.HasValue) && (string.IsNullOrEmpty(email) == true)) {
                throw new ClientRepoADOException("FindClient - no valid input");
            }
                
            SqlConnection conn = getConnection();
            string query = "SELECT Fname from dbo.Client "; 
            //+"WHERE Email = @email";
            if (id.HasValue) {
                query += "WHERE ID=@id";
            } else {
                query += "WHERE Email=@email";
            }
            using (SqlCommand cmd = conn.CreateCommand()) {
                conn.Open();
                try {
                    if (id.HasValue) {
                        cmd.Parameters.AddWithValue("@id", id);
                    } else {
                        cmd.Parameters.AddWithValue("@email", email);
                    }
                    //cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar));
                    //cmd.Parameters["@email"].Value = email;
                    cmd.CommandText = query;
                    //cmd.ExecuteNonQuery();
                    string clientFname = (string)cmd.ExecuteScalar();
                    if (string.IsNullOrEmpty(clientFname)) {
                        throw new ClientRepoADOException("FindClient - Client doesn't exist");
                    }
                    return clientFname;
                }
                catch (ClientRepoADOException) {
                    throw;
                }
                catch (Exception ex) {

                    throw new ClientRepoADOException("FindClient",ex);
                }
                finally {
                    conn.Close();
                }
            }
        }

        public Client GetClientDetails(int? id, string email) {
            if ((!id.HasValue) && (string.IsNullOrEmpty(email) == true)) {
                throw new ClientRepoADOException("GetClientDetails - no valid input");
            }

            SqlConnection conn = getConnection();
            string query = "SELECT * from dbo.Client ";
            //+"WHERE Email = @email";
            if (id.HasValue) {
                query += "WHERE ID=@id";
            } else {
                query += "WHERE Email=@email";
            }
            using (SqlCommand cmd = conn.CreateCommand()) {
                conn.Open();
                try {
                    if (id.HasValue) {
                        cmd.Parameters.AddWithValue("@id", id);
                    } else {
                        cmd.Parameters.AddWithValue("@email", email);
                    }
                    //cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar));
                    //cmd.Parameters["@email"].Value = email;
                    cmd.CommandText = query;
                    //cmd.ExecuteNonQuery();
                    IDataReader reader = cmd.ExecuteReader();
                    if (reader.Read()) {
                        int clientID = (int)reader["ID"];
                        string clientFname = (string)reader["Fname"];
                        string clientLname = (string)reader["Lname"];
                        string clientEmail = (string)reader["Email"];
                        reader.Close();
                        Client c = new Client(clientID,clientEmail,clientFname,clientLname);
                        return c;
                    } else {
                        throw new ClientRepoADOException("GetClientDetails - could not find client");
                    }
                    //string clientFname = (string)cmd.ExecuteScalar();
                    //if (string.IsNullOrEmpty(clientFname)) {
                    //    throw new ClientRepoADOException("FindClient - Client doesn't exist");
                    //}
                    //return clientFname;
                }
                catch (ClientRepoADOException) {
                    throw;
                }
                catch (Exception ex) {

                    throw new ClientRepoADOException("GetClientDetails", ex);
                }
                finally {
                    
                    conn.Close();
                }
            }
        }

        //public Client FindClientById(int id) {
        //    throw new NotImplementedException();
        //}
    }
}
