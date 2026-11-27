/* ==========================================================================
   OMI — Data Contoh (mock data)
   Semua data di sini adalah DATA DEMONSTRASI untuk prototipe tugas IMK.
   Tidak ada koneksi ke database, API, atau payment gateway sungguhan.

   Isi angka (harga paket, dsb.) diambil dari desain Figma agar tampilan
   konsisten dengan High Fidelity yang menjadi acuan.
   ========================================================================== */

const OMI_STORE_KEY = "omi_imk_prototype_v2";

/* --------------------------------------------------------------------------
   Akun demo — 4 peran sesuai navbar High Fidelity
   -------------------------------------------------------------------------- */
const OMI_USERS = [
  {
    id: "u-001",
    role: "customer",
    nama: "Cinta Cahyaning",
    email: "cinta08@gmail.com",
    username: "cinta",
    password: "123456",
    telepon: "0812-3456-7890",
    alamat: "Jl. Ketintang No. 12, Gayungan, Surabaya",
    inisial: "C",
  },
  {
    id: "u-002",
    role: "admin",
    nama: "Pemilik OemahPus",
    email: "owner@oemahpus.id",
    username: "owner",
    password: "123456",
    telepon: "0812-3456-7890",
    alamat: "Jl. Ketintang No. 12, Gayungan, Surabaya",
    inisial: "P",
  },
  {
    id: "u-003",
    role: "staff",
    nama: "Rina Wulandari",
    email: "rina@oemahpus.id",
    username: "rina",
    password: "123456",
    telepon: "0812-3456-7890",
    alamat: "Jl. Ketintang No. 12, Gayungan, Surabaya",
    inisial: "R",
  },
  {
    id: "u-004",
    role: "kurir",
    nama: "Budi Santoso",
    email: "budi@oemahpus.id",
    username: "budi",
    password: "123456",
    telepon: "0812-3456-7890",
    alamat: "Jl. Ketintang No. 12, Gayungan, Surabaya",
    inisial: "B",
  },
];

/* --------------------------------------------------------------------------
   Paket layanan (frame 15/16 — 4 kartu: Reguler, Premium, Grooming, Antar Jemput)
   -------------------------------------------------------------------------- */
const OMI_PAKET = [
  {
    id: "pkg-01",
    nama: "Paket Reguler",
    jenis: "Penitipan",
    harga: 70000,
    satuan: "malam",
    deskripsi: "Kandang ber-AC & area bermain luas",
    fitur: ["Kandang ber-AC & area bermain luas", "Makan 2x sehari + update foto harian"],
  },
  {
    id: "pkg-02",
    nama: "Paket Premium",
    jenis: "Penitipan",
    harga: 120000,
    satuan: "malam",
    deskripsi: "Kamar premium dengan CCTV 24 jam",
    fitur: ["Kamar premium dengan CCTV 24 jam", "Grooming ringan & vitamin termasuk"],
  },
  {
    id: "pkg-03",
    nama: "Paket Grooming",
    jenis: "Grooming",
    harga: 90000,
    satuan: "sesi",
    deskripsi: "Grooming lengkap: mandi & potong kuku",
    fitur: ["Grooming lengkap: mandi & potong kuku", "Parfum aman khusus kucing"],
  },
  {
    id: "pkg-04",
    nama: "Paket Antar Jemput",
    jenis: "Antar Jemput",
    harga: 50000,
    satuan: "trip",
    deskripsi: "Antar jemput area Surabaya",
    fitur: ["Antar jemput area Surabaya", "Carrier aman & driver berpengalaman"],
  },
];

/* --------------------------------------------------------------------------
   Data kucing (frame 04, 05, 06, 07)
   -------------------------------------------------------------------------- */
const OMI_KUCING = [
  {
    id: "cat-01",
    nama: "Luna",
    usia: 1,
    jenisKelamin: "Betina",
    ras: "Anggora",
    warna: "Putih bersih",
    berat: 3.2,
    catatan: "-",
    emoji: "🐱",
    pemilikId: "u-001",
  },
  {
    id: "cat-02",
    nama: "Simba",
    usia: 3,
    jenisKelamin: "Jantan",
    ras: "Domestik",
    warna: "Oranye belang",
    berat: 4.5,
    catatan: "Alergi makanan berbahan ayam",
    emoji: "🐈",
    pemilikId: "u-001",
  },
  {
    id: "cat-03",
    nama: "Mochi",
    usia: 2,
    jenisKelamin: "Betina",
    ras: "Persia",
    warna: "Abu-abu muda",
    berat: 2.8,
    catatan: "Alergi makanan seafood.",
    emoji: "🐈‍⬛",
    pemilikId: "u-001",
  },
];

/* --------------------------------------------------------------------------
   Reservasi milik pemilik kucing yang login (frame 07–11)
   -------------------------------------------------------------------------- */
const OMI_RESERVASI = [
  {
    id: "res-001",
    nama: "Ayen's Stay",
    kucingId: "cat-01",
    paketId: "pkg-02",
    checkIn: "2026-11-10",
    checkOut: "2026-11-12",
    tambahan: [{ nama: "Grooming Ringan", harga: 20000 }],
    status: "Selesai",
    pemilikId: "u-001",
  },
  {
    id: "res-002",
    nama: "Miku's Stay",
    kucingId: "cat-03",
    paketId: "pkg-01",
    checkIn: "2026-11-15",
    checkOut: "2026-11-17",
    tambahan: [],
    status: "Menunggu Pembayaran",
    pemilikId: "u-001",
  },
  {
    id: "res-003",
    nama: "Simba's Stay",
    kucingId: "cat-02",
    paketId: "pkg-01",
    checkIn: "2026-11-20",
    checkOut: "2026-11-22",
    tambahan: [],
    status: "Menunggu",
    pemilikId: "u-001",
  },
];

/* --------------------------------------------------------------------------
   Riwayat pembayaran milik pemilik kucing (frame 10–13)
   -------------------------------------------------------------------------- */
const OMI_PEMBAYARAN = [
  {
    id: "PAY-20261110-0042",
    reservasiId: "res-001",
    nama: "Ayen's Stay",
    total: 140000,
    tanggal: "2026-11-05",
    status: "Pembayaran Sukses",
    metode: "QRIS",
  },
  {
    id: "PAY-20261101-0038",
    reservasiId: "res-002",
    nama: "Miku's Stay",
    total: 70000,
    tanggal: "2026-11-10",
    status: "Menunggu Pembayaran",
    metode: "-",
  },
];

/* --------------------------------------------------------------------------
   Penitipan aktif (frame 17–19 — Staff Daily Report)
   -------------------------------------------------------------------------- */
const OMI_PENITIPAN = [
  { id: "brd-01", nama: "Mochi", kandang: "B-04", paket: "Paket Premium", checkIn: "2026-11-10", emoji: "🐈‍⬛" },
  { id: "brd-02", nama: "Luna", kandang: "A-02", paket: "Paket Reguler", checkIn: "2026-11-11", emoji: "🐱" },
  { id: "brd-03", nama: "Ayen", kandang: "B-01", paket: "Paket Premium", checkIn: "2026-11-09", emoji: "🐈" },
  { id: "brd-04", nama: "Miku", kandang: "A-05", paket: "Paket Reguler", checkIn: "2026-11-12", emoji: "🐈‍⬛" },
];

/* --------------------------------------------------------------------------
   Tugas antar jemput (frame 20, 21 — Staff Antar Jemput)
   -------------------------------------------------------------------------- */
const OMI_ANTAR_JEMPUT = [
  {
    id: "pu-01",
    nama: "Ayen's Stay",
    pemilik: "Cinta Cahyaning · 0812-3456-7890",
    kucing: "Mochi · Persia · Betina",
    alamat: "Jl. Ketintang No. 12, Gayungan, Surabaya",
    jemput: "09.00 WIB",
    status: "Belum Di Jemput",
    tanggal: "2026-11-12",
    emoji: "🚗",
  },
  {
    id: "pu-02",
    nama: "Miku's Stay",
    pemilik: "Dewi Anggraini · 0813-2222-1111",
    kucing: "Ayen · Persia · Jantan",
    alamat: "Jl. Dharmahusada No. 8, Surabaya",
    jemput: "13.00 WIB",
    status: "Sudah Di Jemput",
    tanggal: "2026-11-12",
    emoji: "🚙",
  },
];

/* --------------------------------------------------------------------------
   Riwayat untuk halaman Pemilik Pet Hotel (frame 27–29)
   Kolom mengikuti tabel Figma. Data contoh, bukan data sungguhan.
   -------------------------------------------------------------------------- */
const OMI_RIWAYAT_RESERVASI = [
  { id: "RSV-0044", pemilik: "Fajar Nugroho", kucing: "Miku", paket: "Premium", tanggal: "15–18 Nov 2026", checkIn: "2026-11-15", status: "Disetujui" },
  { id: "RSV-0043", pemilik: "Maya Lestari", kucing: "Ayen", paket: "Reguler", tanggal: "14–16 Nov 2026", checkIn: "2026-11-14", status: "Menunggu Pembayaran" },
  { id: "RSV-0042", pemilik: "Cinta Cahyaning", kucing: "Mochi", paket: "Premium", tanggal: "10–12 Nov 2026", checkIn: "2026-11-10", status: "Berlangsung" },
  { id: "RSV-0041", pemilik: "Dewi Anggraini", kucing: "Luna", paket: "Reguler", tanggal: "8–10 Nov 2026", checkIn: "2026-11-08", status: "Selesai" },
  { id: "RSV-0040", pemilik: "Rizky Pratama", kucing: "Simba", paket: "Premium", tanggal: "5–9 Nov 2026", checkIn: "2026-11-05", status: "Selesai" },
  { id: "RSV-0039", pemilik: "Sari Wulandari", kucing: "Oreo", paket: "Reguler", tanggal: "1–3 Nov 2026", checkIn: "2026-11-01", status: "Selesai" },
];

const OMI_RIWAYAT_PEMBAYARAN = [
  { id: "PAY-0042", pemilik: "Cinta Cahyaning", nominal: 160000, metode: "QRIS", tanggal: "10 Nov 2026", status: "Menunggu" },
  { id: "PAY-0041", pemilik: "Dewi Anggraini", nominal: 140000, metode: "QRIS", tanggal: "8 Nov 2026", status: "Lunas" },
  { id: "PAY-0040", pemilik: "Rizky Pratama", nominal: 480000, metode: "QRIS", tanggal: "5 Nov 2026", status: "Lunas" },
  { id: "PAY-0039", pemilik: "Sari Wulandari", nominal: 140000, metode: "QRIS", tanggal: "1 Nov 2026", status: "Lunas" },
  { id: "PAY-0038", pemilik: "Andi Saputra", nominal: 210000, metode: "QRIS", tanggal: "28 Okt 2026", status: "Lunas" },
  { id: "PAY-0037", pemilik: "Lina Marlina", nominal: 140000, metode: "QRIS", tanggal: "25 Okt 2026", status: "Lunas" },
];

const OMI_RIWAYAT_MEDIS = [
  { kucing: "Mochi", pemilik: "Cinta Cahyaning", tanggal: "10 Nov 2026", pemeriksaan: "Pemeriksaan awal", kondisi: "Sehat", catatan: "Alergi seafood" },
  { kucing: "Luna", pemilik: "Dewi Anggraini", tanggal: "8 Nov 2026", pemeriksaan: "Cek bulu & kulit", kondisi: "Sehat", catatan: "Perlu grooming" },
  { kucing: "Simba", pemilik: "Rizky Pratama", tanggal: "5 Nov 2026", pemeriksaan: "Cek pencernaan", kondisi: "Perhatian", catatan: "Nafsu makan turun" },
  { kucing: "Oreo", pemilik: "Sari Wulandari", tanggal: "1 Nov 2026", pemeriksaan: "Pemeriksaan awal", kondisi: "Sehat", catatan: "-" },
  { kucing: "Ayen", pemilik: "Maya Lestari", tanggal: "30 Okt 2026", pemeriksaan: "Vaksinasi", kondisi: "Sehat", catatan: "Vaksin ke-2" },
  { kucing: "Miku", pemilik: "Fajar Nugroho", tanggal: "27 Okt 2026", pemeriksaan: "Cek mata", kondisi: "Perhatian", catatan: "Mata berair" },
];

/* --------------------------------------------------------------------------
   Riwayat layanan staff (frame 34)
   -------------------------------------------------------------------------- */
const OMI_RIWAYAT_LAYANAN = [
  { tanggal: "12 Nov 2026", kucing: "Mochi", layanan: "Daily Report", petugas: "Rina Wulandari", status: "Terkirim" },
  { tanggal: "12 Nov 2026", kucing: "Luna", layanan: "Check Out", petugas: "Rina Wulandari", status: "Selesai" },
  { tanggal: "11 Nov 2026", kucing: "Mochi", layanan: "Grooming Ringan", petugas: "Dimas Prakoso", status: "Selesai" },
  { tanggal: "11 Nov 2026", kucing: "Simba", layanan: "Daily Report", petugas: "Rina Wulandari", status: "Terkirim" },
  { tanggal: "10 Nov 2026", kucing: "Mochi", layanan: "Check In", petugas: "Rina Wulandari", status: "Selesai" },
  { tanggal: "10 Nov 2026", kucing: "Luna", layanan: "Daily Report", petugas: "Dimas Prakoso", status: "Draft" },
  { tanggal: "9 Nov 2026", kucing: "Simba", layanan: "Check Out", petugas: "Rina Wulandari", status: "Selesai" },
];

/* --------------------------------------------------------------------------
   Slot ketersediaan kandang (frame 30)
   -------------------------------------------------------------------------- */
const OMI_KANDANG = [
  { kode: "A-01", status: "Tersedia" }, { kode: "A-02", status: "Terisi" },
  { kode: "A-03", status: "Tersedia" }, { kode: "A-04", status: "Terisi" },
  { kode: "A-05", status: "Maintenance" }, { kode: "A-06", status: "Tersedia" },
  { kode: "A-07", status: "Terisi" }, { kode: "A-08", status: "Tersedia" },
  { kode: "B-01", status: "Terisi" }, { kode: "B-02", status: "Terisi" },
  { kode: "B-03", status: "Tersedia" }, { kode: "B-04", status: "Tersedia" },
  { kode: "B-05", status: "Tersedia" }, { kode: "B-06", status: "Terisi" },
  { kode: "B-07", status: "Tersedia" }, { kode: "B-08", status: "Maintenance" },
];

/* --------------------------------------------------------------------------
   Helper baca/tulis state prototipe
   -------------------------------------------------------------------------- */
const OMI_DEFAULT_STATE = {
  users: OMI_USERS,
  kucing: OMI_KUCING,
  paket: OMI_PAKET,
  reservasi: OMI_RESERVASI,
  pembayaran: OMI_PEMBAYARAN,
  penitipan: OMI_PENITIPAN,
  antarJemput: OMI_ANTAR_JEMPUT,
  riwayatReservasi: OMI_RIWAYAT_RESERVASI,
  riwayatPembayaran: OMI_RIWAYAT_PEMBAYARAN,
  riwayatMedis: OMI_RIWAYAT_MEDIS,
  riwayatLayanan: OMI_RIWAYAT_LAYANAN,
  kandang: OMI_KANDANG,
  laporan: [],
  sesi: null,          // { userId, role, nama, inisial }
  draftReservasi: null, // data sementara selama 3 langkah reservasi
};