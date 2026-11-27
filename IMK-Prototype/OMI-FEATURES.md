# OMI — OemahPus Monitoring & Information · Daftar Fitur

Dokumen ini merangkum seluruh fitur prototipe **OMI** (pet hotel kucing) yang ada di folder `IMK-Prototype/`. Dipakai sebagai acuan untuk membangun ulang proyek serupa di folder lain.

- **Sumber kebenaran tampilan:** folder `IMK-Prototype/` (HTML/CSS/JS).
- **Sumber kebenaran desain:** Figma High Fidelity, page `New High Fidelity`, 28 frame.
- **Jenis proyek:** prototipe tugas IMK. Vanilla HTML + CSS + JavaScript, tanpa framework, tanpa build tool, tanpa backend.

---

## 1. Ringkasan

Prototipe aplikasi pet hotel kucing dengan **4 peran**: Pemilik Kucing (customer), Pemilik Pet Hotel (admin), Staff Operasional, dan Staff Antar Jemput (kurir). Tiap peran punya navigasi, beranda, dan kumpulan tugas sendiri.

Seluruh data bersifat **contoh (mock)** dan disimpan di `localStorage` browser. Tidak ada koneksi ke database, API, atau payment gateway sungguhan.

---

## 2. Arsitektur & Batas

| Aspek | Nilai |
|---|---|
| Halaman | 28 file HTML |
| Gaya | 11 file CSS (`app`, `tokens`, `auth`, `home`, `cats`, `tracking`, `reservasi`, `pembayaran`, `admin`, `staff`, `akun`) |
| Logika | 13 file JS (`data`, `common`, `auth`, 10 `page-*`) |
| Penyimpanan | `localStorage`, key `omi_imk_prototype_v2` |
| Design token | `css/tokens.css` (variabel warna, spasi, tipografi) |
| Backend | tidak ada |
| Auth | pencocokan data contoh, **bukan** autentikasi aman |
| Gambar | placeholder gradien + emoji (bukan file foto) |

**Catatan kejujuran** (ditampilkan di UI, bukan disembunyikan):

- Pembayaran hanya simulasi, tidak ada transaksi nyata.
- Laporan harian tidak diperbarui real-time.
- Autentikasi hanya mencocokkan data contoh di localStorage.
- Data kucing/staff/reservasi adalah data contoh.

---

## 3. Peran, Akun Demo & Navigasi

### 3.1 Akun demo

Tombol cepat tersedia di halaman Login (`data-user`). Klik = isi form otomatis + submit.

| Peran | Username | Password | Nama | Inisial | Label navbar | Beranda |
|---|---|---|---|---|---|---|
| customer | `cinta` | `123456` | Cinta Cahyaning | C | — (tanpa tag) | `home.html` |
| admin | `owner` | `123456` | Pemilik OemahPus | P | Pemilik Pet Hotel | `admin-kelola-layanan.html` |
| staff | `rina` | `123456` | Rina Wulandari | R | Staff Operasional | `staff-daily-report.html` |
| kurir | `budi` | `123456` | Budi Santoso | B | Staff Antar Jemput | `staff-antar-jemput.html` |

### 3.2 Menu navbar per peran

| Peran | Item menu (urutan) |
|---|---|
| customer | Home · Profil Kucing · Pet Tracking · Reservasi · Riwayat · Akun Saya |
| admin | Kelola Layanan · Riwayat · Reservasi · Akun Saya |
| staff | Daily Report · Check In & Out · Riwayat Layanan · Akun Saya |
| kurir | Jadwal · Detail Pesanan · Akun Saya |

Struktur navbar (kecuali customer, memakai tag peran): brand (link ke beranda peran) · tag peran · menu · chip pengguna (avatar inisial + nama depan) · tombol **Keluar**.

### 3.3 Proteksi & pengalihan

- `omiRequireRole(peran)` memblokir halaman lintas peran → dialihkan ke beranda peran sendiri.
- Belum login → dialihkan ke `index.html`.
- Sudah login tapi buka Login → otomatis dialihkan ke beranda peran.
- **Keluar** menghapus `sesi` + `draftReservasi` lalu kembali ke Login.

---

## 4. Fitur Autentikasi

### 4.1 Login (`index.html`)

- Field: Username (bisa juga email) + Password.
- Validasi: keduanya wajib diisi.
- Pesan error: `Username atau password salah. Coba akun demo di bawah.`
- Blok **Akun demo** berisi 4 tombol peran; klik → auto-isi + masuk.
- Submit berhasil → redirect ke beranda sesuai peran.

### 4.2 Sign Up (`signup.html`)

- Field: Email, Phone Number, Username, Password, Confirm Password.
- Aturan validasi (berurutan):

| Cek | Aturan | Pesan |
|---|---|---|
| Kosong | semua kolom wajib | "Semua kolom wajib diisi." |
| Email | pola `nama@email.com` | "Format email belum benar." |
| Telepon | angka/`+`/`-`/spasi, 8–20 digit | "Nomor HP hanya boleh angka, 8–20 digit." |
| Username | minimal 3 karakter | "Username minimal 3 karakter." |
| Password | minimal 6 karakter | "Password minimal 6 karakter." |
| Konfirmasi | harus sama dengan password | "Password dan konfirmasi tidak sama." |
| Duplikat | username/email belum terdaftar | "Username atau email sudah terdaftar." |

- Akun baru selalu berperan **customer**.
- Setelah sukses: pesan singkat → otomatis login → beranda.

### 4.3 Ubah Password (`ubah-password.html`)

- Field: Password Lama, Password Baru, Konfirmasi Password Baru.
- Tombol: **Batal** (→ Akun Saya) dan **Simpan Password**.
- Dipakai bersama semua peran (versi prototipe = satu halaman).

### 4.4 Keluar

- Tombol **Keluar** di navbar (semua halaman) dan **Keluar dari Akun** di Akun Saya.

---

## 5. Fitur Customer (Pemilik Kucing)

### 5.1 Home (`home.html`)
- Hero + judul + tombol **Reservasi Sekarang** dan **Lihat Layanan**.
- Section "Empat Langkah Memulai" (kartu langkah).
- Section "Paket Layanan di OMI" (kartu paket + tombol **Lihat Detail**).

### 5.2 Profil Kucing (`profil-kucing.html`)
- Kartu tiap kucing: foto (emoji), nama · usia, ras · jenis kelamin, tombol **Edit** + **Hapus**.
- Tombol **+ Tambah Kucing** (header) dan **FAB +** (kanan bawah).
- Hapus memakai konfirmasi; kucing yang masih dipakai reservasi tidak boleh dihapus.
- Empty state bila belum ada kucing.

### 5.3 Tambah / Edit Kucing (`tambah-kucing.html`, `edit-kucing.html`)
- Field: Nama, Usia (tahun), Jenis Kelamin (select), Ras, Warna & Corak Bulu, Berat (kg), Catatan Penyakit (textarea).
- Panel foto: **Ubah Foto Kucing** (ganti emoji) + **Hapus Foto Kucing**.
- Tombol: **Batal** + **Simpan**.
- Validasi: nama wajib; usia 0–30; berat 0.1–30.

### 5.4 Pet Tracking (`pet-tracking.html`)
- Kartu penitipan aktif (nama, kandang, paket, check-in, badge **Sedang Menginap**).
- Tabel "Laporan Harian Terbaru": Tanggal · Kucing · Kandang · Makan · Kondisi · Catatan.
- Empty state + tombol **Reservasi Sekarang**.
- Catatan kejujuran: laporan = data contoh, tidak real-time.

### 5.5 Reservasi — 2 Langkah
1. **Data & Paket** (`reservasi-data.html`): Nama, No. HP, Alamat, Catatan Kesehatan, pilih kucing; section **Pilih Paket Layanan** (2 kartu: Reguler & Premium); baris add-on **Tambahkan layanan antar jemput** (checkbox, Rp50.000/trip). Tombol **Batal** (→ Home) + **Selanjutnya**.
2. **Konfirmasi** (`reservasi-konfirmasi.html`): kalender pilih check-in & check-out, rincian biaya (harga paket, jumlah malam, layanan tambahan, total), status pengajuan, ringkasan. Tombol **Kembali** (→ Data & Paket) + **Ajukan**.

Catatan: harga contoh, bukan tarif resmi. Layanan antar jemput disimpan sebagai `tambahan: [{ nama, harga }]` sehingga otomatis muncul di **Biaya Layanan Tambahan** pada halaman Pembayaran/Sukses/Riwayat.

Validasi: nama/telepon/alamat wajib; minimal 1 kucing dipilih; minimal 1 paket dipilih; antar jemput opsional; tanggal masuk & keluar wajib (tanggal keluar harus setelah masuk, tanpa bentrok jadwal kucing).

### 5.6 Pembayaran
- **Pembayaran** (`pembayaran.html`): info pemilik, rincian biaya, pilih metode **QRIS** / **Tunai di Lokasi**, status, tombol **Lanjut ke Pembayaran**. Catatan: hanya simulasi.
- **Pembayaran QRIS** (`pembayaran-qris.html`): ilustrasi QR (tidak dapat dipindai), nominal, timer, tombol **Simulasikan Pembayaran Berhasil**, **Unduh Kode QR**, **Kembali ke Riwayat**.
- **Pembayaran Sukses** (`pembayaran-sukses.html`): ikon sukses, bukti pembayaran, rincian final, tombol **Lihat Riwayat** + **Unduh Bukti Pembayaran** (print). Catatan: bukti simulasi, bukan bukti sah.

### 5.7 Riwayat (`riwayat.html`)
- Kartu reservasi + tombol **Lihat** (→ Pembayaran) dan **Reservasi Baru**.
- Tabel "Riwayat Pembayaran": Nama Reservasi · Harga · Tanggal · Status.
- Empty state.

### 5.8 Akun Saya (`akun-saya.html`)
- Kartu identitas: avatar inisial, nama, email, badge peran.
- Tombol **Keluar dari Akun**.
- Form Informasi Akun: Nama depan, Nama belakang, No. telepon, Email, Alamat.
- Tombol **Ubah Password** + **Simpan Perubahan** (validasi + pesan sukses).
- Catatan: tombol **Reset Data Demo** sudah dihapus.

---

## 6. Fitur Admin (Pemilik Pet Hotel)

### 6.1 Kelola Layanan (`admin-kelola-layanan.html`)
- Kartu paket layanan (4 kolom) + tombol **Edit** (→ Tambah/Edit Layanan) + **Hapus**.
- Tombol **+ Tambah Layanan** + search "Cari nama layanan...".
- Hapus paket yang masih dipakai reservasi ditolak.

### 6.2 Tambah / Edit Layanan (`admin-tambah-layanan.html`)
- Field: Nama Layanan, Jenis (select: Penitipan/Grooming/Antar Jemput/Tambahan), Harga, Satuan, Deskripsi.
- Tombol **Batal** + **Simpan**.

### 6.3 Reservasi (`admin-reservasi.html`)
- Tabel "Informasi Reservasi": ID · Pemilik · Kucing · Check In · Status.
- Panel "Data Kucing & Pemilik" (detail + catatan kesehatan).
- Panel "Slot Ketersediaan Kandang": grid 16 kandang (A-01..A-08, B-01..B-08), legenda **Tersedia / Terisi / Maintenance**.
- Klik slot untuk memutar status: Tersedia → Terisi → Maintenance. Tombol **Catat Slot**.

### 6.4 Riwayat (tab) — `admin-riwayat-reservasi.html`, `admin-riwayat-pembayaran.html`, `admin-riwayat-medis.html`
- Tab: **Riwayat Reservasi** · **Riwayat Pembayaran** · **Riwayat Pemeriksaan Medis**.
- Riwayat Reservasi: ID Reservasi · Pemilik · Kucing · Paket · Tanggal · Status.
- Riwayat Pembayaran: ID · Pemilik · Nominal · Metode · Tanggal · Status.
- Riwayat Medis: Kucing · Pemilik · Tanggal · Pemeriksaan · Kondisi · Catatan.

---

## 7. Fitur Staff Operasional

### 7.1 Daily Report (`staff-daily-report.html`)
- Search + tombol pilih tanggal (`Kamis, 12 November 2026`).
- Grid 4 kartu penitipan: nama, foto, kandang · paket, check-in, tombol **Buat Laporan**.

### 7.2 Buat Laporan (`staff-buat-laporan.html`)
- Header "Buat Daily Report" + tanggal; baris info penitipan (kucing + kandang/paket/check-in).
- Field: Nama Kucing (readonly), Tanggal, Makan, Minum, Kondisi, Nama Kandang, Catatan.
- Tombol **Batal** + **Kirim Daily Report**.
- Membutuhkan `?id=brd-xx`; tanpa itu dialihkan ke Daily Report.

### 7.3 Pilih Tanggal (`staff-pilih-tanggal.html`)
- Kartu kalender: head (◀ bulan ▶), grid 7 kolom, tanggal terpilih disorot.
- Tombol **Kembali** + **Lanjut**.

### 7.4 Check In & Out (`staff-checkin-out.html`)
- Daftar penitipan aktif: foto, nama, kandang · paket, check-in, badge **Sedang Menginap**, tombol **Catat Check-out**.
- Catatan kejujuran: check-out hanya menghapus baris dari daftar aktif; riwayat tidak terhapus.

### 7.5 Riwayat Layanan (`staff-riwayat-layanan.html`)
- Search + tabel: Tanggal · Kucing · Layanan · Petugas · Status.

---

## 8. Fitur Kurir (Staff Antar Jemput)

### 8.1 Jadwal (`staff-antar-jemput.html`)
- Header + tombol pilih tanggal.
- Kartu tugas: ikon, nama (…'s Stay), jam jemput, alamat, badge status, tombol **Perbarui**.

### 8.2 Detail Pesanan (`staff-detail-antar-jemput.html`)
- Kartu "Informasi Pesanan": Pemilik · Kucing · Alamat Penjemputan · Jadwal Jemput.
- Kartu "Perbarui Status": select status + tombol **Sudah Di Jemput**, **Belum Di Jemput**, **Simpan**, **Batal**.
- Membutuhkan `?id=pu-xx`.

---

## 9. Peta Halaman → File

| # | Frame Figma | File HTML |
|---|---|---|
| 01 | Login | `index.html` |
| 02 | Sign Up | `signup.html` |
| 03 | Home | `home.html` |
| 04 | Profil Kucing | `profil-kucing.html` |
| 05 | Tambah Kucing | `tambah-kucing.html` |
| 06 | Edit Kucing | `edit-kucing.html` |
| 07 | Pet Tracking | `pet-tracking.html` |
| 08 | Reservasi Data | `reservasi-data.html` |
| 09 | Reservasi Konfirmasi | `reservasi-konfirmasi.html` |
| 10 | Pembayaran | `pembayaran.html` |
| 11 | Pembayaran QRIS | `pembayaran-qris.html` |
| 12 | Pembayaran Sukses | `pembayaran-sukses.html` |
| 13 | Riwayat Reservasi | `riwayat.html` |
| 14 | Akun Saya | `akun-saya.html` |
| 15 | Ubah Password | `ubah-password.html` |
| 16 | Admin - Kelola Layanan | `admin-kelola-layanan.html` |
| 17 | Admin - Tambah Layanan | `admin-tambah-layanan.html` |
| 18 | Admin - Reservasi | `admin-reservasi.html` |
| 19 | Admin - Riwayat Reservasi | `admin-riwayat-reservasi.html` |
| 20 | Admin - Riwayat Pembayaran | `admin-riwayat-pembayaran.html` |
| 21 | Admin - Riwayat Medis | `admin-riwayat-medis.html` |
| 22 | Staff - Daily Report | `staff-daily-report.html` |
| 23 | Staff - Buat Laporan | `staff-buat-laporan.html` |
| 24 | Staff - Pilih Tanggal | `staff-pilih-tanggal.html` |
| 25 | Staff - Check In & Out | `staff-checkin-out.html` |
| 26 | Staff - Riwayat Layanan | `staff-riwayat-layanan.html` |
| 27 | Kurir - Jadwal | `staff-antar-jemput.html` |
| 28 | Kurir - Detail Pesanan | `staff-detail-antar-jemput.html` |

---

## 10. Alur Utama (Happy Path)

- **Login → peran:** `index.html` → (demo/isi form) → beranda sesuai peran.
- **Reservasi:** `08` (data + kucing + paket + antar jemput) → `09 Konfirmasi` → `10 Pembayaran` → `11 QRIS` → `12 Sukses` → `13 Riwayat`.
- **Kelola kucing:** `04` → `05`/`06` (tambah/edit) → kembali `04`.
- **Daily Report:** `22` → `24` (pilih tanggal) → `23` (buat laporan) → kembali `22`.
- **Antar jemput:** `27` → `28` (detail + update status) → kembali `27`.
- **Akun:** `14` → `15` (ubah password) → kembali `14`; **Keluar** → `01 Login`.

---

## 11. Data Model (Mock)

Key `localStorage`: `omi_imk_prototype_v2`. `OMI_DEFAULT_STATE`:

| Field | Isi |
|---|---|
| `users` | 4 akun (customer/admin/staff/kurir) |
| `kucing` | 3 kucing (Luna, Simba, Mochi) |
| `paket` | 4 paket (Reguler, Premium, Grooming, Antar Jemput) |
| `reservasi` | 3 reservasi contoh |
| `pembayaran` | 2 pembayaran contoh |
| `penitipan` | 4 penitipan aktif (`brd-01`..`brd-04`) |
| `antarJemput` | 2 tugas (`pu-01`, `pu-02`) |
| `riwayatReservasi` | 6 baris (RSV-0039..0044) |
| `riwayatPembayaran` | 6 baris |
| `riwayatMedis` | 6 baris |
| `riwayatLayanan` | 7 baris (badge Terkirim/Selesai/Draft) |
| `kandang` | 16 slot A/B (Tersedia/Terisi/Maintenance) |
| `laporan` | `[]` (diisi saat submit laporan) |
| `sesi` | `null` → `{ userId, role, nama, email, inisial }` |
| `draftReservasi` | `null` → data sementara 2 langkah reservasi (+ `tambahan` untuk antar jemput) |

Helper state: `omiState()`, `omiUpdate(mutator)`, `omiResetState()`.

---

## 12. Status & Badge

`omiStatusBadge(status)` memetakan status ke jenis badge:

| Badge | Status |
|---|---|
| **success** (hijau) | Selesai, Disetujui, Lunas, Pembayaran Sukses, Sudah Di Jemput, Sehat, Tersedia |
| **warning** (kuning) | Menunggu, Menunggu Pembayaran, Perhatian, Maintenance |
| **info** (oranye muda) | Berlangsung, Terisi, Terkirim, Belum Di Jemput, Menunggu Konfirmasi |
| **danger** (merah) | Dibatalkan |
| **neutral** (abu) | Draft |

---

## 13. UI System

- **Komponen Figma:** `Navbar/Customer`, `Navbar/Admin`, `Navbar/Staff`, `Navbar/Kurir`, `Button/*` (Primary/Soft/Danger/Ghost, SM/MD/LG), `Badge/*` (Success/Warning/Info/Neutral), `Form/Input|Textarea|Select`, `Step/Active|Done|Inactive`, `Card`, `Footer`.
- **Token warna:** `primary`, `primary-dark`, `primary-light`, `primary-mid`, `bg-page`, `bg-card`, `bg-soft`, `border`, `border-input`, `text`, `text-2`, `text-3`, `text-muted`, `text-faint`, `success`, `success-bg`, `warning`, `warning-bg`, `danger`, `danger-bg`, `gradient-from`, `gradient-to`.
- **Tipografi:** Plus Jakarta Sans (Regular/Medium/SemiBold/Bold/ExtraBold).
- **Placeholder gambar:** gradien (149.18deg, `gradient-from`→`gradient-to`) + emoji.
- **Komponen HTML/CSS:** `.omi-btn`, `.omi-card`, `.omi-badge`, `.omi-input`, `.omi-select`, `.omi-textarea`, `.omi-field`, `.omi-navbar`, `.omi-table`, `.omi-empty`, `.omi-alert`, `.omi-fab`, dll.

---

## 14. Yang Sengaja Tidak Ada

- Backend, database, API, autentikasi aman.
- Upload berkas gambar asli (hanya ganti emoji).
- QR pembayaran asli / integrasi payment gateway.
- Notifikasi & data real-time.
- Filter/search yang persisten antar halaman.
- Tombol **Reset Data Demo** (sengaja dihapus dari Akun Saya).
- Halaman kurir lama yang redundan (fokus pada 28 halaman di atas).

---

## 15. Cara Menjalankan

```bash
cd IMK-Prototype
python -m http.server 5500
# buka http://localhost:5500/index.html
```

Login dengan salah satu akun demo di halaman Login, atau klik tombol peran pada blok **Akun demo**.
