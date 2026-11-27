# OMI — Prototipe IMK (HTML/CSS/JS)

Prototipe antarmuka **OemahPus Monitoring and Information (OMI)** untuk tugas
IMK. Semua tampilan mengikuti frame **High Fidelity** pada file Figma
`IMK-ADSI-PEMDEKS`.

Stack: HTML + CSS + JavaScript murni (tanpa framework, tanpa build step).

## Cara menjalankan

```powershell
cd IMK-Prototype
python -m http.server 5500
```

Lalu buka `http://localhost:5500/`.

## Akun demo

Password semua akun: `123456`

| Peran               | Username | Email                  |
| ------------------- | -------- | ---------------------- |
| Pemilik Kucing      | `cinta`  | `cinta08@gmail.com`    |
| Pemilik Pet Hotel   | `owner`  | `owner@oemahpus.id`    |
| Staff Operasional   | `rina`   | `rina@oemahpus.id`     |
| Staff Antar Jemput  | `budi`   | `budi@oemahpus.id`     |

Tombol akun demo di halaman Login mengisi form otomatis.

## Halaman per peran

**Pemilik Kucing** — Home, Profil Kucing (tambah/edit/hapus), Pet Tracking,
Reservasi (data → paket → konfirmasi), Pembayaran (QRIS → sukses), Riwayat,
Akun Saya, Ubah Password.

**Pemilik Pet Hotel** — Kelola Layanan (cari + tambah), Riwayat (reservasi /
pembayaran / pemeriksaan medis), Reservasi + slot kandang, Akun Saya,
Ubah Password.

**Staff Operasional** — Daily Report, Buat Daily Report, Pilih Tanggal,
Check In & Out, Riwayat Layanan, Akun Saya, Ubah Password.

**Staff Antar Jemput** — Jadwal, Detail Pesanan, Akun Saya, Ubah Password.

## Catatan kejujuran

- Ini prototipe statis. Tidak ada backend, database, atau payment gateway.
- Data disimpan di `localStorage` dan bisa direset dari halaman Akun Saya.
- QRIS hanya simulasi; tidak ada transaksi nyata.
- Tombol unduh tidak menghasilkan berkas sungguhan.
- Harga, nama, dan data kucing adalah contoh dari desain Figma.
- Password disimpan apa adanya di `localStorage` — **tidak aman untuk produksi**.
- Halaman **Pet Tracking**, **Check In & Out**, dan **Ubah Password** tidak punya
  frame tersendiri di Figma; dibangun mengikuti gaya komponen frame lain.

## Struktur

```
IMK-Prototype/
├── *.html          halaman
├── css/            tokens.css (variabel) + app.css (komponen) + gaya per modul
└── js/
    ├── data.js     data contoh
    ├── common.js   state, navbar, helper, proteksi peran
    ├── auth.js     login & sign up
    └── page-*.js   logika per halaman
```