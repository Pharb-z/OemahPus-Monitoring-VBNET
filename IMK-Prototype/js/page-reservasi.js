/* ==========================================================================
   OMI — Logika Alur Reservasi 2 Langkah
   Halaman:
   - reservasi-data.html        langkah 1 (data pemesan + pilih kucing + pilih paket)
   - reservasi-konfirmasi.html  langkah 2 (kalender + rincian + ajukan)

   Draft disimpan di state.draftReservasi agar bisa dibawa antar-halaman.
   ========================================================================== */

/* --------------------------------------------------------------------------
   Helper stepper
   -------------------------------------------------------------------------- */
function omiRenderStepper(aktif) {
  const host = document.getElementById("omi-stepper");
  if (!host) return;

  const langkah = ["Data & Paket", "Konfirmasi"];
  host.className = "omi-steps";
  host.innerHTML = langkah
    .map((label, i) => {
      const nomor = i + 1;
      let kelas = "omi-step";
      if (nomor === aktif) kelas += " is-active";
      else if (nomor < aktif) kelas += " is-done";
      const tanda = nomor < aktif ? "✓" : nomor;
      return `
        <div class="${kelas}">
          <span class="omi-step-num">${tanda}</span>
          <span>${omiEsc(label)}</span>
        </div>
      `;
    })
    .join("");
}

/* --------------------------------------------------------------------------
   LANGKAH 1 — Data pemesan, pilih kucing & paket (frame 08)
   -------------------------------------------------------------------------- */
function omiInitReservasiData() {
  const form = document.getElementById("form-reservasi-data");
  if (!form) return;

  const sesi = omiGetSession();
  const state = omiState();
  const draft = state.draftReservasi;

  // Isi otomatis dari profil pemilik
  const user = omiCariUser(state, sesi.userId);
  if (user) {
    form.nama.value = user.nama || "";
    form.telepon.value = user.telepon || "";
    form.alamat.value = user.alamat || "";
  }
  if (draft && draft.catatan) form.catatan.value = draft.catatan;

  // Render kartu pilih kucing
  const host = document.getElementById("pilih-kucing");
  const milikSaya = state.kucing.filter((k) => k.pemilikId === sesi.userId);

  if (milikSaya.length === 0) {
    host.innerHTML = `
      <div class="omi-empty" style="grid-column:1/-1">
        <div class="omi-empty-icon">🐾</div>
        <p class="omi-fw-semibold">Belum ada kucing terdaftar</p>
        <p class="omi-text-sm omi-mt-8">Tambahkan profil kucing dulu sebelum membuat reservasi.</p>
        <a class="omi-btn omi-btn--primary omi-mt-24" href="tambah-kucing.html">Tambah Kucing</a>
      </div>`;
  } else {
    host.innerHTML = milikSaya
      .map((kucing) => {
        const terpilih = draft && draft.kucingId === kucing.id ? "checked" : "";
        return `
        <label class="omi-pick">
          <input type="radio" name="kucingId" value="${omiEsc(kucing.id)}" ${terpilih}>
          <div class="omi-pick-body">
            <span class="omi-pick-check">✓</span>
            <div class="omi-pick-photo">${kucing.emoji || "🐱"}</div>
            <p class="omi-pick-name">${omiEsc(kucing.nama)} · ${kucing.usia} tahun</p>
            <p class="omi-pick-meta">${omiEsc(kucing.ras)} · ${omiEsc(kucing.jenisKelamin)}</p>
          </div>
        </label>`;
      })
      .join("");
  }

  // Render kartu pilih paket layanan (jenis Penitipan)
  const hostPaket = document.getElementById("pilih-paket");
  if (hostPaket) {
    const daftar = state.paket.filter((p) => p.jenis === "Penitipan");
    hostPaket.innerHTML = daftar
      .map((paket) => {
        const terpilih = draft && draft.paketId === paket.id ? "checked" : "";
        return `
        <label class="omi-pkg-pick">
          <input type="radio" name="paketId" value="${omiEsc(paket.id)}" ${terpilih}>
          <div class="omi-card omi-pkg-card">
            <span class="omi-pkg-badge">✓ Dipilih</span>
            <h3 class="omi-pkg-name">${omiEsc(paket.nama)}</h3>
            <p class="omi-pkg-price">${omiRupiah(paket.harga)}<span class="omi-text-sm omi-text-muted"> /${omiEsc(paket.satuan)}</span></p>
            <ul class="omi-pkg-features">
              ${paket.fitur.map((f) => `<li>${omiEsc(f)}</li>`).join("")}
            </ul>
          </div>
        </label>`;
      })
      .join("");
  }

  const errorBox = document.getElementById("form-error");

  // Add-on opsional: layanan antar jemput (checkbox, bukan paket eksklusif)
  const addon = form.querySelector("#antar-jemput");
  const paketAntarJemput = state.paket.find((p) => p.jenis === "Antar Jemput");
  const tambahanLama = (draft && draft.tambahan) || [];
  if (addon && paketAntarJemput) {
    const hargaEl = document.getElementById("antar-jemput-harga");
    if (hargaEl) hargaEl.textContent = omiRupiah(paketAntarJemput.harga);
    addon.checked = tambahanLama.some((t) => t.nama === paketAntarJemput.nama);
  }

  form.addEventListener("submit", (event) => {
    event.preventDefault();
    omiSembunyikanError(errorBox);

    const nama = form.nama.value.trim();
    const telepon = form.telepon.value.trim();
    const alamat = form.alamat.value.trim();
    const kucingId = form.kucingId ? form.kucingId.value : "";
    const paketId = form.paketId ? form.paketId.value : "";
    const catatan = form.catatan.value.trim();
    const tambahan = [];
    if (addon && addon.checked && paketAntarJemput) {
      tambahan.push({ nama: paketAntarJemput.nama, harga: paketAntarJemput.harga });
    }

    if (!nama) {
      omiTampilkanError(errorBox, "Nama pemesan wajib diisi.");
      return;
    }

    if (!telepon) {
      omiTampilkanError(errorBox, "Nomor HP wajib diisi.");
      return;
    }

    if (!alamat) {
      omiTampilkanError(errorBox, "Alamat wajib diisi.");
      return;
    }

    if (!kucingId) {
      omiTampilkanError(errorBox, "Pilih satu kucing yang akan dititipkan.");
      return;
    }

    if (!paketId) {
      omiTampilkanError(errorBox, "Pilih salah satu paket layanan dulu.");
      return;
    }

    omiUpdate((s) => {
      s.draftReservasi = {
        ...(s.draftReservasi || {}),
        nama,
        telepon,
        alamat,
        kucingId,
        paketId,
        tambahan,
        catatan,
      };
    });

    window.location.href = "reservasi-konfirmasi.html";
  });
}

/* --------------------------------------------------------------------------
   LANGKAH 2 — Konfirmasi (frame 09)
   Kalender untuk memilih tanggal masuk & keluar + rincian biaya.
   -------------------------------------------------------------------------- */
function omiInitReservasiKonfirmasi() {
  const host = document.getElementById("kalender");
  if (!host) return;

  const state = omiState();
  const draft = state.draftReservasi || {};

  if (!draft.kucingId || !draft.paketId) {
    window.location.replace("reservasi-data.html");
    return;
  }

  const paket = omiCariPaket(state, draft.paketId);
  const kucing = omiCariKucing(state, draft.kucingId);

  // --- Tampilkan ringkasan identitas ---
  const infoHost = document.getElementById("ringkasan-identitas");
  if (infoHost) {
    infoHost.innerHTML = `
      <div class="omi-info-list">
        <div><dt>Nama Pemesan</dt><dd>${omiEsc(draft.nama)}</dd></div>
        <div><dt>Nomor HP</dt><dd>${omiEsc(draft.telepon)}</dd></div>
        <div><dt>Kucing</dt><dd>${omiEsc(kucing ? kucing.nama : "-")}</dd></div>
        <div><dt>Paket</dt><dd>${omiEsc(paket ? paket.nama : "-")}</dd></div>
      </div>`;
  }

  // --- State kalender ---
  const hariIni = new Date();
  let bulanTampil = new Date(hariIni.getFullYear(), hariIni.getMonth(), 1);
  let checkIn = draft.checkIn || "";
  let checkOut = draft.checkOut || "";

  const errorBox = document.getElementById("form-error");

  function gambarKalender() {
    host.innerHTML = omiBuatKalenderHTML(bulanTampil, checkIn, checkOut);
    pasangEventKalender();
  }

  function pasangEventKalender() {
    host.querySelectorAll("[data-hari]").forEach((tombol) => {
      tombol.addEventListener("click", () => {
        const iso = tombol.dataset.hari;
        omiSembunyikanError(errorBox);

        // Klik pertama → check-in. Klik kedua → check-out.
        if (!checkIn || (checkIn && checkOut)) {
          checkIn = iso;
          checkOut = "";
        } else {
          if (iso === checkIn) {
            checkOut = "";
          } else if (iso < checkIn) {
            // Tanggal lebih awal dari check-in → jadikan check-in baru.
            checkIn = iso;
            checkOut = "";
          } else {
            checkOut = iso;
          }
        }

        perbaruiRingkasanBiaya();
        gambarKalender();
      });
    });

    const prev = host.querySelector("[data-nav='prev']");
    const next = host.querySelector("[data-nav='next']");
    if (prev) {
      prev.addEventListener("click", () => {
        bulanTampil = new Date(bulanTampil.getFullYear(), bulanTampil.getMonth() - 1, 1);
        gambarKalender();
      });
    }
    if (next) {
      next.addEventListener("click", () => {
        bulanTampil = new Date(bulanTampil.getFullYear(), bulanTampil.getMonth() + 1, 1);
        gambarKalender();
      });
    }
  }

  function perbaruiRingkasanBiaya() {
    const malam = omiJumlahMalam(checkIn, checkOut);
    const biayaPaket = (paket ? paket.harga : 0) * malam;
    const biayaTambahan = (draft.tambahan || []).reduce((t, x) => t + x.harga, 0);

    const setTeks = (id, teks) => {
      const el = document.getElementById(id);
      if (el) el.textContent = teks;
    };

    setTeks("biaya-paket", omiRupiah(paket ? paket.harga : 0));
    setTeks("biaya-malam", malam ? `${malam} malam` : "-");
    setTeks("biaya-tambahan", omiRupiah(biayaTambahan));
    setTeks("biaya-total", omiRupiah(biayaPaket + biayaTambahan));

    // Tampilkan tanggal di kolom input
    const inputIn = document.getElementById("tanggal-masuk");
    const inputOut = document.getElementById("tanggal-keluar");
    if (inputIn) inputIn.value = checkIn;
    if (inputOut) inputOut.value = checkOut;
  }

  // Render awal
  gambarKalender();
  perbaruiRingkasanBiaya();

  // --- Simpan & ajukan ---
  const form = document.getElementById("form-konfirmasi");
  form.addEventListener("submit", (event) => {
    event.preventDefault();
    omiSembunyikanError(errorBox);

    if (!checkIn || !checkOut) {
      omiTampilkanError(errorBox, "Pilih tanggal masuk dan tanggal keluar di kalender.");
      return;
    }

    if (omiJumlahMalam(checkIn, checkOut) < 1) {
      omiTampilkanError(errorBox, "Tanggal keluar harus setelah tanggal masuk.");
      return;
    }

    // Cek bentrok jadwal untuk kucing yang sama
    const bentrok = state.reservasi.some((r) => {
      if (r.kucingId !== draft.kucingId) return false;
      if (r.status === "Dibatalkan") return false;
      return checkIn < r.checkOut && checkOut > r.checkIn;
    });

    if (bentrok) {
      omiTampilkanError(
        errorBox,
        "Kucing ini sudah punya reservasi pada rentang tanggal tersebut. Pilih tanggal lain."
      );
      return;
    }

    const idBaru = "res-" + Date.now();

    omiUpdate((s) => {
      s.reservasi.unshift({
        id: idBaru,
        nama: `${kucing.nama}'s Stay`,
        kucingId: draft.kucingId,
        paketId: draft.paketId,
        checkIn,
        checkOut,
        tambahan: draft.tambahan || [],
        status: "Menunggu",
        pemilikId: s.sesi.userId,
      });
      // Simpan draft terakhir lalu bersihkan
      s.draftReservasi = { ...draft, checkIn, checkOut, idReservasiBaru: idBaru };
    });

    // Arahkan ke halaman pembayaran untuk reservasi baru
    window.location.href = `pembayaran.html?id=${encodeURIComponent(idBaru)}`;
  });
}

/* --------------------------------------------------------------------------
   Membuat HTML kalender
   -------------------------------------------------------------------------- */
function omiBuatKalenderHTML(bulan, checkIn, checkOut) {
  const tahun = bulan.getFullYear();
  const bln = bulan.getMonth();

  const awalBulan = new Date(tahun, bln, 1);
  const jumlahHari = new Date(tahun, bln + 1, 0).getDate();
  const offset = awalBulan.getDay(); // 0 = Minggu

  const hariIniISO = omiToISO(new Date());

  // Header hari: S M T W T F S (mengikuti label di Figma)
  const dow = ["S", "M", "T", "W", "T", "F", "S"];
  let html = `
    <div class="omi-calendar">
      <div class="omi-calendar-head">
        <button type="button" class="omi-calendar-nav" data-nav="prev" aria-label="Bulan sebelumnya">‹</button>
        <span class="omi-calendar-month">${OMI_BULAN_PANJANG[bln]} ${tahun}</span>
        <button type="button" class="omi-calendar-nav" data-nav="next" aria-label="Bulan berikutnya">›</button>
      </div>
      <div class="omi-calendar-grid">
        ${dow.map((d) => `<span class="omi-calendar-dow">${d}</span>`).join("")}
  `;

  // Sel kosong sebelum tanggal 1
  for (let i = 0; i < offset; i++) {
    html += `<span class="omi-calendar-day is-empty"></span>`;
  }

  for (let tgl = 1; tgl <= jumlahHari; tgl++) {
    const iso = omiToISO(new Date(tahun, bln, tgl));
    let kelas = "omi-calendar-day";

    if (iso === checkIn || iso === checkOut) kelas += " is-selected";
    else if (checkIn && checkOut && iso > checkIn && iso < checkOut) kelas += " is-in-range";

    if (iso === hariIniISO && iso !== checkIn && iso !== checkOut) kelas += " is-today";

    html += `<button type="button" class="${kelas}" data-hari="${iso}">${tgl}</button>`;
  }

  html += `</div></div>`;
  return html;
}

/* --------------------------------------------------------------------------
   Auto-init
   -------------------------------------------------------------------------- */
document.addEventListener("DOMContentLoaded", () => {
  if (document.getElementById("form-reservasi-data")) {
    if (!omiBoot("customer", "Reservasi")) return;
    omiRenderStepper(1);
    omiInitReservasiData();
    return;
  }

  if (document.getElementById("kalender")) {
    if (!omiBoot("customer", "Reservasi")) return;
    omiRenderStepper(2);
    omiInitReservasiKonfirmasi();
  }
});
