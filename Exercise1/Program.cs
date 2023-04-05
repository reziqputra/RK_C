using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Exercise1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program pr =new Program();
            while (true)
            {
                try
                {
                    Console.WriteLine("Koneksi Ke Database\n");
                    Console.WriteLine("Masukkan user ID :");
                    string user = Console.ReadLine();
                    Console.WriteLine("Masukkan Password :");
                    string pass = Console.ReadLine();
                    Console.WriteLine("Masukkan Database Tujuan :");
                    string db = Console.ReadLine();
                    Console.Write("\nKetik K untuk Terhubung ke Database: ");
                    char chr = Convert.ToChar(Console.ReadLine());
                    switch (chr)
                    {
                        case 'k':
                            {
                                SqlConnection conn = null;
                                string strKoneksi = "Data source = MSI; " + "initial catalog = {0};" + "User ID = {1}; password = {2}";
                                conn = new SqlConnection(string.Format(strKoneksi, db, user, pass));
                                conn.Open();
                                Console.Clear();
                                while (true)
                                {
                                    try
                                    {
                                        Console.WriteLine("\nMenu");
                                        Console.WriteLine("1. Melihat Seluruh Data");
                                        Console.WriteLine("2. Tambah Data");
                                        Console.WriteLine("3. Hapus Data");
                                        Console.WriteLine("4. Update Data");
                                        Console.WriteLine("5. Keluar");
                                        Console.Write("\nEnter your choice (1-5): ");
                                        char ch = Convert.ToChar(Console.ReadLine());
                                        switch (ch)
                                        {
                                            case '1':
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("DATA BANK SAMPAH\n");
                                                    Console.WriteLine();
                                                    pr.baca(conn);
                                                }
                                                break;
                                            case '2':
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("INPUT DATA NASABAH\n");
                                                    Console.WriteLine("Masukkan ID :");
                                                    string id_Nasabah = Console.ReadLine();
                                                    Console.WriteLine("Masukkan Nama :");
                                                    string nama = Console.ReadLine();
                                                    Console.WriteLine("Masukkan No Telpon :");
                                                    string no_telp = Console.ReadLine();
                                                    Console.WriteLine("Masukkan Nomor Rekening :");
                                                    string no_rek = Console.ReadLine();
                                                    Console.WriteLine("Masukkan Nama Bank (BNI/BCA) :");
                                                    string bank = Console.ReadLine();
                                                    Console.WriteLine("Masukkan Alamat Nasabah :");
                                                    string alamat = Console.ReadLine();
                                                    try
                                                    {
                                                        pr.insert(id_Nasabah, nama, no_telp, no_rek, bank, alamat, conn);
                                                    }
                                                    catch
                                                    {
                                                        Console.WriteLine("\nAnda tidak memiliki " + "akses untuk menambah data");
                                                    }
                                                }

                                        }
                                    }
                                }
                            }
                    }
                }
            }
        }
    }
}
