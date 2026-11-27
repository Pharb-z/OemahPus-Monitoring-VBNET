/* ==========================================================================
   OMI — Logika Halaman Beranda
   ========================================================================== */

const OMI_LANGKAH = [
  {
    nomor: 1,
    judul: "Pilih Paket",
    teks: "Tentukan paket sesuai kebutuhan kucingmu.",
  },
  {
    nomor: 2,
    judul: "Isi Data Kucing",
    teks: "Lengkapi profil & catatan kesehatan.",
  },
  {
    nomor: 3,
    judul: "Bayar via QRIS",
    teks: "Pembayaran cepat dan aman.",
  },
  {
    nomor: 4,
    judul: "Pantau Real-time",
    teks: "Lihat laporan harian dari staf kami.",
  },
];

document.addEventListener("DOMContentLoaded", () => {
  const sesi = omiBoot("customer", "Home");
  if (!sesi) return;

  omiRenderLangkah();
  omiRenderPaket();
});

/* --------------------------------------------------------------------------
   Empat langkah memulai
   -------------------------------------------------------------------------- */
function omiRenderLangkah() {
  const host = document.getElementById("langkah-grid");
  if (!host) return;

  host.innerHTML = OMI_LANGKAH.map(
    (langkah) => `
      <article class="omi-step-card">
        <div class="omi-step-card-head">
          <span class="omi-step-circle">${langkah.nomor}</span>
          <h3 class="omi-step-card-title">${omiEsc(langkah.judul)}</h3>
        </div>
        <p class="omi-step-card-text">${omiEsc(langkah.teks)}</p>
      </article>
    `
  ).join("");
}

/* --------------------------------------------------------------------------
   Paket layanan di beranda
   Hanya paket berjenis "Penitipan" yang ditampilkan sebagai paket utama.
   -------------------------------------------------------------------------- */
function omiRenderPaket() {
  const host = document.getElementById("paket-grid");
  if (!host) return;

  const state = omiState();
  // Beranda hanya menampilkan 2 paket penitipan (Figma: Premium & Reguler).
  const daftar = state.paket.filter((p) => p.jenis === "Penitipan").slice(0, 2);

  host.innerHTML = daftar
    .map(
      (paket) => `
      <article class="omi-card omi-pkg-card">
        <h3 class="omi-pkg-name">${omiEsc(paket.nama)}</h3>
        <p class="omi-pkg-price">${omiRupiah(paket.harga)}</p>
        <ul class="omi-pkg-features">
          ${paket.fitur.map((f) => `<li>${omiEsc(f)}</li>`).join("")}
        </ul>
        <a class="omi-btn omi-btn--primary" href="reservasi-data.html">Lihat Detail</a>
      </article>
    `
    )
    .join("");
}
