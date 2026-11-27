/* ==========================================================================
   OMI — Logika Halaman Riwayat (frame 10, node 71:442)
   Dua bagian: kartu riwayat reservasi + tabel riwayat pembayaran.
   ========================================================================== */

document.addEventListener("DOMContentLoaded", () => {
  const sesi = omiBoot("customer", "Riwayat");
  if (!sesi) return;

  omiRenderRiwayatReservasi(sesi);
  omiRenderRiwayatPembayaran(sesi);
});

/* --------------------------------------------------------------------------
   Kartu riwayat reservasi
   -------------------------------------------------------------------------- */
function omiRenderRiwayatReservasi(sesi) {
  const host = document.getElementById("riwayat-grid");
  if (!host) return;

  const state = omiState();
  const daftar = state.reservasi.filter((r) => r.pemilikId === sesi.userId);

  if (daftar.length === 0) {
    host.innerHTML = `
      <div class="omi-empty" style="grid-column:1/-1">
        <div class="omi-empty-icon">📋</div>
        <p class="omi-fw-semibold">Belum ada reservasi</p>
        <p class="omi-text-sm omi-mt-8">Reservasi yang kamu ajukan akan tampil di sini.</p>
        <a class="omi-btn omi-btn--primary omi-mt-24" href="reservasi-data.html">Buat Reservasi</a>
      </div>`;
    return;
  }

  host.innerHTML = daftar
    .map((reservasi) => {
      const kucing = omiCariKucing(state, reservasi.kucingId);
      const paket = omiCariPaket(state, reservasi.paketId);
      const malam = omiJumlahMalam(reservasi.checkIn, reservasi.checkOut);
      const kelasBadge = omiStatusBadge(reservasi.status);

      return `
      <article class="omi-card omi-cat-card">
        <div class="omi-cat-photo">${kucing ? kucing.emoji : "🐱"}</div>
        <h3 class="omi-cat-name omi-fw-semibold">${omiEsc(reservasi.nama)}</h3>
        <p class="omi-text-sm omi-text-muted">
          ${omiTanggalSingkat(reservasi.checkIn)} — ${omiTanggalSingkat(reservasi.checkOut)} · ${malam} malam
        </p>
        <p class="omi-text-sm omi-text-muted omi-mt-8">${omiEsc(paket ? paket.nama : "-")}</p>
        <div class="omi-mt-16">
          <span class="omi-badge omi-badge--${kelasBadge}">${omiEsc(reservasi.status)}</span>
        </div>
        <div class="omi-cat-actions omi-mt-24">
          <a class="omi-btn omi-btn--soft" href="pembayaran.html?id=${encodeURIComponent(reservasi.id)}">Lihat</a>
        </div>
      </article>`;
    })
    .join("");
}

/* --------------------------------------------------------------------------
   Tabel riwayat pembayaran
   -------------------------------------------------------------------------- */
function omiRenderRiwayatPembayaran(sesi) {
  const body = document.getElementById("riwayat-bayar-body");
  if (!body) return;

  const state = omiState();
  const milikSaya = state.pembayaran.filter((p) => {
    const reservasi = state.reservasi.find((r) => r.id === p.reservasiId);
    return reservasi && reservasi.pemilikId === sesi.userId;
  });

  if (milikSaya.length === 0) {
    body.innerHTML = `
      <tr>
        <td colspan="4" class="omi-text-center omi-text-muted">Belum ada riwayat pembayaran.</td>
      </tr>`;
    return;
  }

  body.innerHTML = milikSaya
    .map((bayar) => {
      const kelasBadge = omiStatusBadge(bayar.status);
      return `
      <tr>
        <td class="omi-fw-semibold">${omiEsc(bayar.nama)}</td>
        <td>${omiRupiah(bayar.total)}</td>
        <td>${omiTanggalTabel(bayar.tanggal)}</td>
        <td><span class="omi-badge omi-badge--${kelasBadge}">${omiEsc(bayar.status)}</span></td>
      </tr>`;
    })
    .join("");
}
