/* ==========================================================================
   OMI — Logika Halaman Pet Tracking (pemilik kucing)
   Tidak ada frame Figma khusus; tampilan mengikuti gaya kartu yang ada.
   ========================================================================== */

document.addEventListener("DOMContentLoaded", () => {
  const sesi = omiBoot("customer", "Pet Tracking");
  if (!sesi) return;

  const state = omiState();
  const namaKucingSaya = state.kucing
    .filter((k) => k.pemilikId === sesi.userId)
    .map((k) => k.nama.toLowerCase());

  const penitipan = state.penitipan.filter((p) =>
    namaKucingSaya.includes(p.nama.toLowerCase())
  );

  const host = document.getElementById("tracking-grid");
  const kosong = document.getElementById("tracking-kosong");

  if (penitipan.length === 0) {
    if (host) host.classList.add("omi-hidden");
    if (kosong) kosong.classList.remove("omi-hidden");
  } else {
    if (kosong) kosong.classList.add("omi-hidden");
    host.innerHTML = penitipan
      .map(
        (item) => `
        <article class="omi-tracking-card">
          <div class="omi-tracking-photo">${item.emoji || "🐱"}</div>
          <div class="omi-tracking-body">
            <p class="omi-tracking-nama">${omiEsc(item.nama)}</p>
            <p class="omi-tracking-meta">Kandang ${omiEsc(item.kandang)}</p>
            <p class="omi-tracking-meta">${omiEsc(item.paket)}</p>
            <p class="omi-tracking-meta">Check-in ${omiTanggalSingkat(item.checkIn)}</p>
            <span class="omi-badge omi-badge--success omi-mt-8">Sedang Menginap</span>
          </div>
        </article>`
      )
      .join("");
  }

  const body = document.getElementById("tracking-laporan-body");
  if (!body) return;

  const laporan = (state.laporan || []).filter((l) =>
    namaKucingSaya.includes(String(l.namaKucing).toLowerCase())
  );

  if (laporan.length === 0) {
    body.innerHTML = `
      <tr>
        <td colspan="6" class="omi-text-center omi-text-muted">
          Belum ada laporan harian untuk kucingmu.
        </td>
      </tr>`;
    return;
  }

  body.innerHTML = laporan
    .slice()
    .reverse()
    .map(
      (l) => `
      <tr>
        <td>${omiTanggalTabel(l.tanggal)}</td>
        <td class="omi-fw-semibold">${omiEsc(l.namaKucing)}</td>
        <td>${omiEsc(l.kandang)}</td>
        <td>${omiEsc(l.makan)}</td>
        <td>${omiEsc(l.kondisi || "-")}</td>
        <td>${omiEsc(l.catatan || "-")}</td>
      </tr>`
    )
    .join("");
});