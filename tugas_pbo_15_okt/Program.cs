using System;
using System.Collections.Generic;

class Orang
{
    public string Nama { get; set; }
    public int Umur { get; set; }

    public Orang(string nama, int umur)
    {
        Nama = nama;
        Umur = umur;
    }

    public virtual void Aktivitas()
    {
        Console.WriteLine($"{Nama} sedang beraktivitas biasa.");
    }
    public void InfoOrang()
    {
        Console.WriteLine($"Nama: {Nama}, Umur: {Umur}");
    }
}

class Pasien : Orang
{
    public string Keluhan { get; set; }

    public Pasien(string nama, int umur, string keluhan) : base(nama, umur)
    {
        Keluhan = keluhan;
    }
    public void CekKeluhan()
    {
        Console.WriteLine($"{Nama} keluhannya: {Keluhan}");
    }

    public override void Aktivitas()
    {
        Console.WriteLine($"{Nama} (pasien) sedang menunggu giliran");
    }
}

class TenagaMedis : Orang
{
    public string Spesialisasi { get; set; }

    public TenagaMedis(string nama, int umur, string spesialisasi) : base(nama, umur)
    {
        Spesialisasi = spesialisasi;
    }

    public void CekSpesialis()
    {
        Console.WriteLine($"{Nama} (tenaga medis) dengan spesialisasi {Spesialisasi} sedang bertugas");
    }
}

class Dokter : TenagaMedis
{
    public Dokter(string nama, int umur, string spesialisasi) : base(nama, umur, spesialisasi)
    {
    }
    public void Diagnosa()
    {
        Console.WriteLine($"Dr. {Nama} sedang mendiagnosa pasien.");
    }
    public override void Aktivitas()
    {
        Console.WriteLine($"Dr. {Nama} sedang memeriksa pasien.");
    }
}

class Perawat : TenagaMedis
{
    public Perawat(string nama, int umur, string spesialisasi) : base(nama, umur, spesialisasi)
    {
    }
    public void CekPasien()
    {
        Console.WriteLine($"Perawat {Nama} sedang mengecek kondisi pasien");
    }
    public override void Aktivitas()
    {
        Console.WriteLine($"Perawat {Nama} sedang merawat pasien");
    }
}

class PasienAnak : Pasien
{
    public PasienAnak(string nama, int umur, string keluhan) : base(nama, umur, keluhan)
    {
    }
    public void Menangis()
    {
        Console.WriteLine($"{Nama} (anak) menangis karena takut suntik");
    }
    public override void Aktivitas()
    {
        Console.WriteLine($"{Nama} (pasien anak) sedang bermain di ruang tunggu.");
    }
}

class PasienDewasa : Pasien
{
    public PasienDewasa(string nama, int umur, string keluhan) : base(nama, umur, keluhan)
    {
    }

    public void Konsultasi()
    {
        Console.WriteLine($"{Nama} sedang berkonsultasi dengan dokter.");
    }

    public override void Aktivitas()
    {
        Console.WriteLine($"{Nama} (pasien dewasa) sedang mengisi formulir");
    }
}

class RumahSakit
{
    private List<Orang> orangList = new List<Orang>();
    public void TambahOrang(Orang orang)
    {
        orangList.Add(orang);
        Console.WriteLine($"{orang.Nama} ditambahkan ke rumah sakit");
    }
    public void DaftarOrang()
    {
        Console.WriteLine($"\n=== Daftar Orang Dirumahsakit ===");
        foreach (Orang o in orangList)
        {
            o.InfoOrang();
        }
    }
    public List<Orang> GetSemua() => orangList;
}

class Program
{
    static void Main()
    {
        RumahSakit rs = new RumahSakit();

        Dokter dokter = new Dokter("Budi", 40, "Jantung");
        Perawat perawat = new Perawat("Sari", 28, "ICU");
        PasienAnak anak = new PasienAnak("Andi", 7, "Kolestrol");
        PasienDewasa dewasa = new PasienDewasa("Rinna", 25, "Hamil diluar nikah");

        rs.TambahOrang(dokter);
        rs.TambahOrang(perawat);
        rs.TambahOrang(anak);
        rs.TambahOrang(dewasa);

        rs.DaftarOrang();

        Console.WriteLine("\n=== Polymorphism: Aktivitas() ===");
        foreach (Orang o in rs.GetSemua())
        {
            o.Aktivitas();
        }

        Console.WriteLine("\n=== Method Khusus ===");
        dokter.Diagnosa();
        perawat.CekPasien();
        anak.Menangis();
        dewasa.Konsultasi();
        anak.CekKeluhan();
        dokter.CekSpesialis();
    }
}