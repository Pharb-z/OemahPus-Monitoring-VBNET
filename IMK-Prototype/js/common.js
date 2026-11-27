/* ==========================================================================
   OMI — Helper Bersama
   Berisi: penyimpanan state, format angka/tanggal, navbar, dan proteksi halaman.

   Prototipe ini memakai localStorage HANYA untuk kenyamanan demo antar-halaman.
   localStorage bukan database dan bukan mekanisme keamanan.
   ========================================================================== */

/* --------------------------------------------------------------------------
   1. STATE
   -------------------------------------------------------------------------- */
function omiLoadState() {
  try {
    const raw = localStorage.getItem(OMI_STORE_KEY);
    if (!raw) return structuredClone(OMI_DEFAULT_STATE);
    const parsed = JSON.parse(raw);
    // Gabungkan dengan default supaya field baru tetap ada setelah update.
    return { ...structuredClone(OMI_DEFAULT_STATE), ...parsed };
  } catch (err) {
    console.warn("Gagal membaca state, memakai data awal.", err);
    return structuredClone(OMI_DEFAULT_STATE);
  }
}

function omiSaveState(state) {
  try {
    localStorage.setItem(OMI_STORE_KEY, JSON.stringify(state));
  } catch (err) {
    console.warn("Gagal menyimpan state.", err);
  }
}

function omiResetState() {
  localStorage.removeItem(OMI_STORE_KEY);
}

/** Ambil state terbaru (selalu dibaca ulang agar antar-halaman sinkron). */
function omiState() {
  return omiLoadState();
}

/** Simpan perubahan lewat callback, lalu kembalikan state barunya. */
function omiUpdate(mutator) {
  const state = omiLoadState();
  mutator(state);
  omiSaveState(state);
  return state;
}

/* --------------------------------------------------------------------------
   2. SESI PENGGUNA
   -------------------------------------------------------------------------- */
function omiGetSession() {
  return omiLoadState().sesi;
}

function omiSetSession(user) {
  omiUpdate((s) => {
    s.sesi = {
      userId: user.id,
      role: user.role,
      nama: user.nama,
      email: user.email,
      inisial: user.inisial,
    };
  });
}

function omiLogout() {
  omiUpdate((s) => {
    s.sesi = null;
    s.draftReservasi = null;
  });
  window.location.href = "index.html";
}

/**
 * Pastikan halaman hanya bisa dibuka oleh peran tertentu.
 * Kalau belum login atau peran tidak cocok, arahkan ke halaman yang benar.
 */
function omiRequireRole(allowedRoles) {
  const sesi = omiGetSession();
  if (!sesi) {
    window.location.replace("index.html");
    return null;
  }
  const roles = Array.isArray(allowedRoles) ? allowedRoles : [allowedRoles];
  if (!roles.includes(sesi.role)) {
    const fallback = {
      customer: "home.html",
      admin: "admin-kelola-layanan.html",
      staff: "staff-daily-report.html",
      kurir: "staff-antar-jemput.html",
    };
    window.location.replace(fallback[sesi.role] || "index.html");
    return null;
  }
  return sesi;
}

/* --------------------------------------------------------------------------
   3. FORMAT
   -------------------------------------------------------------------------- */
const OMI_BULAN = [
  "Jan", "Feb", "Mar", "Apr", "Mei", "Jun",
  "Jul", "Agu", "Sep", "Okt", "Nov", "Des",
];

const OMI_BULAN_PANJANG = [
  "Januari", "Februari", "Maret", "April", "Mei", "Juni",
  "Juli", "Agustus", "September", "Oktober", "November", "Desember",
];

const OMI_HARI = ["Minggu", "Senin", "Selasa", "Rabu", "Kamis", "Jumat", "Sabtu"];

/** 70000 → "IDR. 70.000" */
function omiRupiah(angka) {
  return "IDR. " + Number(angka || 0).toLocaleString("id-ID");
}

/** 70000 → "70.000" (tanpa prefix) */
function omiAngka(angka) {
  return Number(angka || 0).toLocaleString("id-ID");
}

/** "2026-11-10" → "10 Nov 2026" */
function omiTanggalSingkat(iso) {
  const d = omiParseISO(iso);
  if (!d) return "-";
  return `${d.getDate()} ${OMI_BULAN[d.getMonth()]} ${d.getFullYear()}`;
}

/** "2026-11-12" → "Kamis, 12 November 2026" */
function omiTanggalPanjang(iso) {
  const d = omiParseISO(iso);
  if (!d) return "-";
  return `${OMI_HARI[d.getDay()]}, ${d.getDate()} ${OMI_BULAN_PANJANG[d.getMonth()]} ${d.getFullYear()}`;
}

/** "2026-11-05" → "05 - 11 - 2026" (format tabel riwayat di Figma) */
function omiTanggalTabel(iso) {
  const d = omiParseISO(iso);
  if (!d) return "-";
  const dd = String(d.getDate()).padStart(2, "0");
  const mm = String(d.getMonth() + 1).padStart(2, "0");
  return `${dd} - ${mm} - ${d.getFullYear()}`;
}

/** Parse "YYYY-MM-DD" sebagai tengah malam lokal (hindari geser timezone). */
function omiParseISO(iso) {
  if (!iso) return null;
  const [y, m, d] = String(iso).split("-").map(Number);
  if (!y || !m || !d) return null;
  return new Date(y, m - 1, d);
}

/** Date → "YYYY-MM-DD" */
function omiToISO(date) {
  if (!date) return "";
  const y = date.getFullYear();
  const m = String(date.getMonth() + 1).padStart(2, "0");
  const d = String(date.getDate()).padStart(2, "0");
  return `${y}-${m}-${d}`;
}

/** Jumlah malam antara dua tanggal ISO (check-out eksklusif). */
function omiJumlahMalam(checkIn, checkOut) {
  const a = omiParseISO(checkIn);
  const b = omiParseISO(checkOut);
  if (!a || !b) return 0;
  const diff = Math.round((b - a) / 86400000);
  return diff > 0 ? diff : 0;
}

/** Escape HTML supaya data contoh tidak merusak markup. */
function omiEsc(str) {
  return String(str ?? "").replace(/[&<>"']/g, (c) => ({
    "&": "&amp;",
    "<": "&lt;",
    ">": "&gt;",
    '"': "&quot;",
    "'": "&#39;",
  }[c]));
}

/** Ambil parameter ?id= dari URL */
function omiParam(nama) {
  return new URLSearchParams(window.location.search).get(nama);
}

/* --------------------------------------------------------------------------
   4. NAVBAR
   Menu disusun berbeda per peran, mengikuti frame Figma:
   - customer : Home, Profil Kucing, Pet Tracking, Reservasi, Riwayat, Akun Saya
   - admin    : Kelola Layanan, Riwayat, Reservasi, Akun Saya
   - staff    : Daily Report, Check In & Out, Riwayat Layanan, Akun Saya
   - kurir    : Jadwal, Detail Pesanan, Akun Saya
   -------------------------------------------------------------------------- */
const OMI_MENU = {
  customer: [
    { label: "Home", href: "home.html" },
    { label: "Profil Kucing", href: "profil-kucing.html" },
    { label: "Pet Tracking", href: "pet-tracking.html" },
    { label: "Reservasi", href: "reservasi-data.html" },
    { label: "Riwayat", href: "riwayat.html" },
    { label: "Akun Saya", href: "akun-saya.html" },
  ],
  admin: [
    { label: "Kelola Layanan", href: "admin-kelola-layanan.html" },
    { label: "Riwayat", href: "admin-riwayat-reservasi.html" },
    { label: "Reservasi", href: "admin-reservasi.html" },
    { label: "Akun Saya", href: "akun-saya.html" },
  ],
  staff: [
    { label: "Daily Report", href: "staff-daily-report.html" },
    { label: "Check In & Out", href: "staff-checkin-out.html" },
    { label: "Riwayat Layanan", href: "staff-riwayat-layanan.html" },
    { label: "Akun Saya", href: "akun-saya.html" },
  ],
  kurir: [
    { label: "Jadwal", href: "staff-antar-jemput.html" },
    { label: "Detail Pesanan", href: "staff-detail-antar-jemput.html" },
    { label: "Akun Saya", href: "akun-saya.html" },
  ],
};

/** Label peran yang tampil di UI (mengikuti teks Figma). */
const OMI_LABEL_PERAN = {
  customer: "Pemilik Kucing",
  admin: "Pemilik Pet Hotel",
  staff: "Staff Operasional",
  kurir: "Staff Antar Jemput",
};

function omiLabelPeran(role) {
  return OMI_LABEL_PERAN[role] || role;
}

/** Halaman awal per peran. */
const OMI_BERANDA = {
  customer: "home.html",
  admin: "admin-kelola-layanan.html",
  staff: "staff-daily-report.html",
  kurir: "staff-antar-jemput.html",
};

/**
 * Render navbar ke dalam <header id="omi-navbar">.
 * @param {string} aktif - label menu yang sedang aktif
 * @param {object} sesi  - hasil omiRequireRole()
 */
function omiRenderNavbar(aktif, sesi) {
  const host = document.getElementById("omi-navbar");
  if (!host) return;

  const menu = OMI_MENU[sesi.role] || [];
  const links = menu
    .map((item) => {
      const kelas = item.label === aktif ? "omi-navlink is-active" : "omi-navlink";
      return `<a class="${kelas}" href="${item.href}">${omiEsc(item.label)}</a>`;
    })
    .join("");

  // Tag peran di navbar (frame baru). Pemilik Kucing tidak memakai tag.
  const tag = sesi.role === "customer"
    ? ""
    : `<span class="omi-navtag">${omiEsc(omiLabelPeran(sesi.role))}</span>`;

  host.className = "omi-navbar";
  host.innerHTML = `
    <div class="omi-navbar-inner">
      <a class="omi-brand" href="${OMI_BERANDA[sesi.role] || "home.html"}">
        <span class="omi-brand-mark" aria-hidden="true">🐾</span>
        <span class="omi-brand-word">OMI</span>
      </a>
      ${tag}
      <nav class="omi-navmenu" aria-label="Navigasi utama">${links}</nav>
      <div class="omi-user-chip" title="${omiEsc(sesi.email)}">
        <span class="omi-avatar">${omiEsc(sesi.inisial)}</span>
        <span class="omi-user-chip-nama">${omiEsc(sesi.nama.split(" ")[0])}</span>
      </div>
      <button type="button" class="omi-btn omi-btn--ghost omi-btn--sm" id="omi-logout">Keluar</button>
    </div>
  `;

  const btn = document.getElementById("omi-logout");
  if (btn) btn.addEventListener("click", omiLogout);
}

/**
 * Pasang navbar + proteksi peran dalam satu panggilan.
 * @returns {object|null} sesi, atau null jika dialihkan.
 */
function omiBoot(peranDiizinkan, menuAktif) {
  const sesi = omiRequireRole(peranDiizinkan);
  if (!sesi) return null;
  omiRenderNavbar(menuAktif, sesi);
  return sesi;
}

/* --------------------------------------------------------------------------
   5. LOOKUP
   -------------------------------------------------------------------------- */
function omiCariPaket(state, id) {
  return state.paket.find((p) => p.id === id) || null;
}

function omiCariKucing(state, id) {
  return state.kucing.find((k) => k.id === id) || null;
}

function omiCariUser(state, id) {
  return state.users.find((u) => u.id === id) || null;
}

/** Hitung rincian biaya satu reservasi. */
function omiHitungBiaya(state, reservasi) {
  const paket = omiCariPaket(state, reservasi.paketId);
  const hargaPaket = paket ? paket.harga : 0;
  const malam = omiJumlahMalam(reservasi.checkIn, reservasi.checkOut);
  const biayaPaket = hargaPaket * malam;
  const biayaTambahan = (reservasi.tambahan || []).reduce((t, x) => t + x.harga, 0);
  return {
    paket,
    hargaPaket,
    malam,
    biayaPaket,
    biayaTambahan,
    total: biayaPaket + biayaTambahan,
  };
}

/**
 * Peta status → kelas badge.
 * Label mengikuti teks yang ada di desain Figma.
 */
function omiStatusBadge(status) {
  const map = {
    "Selesai": "success",
    "Disetujui": "success",
    "Lunas": "success",
    "Pembayaran Sukses": "success",
    "Sudah Di Jemput": "success",
    "Sehat": "success",
    "Tersedia": "success",
    "Menunggu": "warning",
    "Menunggu Pembayaran": "warning",
    "Perhatian": "warning",
    "Maintenance": "warning",
    "Berlangsung": "info",
    "Terisi": "info",
    "Terkirim": "info",
    "Belum Di Jemput": "info",
    "Menunggu Konfirmasi": "info",
    "Dibatalkan": "danger",
    "Draft": "neutral",
  };
  return map[status] || "neutral";
}

/* --------------------------------------------------------------------------
   6. PESAN ERROR / SUKSES
   Dipakai di semua halaman, jadi ditaruh di sini (bukan di auth.js).
   -------------------------------------------------------------------------- */
function omiTampilkanError(box, pesan) {
  if (!box) {
    alert(pesan);
    return;
  }
  box.textContent = pesan;
  box.classList.remove("omi-hidden");
}

function omiSembunyikanError(box) {
  if (!box) return;
  box.textContent = "";
  box.classList.add("omi-hidden");
}
