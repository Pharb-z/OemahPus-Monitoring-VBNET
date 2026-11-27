/* ==========================================================================
   OMI — Logika Modul Pembayaran
   Halaman:
   - pembayaran.html          rincian + pilih metode (frame 11)
   - pembayaran-qris.html     simulasi QRIS + hitung mundur (frame 12)
   - pembayaran-sukses.html   bukti pembayaran (frame 13)

   PENTING: seluruh proses pembayaran di sini adalah SIMULASI.
   Tidak ada payment gateway, tidak ada transaksi nyata.
   ========================================================================== */

/* --------------------------------------------------------------------------
   LANGKAH 1 — Halaman rincian pembayaran (frame 11)
   -------------------------------------------------------------------------- */
function omiInitPembayaran() {
  const host = document.getElementById("rincian-biaya");
  if (!host) return;

  const sesi = omiGetSession();
  const idReservasi = omiParam("id");
  const state = omiState();

  const reservasi = idReservasi
    ? state.reservasi.find((r) => r.id === idReservasi)
    : state.reservasi.find((r) => r.pemilikId === sesi.userId);

  if (!reservasi) {
    window.location.replace("riwayat.html");
    return;
  }

  const kucing = omiCariKucing(state, reservasi.kucingId);
  const biaya = omiHitungBiaya(state, reservasi);
  const pemilik = omiCariUser(state, reservasi.pemilikId);

  // --- Info pemilik & kucing ---
  const infoHost = document.getElementById("info-pemilik");
  if (infoHost) {
    infoHost.innerHTML = `
      <div class="omi-detail-grid">
        <div><dt>Pemilik Kucing</dt><dd>${omiEsc(pemilik ? pemilik.nama : "-")}</dd></div>
        <div><dt>Nama Kucing</dt><dd>${omiEsc(kucing ? kucing.nama : "-")}</dd></div>
        <div><dt>Usia Kucing</dt><dd>${kucing ? kucing.usia + " tahun" : "-"}</dd></div>
        <div><dt>Alamat</dt><dd>${omiEsc(pemilik && pemilik.alamat ? pemilik.alamat : "-")}</dd></div>
        <div><dt>Check In</dt><dd>${omiTanggalSingkat(reservasi.checkIn)}</dd></div>
        <div><dt>Check Out</dt><dd>${omiTanggalSingkat(reservasi.checkOut)}</dd></div>
        <div style="grid-column:1/-1">
          <dt>Catatan Kesehatan</dt>
          <dd>${omiEsc(kucing && kucing.catatan ? kucing.catatan : "Tidak ada catatan")}</dd>
        </div>
      </div>`;
  }

  // --- Rincian biaya ---
  host.innerHTML = `
    <div class="omi-summary-row">
      <dt>Harga Paket Layanan</dt>
      <dd>${omiRupiah(biaya.hargaPaket)} / malam</dd>
    </div>
    <div class="omi-summary-row">
      <dt>Jumlah Malam</dt>
      <dd>${biaya.malam} malam</dd>
    </div>
    <div class="omi-summary-row">
      <dt>Biaya Layanan Tambahan</dt>
      <dd>${omiRupiah(biaya.biayaTambahan)}</dd>
    </div>
    <div class="omi-summary-row omi-summary-total">
      <dt>Total</dt>
      <dd>${omiRupiah(biaya.total)}</dd>
    </div>`;

  // --- Ringkasan di sidebar ---
  const ringkas = document.getElementById("ringkas-biaya");
  if (ringkas) {
    ringkas.innerHTML = `
      <div><dt>Paket</dt><dd>${omiEsc(biaya.paket ? biaya.paket.nama : "-")}</dd></div>
      <div><dt>Durasi</dt><dd>${biaya.malam} malam</dd></div>
      <div><dt>Total Tagihan</dt><dd>${omiRupiah(biaya.total)}</dd></div>`;
  }

  // --- Status ---
  const statusBayar = document.getElementById("status-pembayaran");
  if (statusBayar) {
    const sudah = state.pembayaran.find(
      (p) => p.reservasiId === reservasi.id && p.status === "Pembayaran Sukses"
    );
    const label = sudah ? "Pembayaran Sukses" : "Menunggu Pembayaran";
    statusBayar.textContent = label;
    statusBayar.className = `omi-badge omi-badge--${omiStatusBadge(label)}`;
  }

  const statusRes = document.getElementById("status-reservasi");
  if (statusRes) {
    statusRes.textContent = reservasi.status;
    statusRes.className = `omi-badge omi-badge--${omiStatusBadge(reservasi.status)}`;
  }

  // --- Tombol lanjut ---
  const tombol = document.getElementById("btn-bayar");
  if (tombol) {
    tombol.addEventListener("click", () => {
      const metodeEl = document.querySelector("input[name='metode']:checked");
      const metode = metodeEl ? metodeEl.value : "qris";

      if (metode === "tunai") {
        // Tunai tidak butuh halaman QR — tampilkan konfirmasi simulasi.
        const yakin = window.confirm(
          "Metode tunai dipilih. Pembayaran dilakukan langsung di lokasi saat check-in.\n\n" +
          "Simulasikan pembayaran sebagai berhasil sekarang?"
        );
        if (!yakin) return;
        omiSimpanPembayaran(state, reservasi, biaya, "Tunai");
        window.location.href = `pembayaran-sukses.html?id=${encodeURIComponent(reservasi.id)}`;
        return;
      }

      window.location.href = `pembayaran-qris.html?id=${encodeURIComponent(reservasi.id)}`;
    });
  }
}

/* --------------------------------------------------------------------------
   LANGKAH 2 — Halaman QRIS (frame 12)
   -------------------------------------------------------------------------- */
function omiInitQris() {
  const frame = document.getElementById("qris-frame");
  if (!frame) return;

  const idReservasi = omiParam("id");
  const state = omiState();
  const reservasi = state.reservasi.find((r) => r.id === idReservasi);

  if (!reservasi) {
    window.location.replace("riwayat.html");
    return;
  }

  const biaya = omiHitungBiaya(state, reservasi);

  // Nominal
  const nominal = document.getElementById("qris-nominal");
  if (nominal) nominal.textContent = omiRupiah(biaya.total);

  const namaEl = document.getElementById("qris-nama");
  if (namaEl) namaEl.textContent = reservasi.nama;

  // Gambar pola QR dekoratif (BUKAN QR yang bisa dipindai)
  frame.innerHTML = omiBuatPolaQR();

  // --- Hitung mundur 23:55 (sesuai desain) ---
  let sisaDetik = 23 * 60 + 55;
  const timerEl = document.getElementById("qris-timer");

  function renderTimer() {
    const menit = String(Math.floor(sisaDetik / 60)).padStart(2, "0");
    const detik = String(sisaDetik % 60).padStart(2, "0");
    if (timerEl) timerEl.textContent = `${menit}:${detik}`;
  }

  renderTimer();

  const interval = setInterval(() => {
    sisaDetik -= 1;
    if (sisaDetik <= 0) {
      clearInterval(interval);
      if (timerEl) {
        timerEl.textContent = "00:00";
        timerEl.classList.remove("omi-timer--warning");
      }
      const kotak = document.getElementById("qris-kedaluwarsa");
      if (kotak) kotak.classList.remove("omi-hidden");
      return;
    }
    renderTimer();
  }, 1000);

  // --- Tombol unduh QR (hanya menyimpan pola sebagai PNG) ---
  const btnUnduh = document.getElementById("btn-unduh-qr");
  if (btnUnduh) {
    btnUnduh.addEventListener("click", () => {
      alert(
        "Pada prototipe ini kode QR hanya ilustrasi, sehingga tidak ada berkas\n" +
        "QR sungguhan yang bisa diunduh."
      );
    });
  }

  // --- Simulasi pembayaran berhasil ---
  const btnSimulasi = document.getElementById("btn-simulasi-bayar");
  if (btnSimulasi) {
    btnSimulasi.addEventListener("click", () => {
      clearInterval(interval);
      omiSimpanPembayaran(state, reservasi, biaya, "QRIS");
      window.location.href = `pembayaran-sukses.html?id=${encodeURIComponent(reservasi.id)}`;
    });
  }
}

/**
 * Pola kotak-kotak mirip QR. Deterministik supaya tampilannya stabil.
 * Ini murni hiasan, tidak berisi data apa pun.
 */
function omiBuatPolaQR() {
  const ukuran = 9;
  let html = '<div class="omi-qr-pattern" aria-hidden="true">';

  for (let baris = 0; baris < ukuran; baris++) {
    for (let kolom = 0; kolom < ukuran; kolom++) {
      const sudutKiriAtas = baris < 3 && kolom < 3;
      const sudutKananAtas = baris < 3 && kolom > ukuran - 4;
      const sudutKiriBawah = baris > ukuran - 4 && kolom < 3;

      if (sudutKiriAtas || sudutKananAtas || sudutKiriBawah) {
        html += '<span class="is-corner"></span>';
        continue;
      }

      // Pola pseudo-acak yang stabil
      const nilai = (baris * 31 + kolom * 17 + ((baris * kolom) % 7)) % 3;
      html += nilai === 0 ? '<span class="is-off"></span>' : "<span></span>";
    }
  }

  html += "</div>";
  return html;
}

/* --------------------------------------------------------------------------
   LANGKAH 3 — Halaman sukses / bukti pembayaran (frame 13)
   -------------------------------------------------------------------------- */
function omiInitSukses() {
  const host = document.getElementById("bukti");
  if (!host) return;

  const idReservasi = omiParam("id");
  const state = omiState();
  const reservasi = state.reservasi.find((r) => r.id === idReservasi);

  if (!reservasi) {
    window.location.replace("riwayat.html");
    return;
  }

  const kucing = omiCariKucing(state, reservasi.kucingId);
  const biaya = omiHitungBiaya(state, reservasi);
  const pemilik = omiCariUser(state, reservasi.pemilikId);
  const bayar = state.pembayaran.find((p) => p.reservasiId === reservasi.id);

  host.innerHTML = `
    <div class="omi-detail-grid">
      <div><dt>ID Pembayaran</dt><dd>${omiEsc(bayar ? bayar.id : "-")}</dd></div>
      <div><dt>Nama</dt><dd>${omiEsc(pemilik ? pemilik.nama : "-")}</dd></div>
      <div><dt>Nama Kucing</dt><dd>${omiEsc(kucing ? kucing.nama : "-")}</dd></div>
      <div><dt>Paket Layanan</dt><dd>${omiEsc(biaya.paket ? biaya.paket.nama : "-")}</dd></div>
      <div><dt>Check In</dt><dd>${omiTanggalSingkat(reservasi.checkIn)}</dd></div>
      <div><dt>Check Out</dt><dd>${omiTanggalSingkat(reservasi.checkOut)}</dd></div>
      <div><dt>Metode</dt><dd>${omiEsc(bayar ? bayar.metode : "-")}</dd></div>
      <div><dt>Tanggal Bayar</dt><dd>${omiTanggalSingkat(bayar ? bayar.tanggal : "-")}</dd></div>
    </div>`;

  // --- Rincian pembayaran ---
  const rincian = document.getElementById("rincian-final");
  if (rincian) {
    rincian.innerHTML = `
      <div class="omi-summary-row">
        <dt>Harga Paket Layanan</dt>
        <dd>${omiRupiah(biaya.hargaPaket)} / malam</dd>
      </div>
      <div class="omi-summary-row">
        <dt>Jumlah Malam</dt>
        <dd>${biaya.malam} malam</dd>
      </div>
      <div class="omi-summary-row">
        <dt>Biaya Layanan Tambahan</dt>
        <dd>${omiRupiah(biaya.biayaTambahan)}</dd>
      </div>
      <div class="omi-summary-row omi-summary-total">
        <dt>Total</dt>
        <dd>${omiRupiah(biaya.total)}</dd>
      </div>`;
  }

  // --- Tombol cetak bukti ---
  const btnCetak = document.getElementById("btn-cetak");
  if (btnCetak) {
    btnCetak.addEventListener("click", () => window.print());
  }
}

/* --------------------------------------------------------------------------
   Helper: catat pembayaran simulasi & perbarui status reservasi
   -------------------------------------------------------------------------- */
function omiSimpanPembayaran(state, reservasi, biaya, metode) {
  const sekarang = omiToISO(new Date());

  omiUpdate((s) => {
    // Hindari duplikat kalau tombol ditekan dua kali
    const sudahAda = s.pembayaran.find((p) => p.reservasiId === reservasi.id);
    if (sudahAda) {
      sudahAda.status = "Pembayaran Sukses";
      sudahAda.metode = metode;
      sudahAda.tanggal = sekarang;
      sudahAda.total = biaya.total;
    } else {
      s.pembayaran.unshift({
        id: omiBuatIdPembayaran(sekarang),
        reservasiId: reservasi.id,
        nama: reservasi.nama,
        total: biaya.total,
        tanggal: sekarang,
        status: "Pembayaran Sukses",
        metode,
      });
    }

    // Reservasi ikut diperbarui statusnya
    const res = s.reservasi.find((r) => r.id === reservasi.id);
    if (res) res.status = "Dikonfirmasi";
  });
}

/** Format ID pembayaran: PAY-YYYYMMDD-NNNN (meniru desain Figma). */
function omiBuatIdPembayaran(iso) {
  const angka = iso.replace(/-/g, "");
  const urut = String(Math.floor(Math.random() * 9000) + 1000);
  return `PAY-${angka}-${urut}`;
}

/* --------------------------------------------------------------------------
   Auto-init
   -------------------------------------------------------------------------- */
document.addEventListener("DOMContentLoaded", () => {
  if (document.getElementById("rincian-biaya")) {
    if (!omiBoot("customer", "Riwayat")) return;
    omiInitPembayaran();
    return;
  }

  if (document.getElementById("qris-frame")) {
    if (!omiBoot("customer", "Riwayat")) return;
    omiInitQris();
    return;
  }

  if (document.getElementById("bukti")) {
    if (!omiBoot("customer", "Riwayat")) return;
    omiInitSukses();
  }
});
