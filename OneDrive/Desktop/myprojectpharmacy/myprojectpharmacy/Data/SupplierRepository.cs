using myprojectpharmacy.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

public class SupplierRepository
{
    private readonly string _connectionString;

    public SupplierRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<Supplier> GetAllSuppliers()
    {
        var suppliers = new List<Supplier>();

        using var conn = new SqlConnection(_connectionString);
        using var cmd = new SqlCommand("SELECT Id, Name, Phone, Medications FROM Suppliers", conn);
        conn.Open();

        using SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            suppliers.Add(new Supplier
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                Name = reader.GetString(reader.GetOrdinal("Name")),
                Phone = reader.GetString(reader.GetOrdinal("Phone")),
                Medications = reader.GetString(reader.GetOrdinal("Medications"))
            });
        }

        return suppliers;
    }

    public void AddSupplier(Supplier supplier)
    {
        using var conn = new SqlConnection(_connectionString);
        using var cmd = new SqlCommand(@"
            INSERT INTO Suppliers (Name, Phone, Medications)
            VALUES (@Name, @Phone, @Medications)", conn);

        cmd.Parameters.AddWithValue("@Name", supplier.Name);
        cmd.Parameters.AddWithValue("@Phone", supplier.Phone);
        cmd.Parameters.AddWithValue("@Medications", supplier.Medications);

        conn.Open();
        cmd.ExecuteNonQuery();
    }

    public Supplier? GetSupplierById(int id)
    {
        using var conn = new SqlConnection(_connectionString);
        using var cmd = new SqlCommand("SELECT Id, Name, Phone, Medications FROM Suppliers WHERE Id = @Id", conn);
        cmd.Parameters.AddWithValue("@Id", id);

        conn.Open();
        using var reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            return new Supplier
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                Name = reader.GetString(reader.GetOrdinal("Name")),
                Phone = reader.GetString(reader.GetOrdinal("Phone")),
                Medications = reader.GetString(reader.GetOrdinal("Medications"))
            };
        }

        return null;
    }

    public void UpdateSupplier(Supplier supplier)
    {
        using var conn = new SqlConnection(_connectionString);
        using var cmd = new SqlCommand(@"
            UPDATE Suppliers 
            SET Name = @Name, Phone = @Phone, Medications = @Medications 
            WHERE Id = @Id", conn);

        cmd.Parameters.AddWithValue("@Id", supplier.Id);
        cmd.Parameters.AddWithValue("@Name", supplier.Name);
        cmd.Parameters.AddWithValue("@Phone", supplier.Phone);
        cmd.Parameters.AddWithValue("@Medications", supplier.Medications);

        conn.Open();
        cmd.ExecuteNonQuery();
    }

    public void DeleteSupplier(int id)
    {
        using var conn = new SqlConnection(_connectionString);
        using var cmd = new SqlCommand("DELETE FROM Suppliers WHERE Id = @Id", conn);
        cmd.Parameters.AddWithValue("@Id", id);

        conn.Open();
        cmd.ExecuteNonQuery();
    }
}
