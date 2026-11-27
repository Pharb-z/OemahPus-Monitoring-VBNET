/* ==========================================================================
   OMI — Logika Modul Staff & Staff Antar Jemput
   Halaman:
   - staff-daily-report.html         daftar penitipan (frame 17)
   - staff-buat-laporan.html         form laporan (frame 18)
   - staff-pilih-tanggal.html        kalender (frame 19)
   - staff-antar-jemput.html         jadwal antar jemput (frame 20)
   - staff-detail-antar-jemput.html  detail pesanan (frame 21)
   - staff-checkin-out.html          check-in / check-out
   - staff-riwayat-layanan.html      riwayat layanan (frame 34)
   ========================================================================== */

/* --------------------------------------------------------------------------
   1. DAFTAR PENITIPAN / DAILY REPORT (frame 17)
   -------------------------------------------------------------------------- */
function omiInitDailyReport() {
  const host = document.getElementById("penitipan-list");
  if (!host) return;

  omiRenderPenitipan();

  const inputCari = document.getElementById("cari-penitipan");
  if (inputCari) {
    inputCari.addEventListener("input", () => {
      omiRenderPenitipan(inputCari.value.trim().toLowerCase());
    });
  }
}

function omiRenderPenitipan(kataKunci = "") {
  const host = document.getElementById("penitipan-list");
  if (!host) return;

  const state = omiState();
  const kosong = document.getElementById("penitipan-kosong");

  const daftar = state.penitipan.filter((p) => {
    if (!kataKunci) return true;
    return (
      p.nama.toLowerCase().includes(kataKunci) ||
      p.kandang.toLowerCase().includes(kataKunci) ||
      p.paket.toLowerCase().includes(kataKunci)
    );
  });

  if (daftar.length === 0) {
    host.classList.add("omi-hidden");
    if (kosong) kosong.classList.remove("omi-hidden");
    return;
  }

  host.classList.remove("omi-hidden");
  if (kosong) kosong.classList.add("omi-hidden");

  host.innerHTML = daftar
    .map(
      (item) => `
      <article class="omi-card omi-report-card">
        <h3 class="omi-report-nama">${omiEsc(item.nama)}</h3>
        <div class="omi-report-photo">${item.emoji || "🐱"}</div>
        <p class="omi-report-meta">Kandang ${omiEsc(item.kandang)} · ${omiEsc(item.paket)}</p>
        <p class="omi-report-meta">Check-in: ${omiTanggalSingkat(item.checkIn)}</p>
        <a class="omi-btn omi-btn--primary omi-report-aksi"
           href="staff-buat-laporan.html?id=${encodeURIComponent(item.id)}">Buat Laporan</a>
      </article>
    `
    )
    .join("");
}

/* --------------------------------------------------------------------------
   2. FORM BUAT LAPORAN (frame 18)
   Field: Nama Kucing, Tanggal, Makan, Minum, Kondisi, Nama Kandang, Catatan.
   -------------------------------------------------------------------------- */
function omiInitBuatLaporan() {
  const form = document.getElementById("form-laporan");
  if (!form) return;

  const idPenitipan = omiParam("id");
  const state = omiState();
  const penitipan = state.penitipan.find((p) => p.id === idPenitipan);

  if (!penitipan) {
    window.location.replace("staff-daily-report.html");
    return;
  }

  const infoHost = document.getElementById("laporan-info");
  if (infoHost) {
    infoHost.innerHTML = `
      <div class="omi-penitipan-row">
        <div class="omi-penitipan-photo">${penitipan.emoji || "🐱"}</div>
        <div class="omi-penitipan-info">
          <p class="omi-penitipan-nama">${omiEsc(penitipan.nama)}</p>
          <p class="omi-penitipan-meta">
            Kandang ${omiEsc(penitipan.kandang)} · ${omiEsc(penitipan.paket)} ·
            Check-in ${omiTanggalSingkat(penitipan.checkIn)}
          </p>
        </div>
      </div>`;
  }

  form.nama.value = penitipan.nama;
  form.kandang.value = penitipan.kandang;
  form.tanggal.value = omiToISO(new Date());

  const labelTanggal = document.getElementById("label-tanggal");
  if (labelTanggal) labelTanggal.textContent = omiTanggalPanjang(form.tanggal.value);

  form.tanggal.addEventListener("change", () => {
    if (labelTanggal) labelTanggal.textContent = omiTanggalPanjang(form.tanggal.value);
  });

  const errorBox = document.getElementById("form-error");

  form.addEventListener("submit", (event) => {
    event.preventDefault();
    omiSembunyikanError(errorBox);

    const tanggal = form.tanggal.value;
    const makan = form.makan.value.trim();
    const minum = form.minum.value.trim();
    const kondisi = form.kondisi.value.trim();
    const kandang = form.kandang.value.trim();
    const catatan = form.catatan.value.trim();

    if (!tanggal) {
      omiTampilkanError(errorBox, "Tanggal laporan wajib diisi.");
      return;
    }

    if (!kandang) {
      omiTampilkanError(errorBox, "Nama kandang wajib diisi.");
      return;
    }

    if (!makan) {
      omiTampilkanError(errorBox, "Catatan makan wajib diisi. Contoh: Habis 1 porsi.");
      return;
    }

    if (!minum) {
      omiTampilkanError(errorBox, "Catatan minum wajib diisi.");
      return;
    }

    if (!kondisi) {
      omiTampilkanError(errorBox, "Kondisi kucing wajib diisi. Contoh: Sehat & aktif.");
      return;
    }

    // Satu laporan per kucing per tanggal
    const stateNow = omiState();
    const sudahAda =
      stateNow.laporan &&
      stateNow.laporan.some((l) => l.penitipanId === penitipan.id && l.tanggal === tanggal);

    if (sudahAda) {
      omiTampilkanError(
        errorBox,
        `Laporan untuk ${penitipan.nama} pada ${omiTanggalSingkat(tanggal)} sudah dibuat. ` +
        "Ubah laporan yang ada atau pilih tanggal lain."
      );
      return;
    }

    omiUpdate((s) => {
      if (!s.laporan) s.laporan = [];
      s.laporan.push({
        id: "lap-" + Date.now(),
        penitipanId: penitipan.id,
        namaKucing: penitipan.nama,
        kandang,
        tanggal,
        makan,
        minum,
        kondisi,
        catatan,
        dibuatOleh: s.sesi ? s.sesi.userId : null,
      });

      // Catat juga di riwayat layanan agar staf bisa menelusuri kembali.
      if (!s.riwayatLayanan) s.riwayatLayanan = [];
      s.riwayatLayanan.unshift({
        tanggal: omiTanggalSingkat(tanggal),
        kucing: penitipan.nama,
        layanan: "Daily Report",
        petugas: s.sesi ? s.sesi.nama : "-",
        status: "Terkirim",
      });
    });

    alert(`Laporan harian ${penitipan.nama} berhasil dikirim.`);
    window.location.href = "staff-daily-report.html";
  });

  const btnBatal = document.getElementById("btn-batal");
  if (btnBatal) {
    btnBatal.addEventListener("click", () => {
      window.location.href = "staff-daily-report.html";
    });
  }
}

/* --------------------------------------------------------------------------
   3. PILIH TANGGAL — kalender penuh (frame 19)
   -------------------------------------------------------------------------- */
function omiInitPilihTanggal() {
  const host = document.getElementById("kalender");
  if (!host) return;

  let bulan = new Date(2026, 10, 1); // November 2026, sesuai Figma
  let terpilih = "2026-11-12";

  const gambar = () => {
    const tahun = bulan.getFullYear();
    const bln = bulan.getMonth();
    const jumlahHari = new Date(tahun, bln + 1, 0).getDate();
    const mulai = new Date(tahun, bln, 1).getDay();

    let sel = ["<span class=\"omi-calendar-dow\">S</span>", "<span class=\"omi-calendar-dow\">M</span>",
      "<span class=\"omi-calendar-dow\">T</span>", "<span class=\"omi-calendar-dow\">W</span>",
      "<span class=\"omi-calendar-dow\">T</span>", "<span class=\"omi-calendar-dow\">F</span>",
      "<span class=\"omi-calendar-dow\">S</span>"].join("");

    for (let i = 0; i < mulai; i++) sel += '<span class="omi-calendar-day is-empty"></span>';

    for (let d = 1; d <= jumlahHari; d++) {
      const iso = omiToISO(new Date(tahun, bln, d));
      const kelas = iso === terpilih ? "omi-calendar-day is-selected" : "omi-calendar-day";
      sel += `<button type="button" class="${kelas}" data-tanggal="${iso}">${d}</button>`;
    }

    host.innerHTML = `
      <div class="omi-calendar-head">
        <button type="button" class="omi-calendar-nav" data-geser="-1" aria-label="Bulan sebelumnya">◀</button>
        <span class="omi-calendar-month">${OMI_BULAN_PANJANG[bln]} ${tahun}</span>
        <button type="button" class="omi-calendar-nav" data-geser="1" aria-label="Bulan berikutnya">▶</button>
      </div>
      <div class="omi-calendar-grid">${sel}</div>`;

    host.querySelectorAll("[data-geser]").forEach((tombol) => {
      tombol.addEventListener("click", () => {
        bulan = new Date(bulan.getFullYear(), bulan.getMonth() + Number(tombol.dataset.geser), 1);
        gambar();
      });
    });

    host.querySelectorAll("[data-tanggal]").forEach((tombol) => {
      tombol.addEventListener("click", () => {
        terpilih = tombol.dataset.tanggal;
        gambar();
        const label = document.getElementById("tanggal-terpilih");
        if (label) label.textContent = omiTanggalPanjang(terpilih);
      });
    });
  };

  gambar();

  const btnLanjut = document.getElementById("btn-lanjut-tanggal");
  if (btnLanjut) {
    btnLanjut.addEventListener("click", () => {
      window.location.href = `staff-daily-report.html?tanggal=${terpilih}`;
    });
  }
}

/* --------------------------------------------------------------------------
   4. JADWAL ANTAR JEMPUT (frame 20)
   -------------------------------------------------------------------------- */
function omiInitAntarJemput() {
  const host = document.getElementById("tugas-list");
  if (!host) return;

  omiRenderTugas();
}

function omiRenderTugas() {
  const host = document.getElementById("tugas-list");
  if (!host) return;

  const state = omiState();

  host.innerHTML = state.antarJemput
    .map(
      (tugas) => `
      <article class="omi-tugas-card">
        <div class="omi-tugas-head">
          <div class="omi-tugas-icon">${tugas.emoji || "🚗"}</div>
          <div>
            <p class="omi-tugas-nama">${omiEsc(tugas.nama)}</p>
            <p class="omi-tugas-jadwal">Jemput: ${omiEsc(tugas.jemput)}</p>
          </div>
        </div>
        <p class="omi-tugas-alamat">
          <span aria-hidden="true">📍</span>
          <span>${omiEsc(tugas.alamat)}</span>
        </p>
        <div class="omi-tugas-foot">
          <span class="omi-badge omi-badge--${omiStatusBadge(tugas.status)}">${omiEsc(tugas.status)}</span>
          <a class="omi-btn omi-btn--soft" href="staff-detail-antar-jemput.html?id=${encodeURIComponent(tugas.id)}">
            Perbarui
          </a>
        </div>
      </article>`
    )
    .join("");
}

/* --------------------------------------------------------------------------
   5. DETAIL PESANAN ANTAR JEMPUT (frame 21)
   -------------------------------------------------------------------------- */
function omiInitDetailTugas() {
  const form = document.getElementById("form-tugas");
  if (!form) return;

  const idTugas = omiParam("id");
  const state = omiState();
  const tugas = state.antarJemput.find((t) => t.id === idTugas);

  if (!tugas) {
    window.location.replace("staff-antar-jemput.html");
    return;
  }

  const infoHost = document.getElementById("detail-tugas-info");
  if (infoHost) {
    infoHost.innerHTML = `
      <div class="omi-detail-antar">
        <div class="omi-detail-antar-foto">${tugas.emoji || "🐱"}</div>
        <dl class="omi-detail-grid">
          <div><dt>Pemilik Kucing</dt><dd>${omiEsc(tugas.pemilik)}</dd></div>
          <div><dt>Kucing</dt><dd>${omiEsc(tugas.kucing)}</dd></div>
          <div style="grid-column:1/-1"><dt>Alamat Penjemputan</dt><dd>${omiEsc(tugas.alamat)}</dd></div>
          <div style="grid-column:1/-1"><dt>Jadwal Jemput</dt><dd>${omiTanggalPanjang(tugas.tanggal)} · ${omiEsc(tugas.jemput)}</dd></div>
        </dl>
      </div>`;
  }

  form.status.value = tugas.status;

  const errorBox = document.getElementById("form-error");

  form.addEventListener("submit", (event) => {
    event.preventDefault();
    omiSembunyikanError(errorBox);

    const statusBaru = form.status.value;
    if (!statusBaru) {
      omiTampilkanError(errorBox, "Pilih status tugas terlebih dahulu.");
      return;
    }

    omiUpdate((s) => {
      const target = s.antarJemput.find((t) => t.id === tugas.id);
      if (target) target.status = statusBaru;
    });

    window.location.href = "staff-antar-jemput.html";
  });

  // Tombol pintas status
  document.querySelectorAll("[data-status]").forEach((tombol) => {
    tombol.addEventListener("click", () => {
      form.status.value = tombol.dataset.status;
      form.requestSubmit();
    });
  });

  const btnBatal = document.getElementById("btn-batal");
  if (btnBatal) {
    btnBatal.addEventListener("click", () => {
      window.location.href = "staff-antar-jemput.html";
    });
  }
}

/* --------------------------------------------------------------------------
   6. CHECK IN & OUT (halaman tambahan, mengikuti gaya Figma)
   -------------------------------------------------------------------------- */
function omiInitCheckInOut() {
  const host = document.getElementById("checkinout-list");
  if (!host) return;

  const state = omiState();

  host.innerHTML = state.penitipan
    .map(
      (item) => `
      <div class="omi-penitipan-row">
        <div class="omi-penitipan-photo">${item.emoji || "🐱"}</div>
        <div class="omi-penitipan-info">
          <p class="omi-penitipan-nama">${omiEsc(item.nama)}</p>
          <p class="omi-penitipan-meta">
            Kandang ${omiEsc(item.kandang)} · ${omiEsc(item.paket)}
          </p>
          <p class="omi-penitipan-meta">Check-in: ${omiTanggalSingkat(item.checkIn)}</p>
        </div>
        <div class="omi-penitipan-aksi">
          <span class="omi-badge omi-badge--success">Sedang Menginap</span>
          <button type="button" class="omi-btn omi-btn--soft" data-checkout="${omiEsc(item.id)}">
            Catat Check-out
          </button>
        </div>
      </div>
    `
    )
    .join("");

  host.querySelectorAll("[data-checkout]").forEach((tombol) => {
    tombol.addEventListener("click", () => {
      const id = tombol.dataset.checkout;
      const item = omiState().penitipan.find((p) => p.id === id);
      if (!item) return;

      const yakin = window.confirm(
        `Catat check-out untuk ${item.nama} (kandang ${item.kandang})?\n\n` +
        "Data penitipan akan dihapus dari daftar aktif, tetapi riwayat tetap tersimpan."
      );
      if (!yakin) return;

      omiUpdate((s) => {
        s.penitipan = s.penitipan.filter((p) => p.id !== id);
        if (!s.riwayatLayanan) s.riwayatLayanan = [];
        s.riwayatLayanan.unshift({
          tanggal: omiTanggalSingkat(omiToISO(new Date())),
          kucing: item.nama,
          layanan: "Check Out",
          petugas: s.sesi ? s.sesi.nama : "-",
          status: "Selesai",
        });
      });

      window.location.reload();
    });
  });
}

/* --------------------------------------------------------------------------
   7. RIWAYAT LAYANAN (frame 34)
   -------------------------------------------------------------------------- */
let omiFilterRiwayatLayanan = "";

function omiInitRiwayatLayanan() {
  const body = document.getElementById("riwayat-layanan-body");
  if (!body) return;

  omiRenderRiwayatLayanan();

  const inputCari = document.getElementById("cari-riwayat-layanan");
  if (inputCari) {
    inputCari.addEventListener("input", () => {
      omiFilterRiwayatLayanan = inputCari.value.trim().toLowerCase();
      omiRenderRiwayatLayanan();
    });
  }
}

function omiRenderRiwayatLayanan() {
  const body = document.getElementById("riwayat-layanan-body");
  if (!body) return;

  const daftar = (omiState().riwayatLayanan || []).filter((l) => {
    if (!omiFilterRiwayatLayanan) return true;
    return (
      l.kucing.toLowerCase().includes(omiFilterRiwayatLayanan) ||
      l.layanan.toLowerCase().includes(omiFilterRiwayatLayanan) ||
      l.petugas.toLowerCase().includes(omiFilterRiwayatLayanan)
    );
  });

  if (daftar.length === 0) {
    body.innerHTML = `
      <tr>
        <td colspan="5" class="omi-text-center omi-text-muted">
          Tidak ada riwayat layanan yang cocok.
        </td>
      </tr>`;
    return;
  }

  body.innerHTML = daftar
    .map(
      (l) => `
      <tr>
        <td>${omiEsc(l.tanggal)}</td>
        <td class="omi-fw-semibold">${omiEsc(l.kucing)}</td>
        <td>${omiEsc(l.layanan)}</td>
        <td>${omiEsc(l.petugas)}</td>
        <td><span class="omi-badge omi-badge--${omiStatusBadge(l.status)}">${omiEsc(l.status)}</span></td>
      </tr>`
    )
    .join("");
}

/* --------------------------------------------------------------------------
   Auto-init
   -------------------------------------------------------------------------- */
document.addEventListener("DOMContentLoaded", () => {
  const halaman = {
    "penitipan-list": { roles: ["staff"], menu: "Daily Report", init: omiInitDailyReport },
    "form-laporan": { roles: ["staff"], menu: "Daily Report", init: omiInitBuatLaporan },
    "kalender": { roles: ["staff"], menu: "Daily Report", init: omiInitPilihTanggal },
    "tugas-list": { roles: ["kurir"], menu: "Jadwal", init: omiInitAntarJemput },
    "form-tugas": { roles: ["kurir"], menu: "Detail Pesanan", init: omiInitDetailTugas },
    "checkinout-list": { roles: ["staff"], menu: "Check In & Out", init: omiInitCheckInOut },
    "riwayat-layanan-body": { roles: ["staff"], menu: "Riwayat Layanan", init: omiInitRiwayatLayanan },
  };

  for (const [id, config] of Object.entries(halaman)) {
    if (!document.getElementById(id)) continue;

    if (!omiBoot(config.roles, config.menu)) return;
    config.init();
    return;
  }
});