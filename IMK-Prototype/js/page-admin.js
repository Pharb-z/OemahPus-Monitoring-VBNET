/* ==========================================================================
   OMI — Logika Modul Admin
   Halaman:
   - admin-kelola-layanan.html    daftar + cari + hapus (frame 15)
   - admin-tambah-layanan.html    tambah / edit layanan (frame 16)
   ========================================================================== */

/* --------------------------------------------------------------------------
   1. DAFTAR LAYANAN
   -------------------------------------------------------------------------- */
let omiFilterLayanan = "";

function omiInitKelolaLayanan() {
  const host = document.getElementById("layanan-grid");
  if (!host) return;

  omiRenderLayanan();

  const inputCari = document.getElementById("cari-layanan");
  if (inputCari) {
    inputCari.addEventListener("input", () => {
      omiFilterLayanan = inputCari.value.trim().toLowerCase();
      omiRenderLayanan();
    });
  }
}

function omiRenderLayanan() {
  const host = document.getElementById("layanan-grid");
  if (!host) return;

  const state = omiState();
  const kosong = document.getElementById("layanan-kosong");
  const jumlahEl = document.getElementById("jumlah-layanan");

  const daftar = state.paket.filter((p) => {
    if (!omiFilterLayanan) return true;
    return (
      p.nama.toLowerCase().includes(omiFilterLayanan) ||
      p.jenis.toLowerCase().includes(omiFilterLayanan) ||
      p.deskripsi.toLowerCase().includes(omiFilterLayanan)
    );
  });

  if (jumlahEl) {
    jumlahEl.textContent = `Menampilkan ${daftar.length} dari ${state.paket.length} layanan`;
  }

  if (daftar.length === 0) {
    host.classList.add("omi-hidden");
    if (kosong) kosong.classList.remove("omi-hidden");
    return;
  }

  host.classList.remove("omi-hidden");
  if (kosong) kosong.classList.add("omi-hidden");

  host.innerHTML = daftar
    .map(
      (paket) => `
      <article class="omi-card omi-layanan-card">
        <span class="omi-layanan-jenis">${omiEsc(paket.jenis)}</span>
        <h3 class="omi-layanan-nama">${omiEsc(paket.nama)}</h3>
        <p class="omi-layanan-harga">
          ${omiRupiah(paket.harga)}<small> /${omiEsc(paket.satuan)}</small>
        </p>
        <ul class="omi-layanan-fitur">
          ${paket.fitur.map((f) => `<li>${omiEsc(f)}</li>`).join("")}
        </ul>
        <div class="omi-layanan-aksi">
          <a class="omi-btn omi-btn--soft" href="admin-tambah-layanan.html?id=${encodeURIComponent(paket.id)}">Edit</a>
          <button type="button" class="omi-btn omi-btn--danger" data-hapus="${omiEsc(paket.id)}">Hapus</button>
        </div>
      </article>
    `
    )
    .join("");

  host.querySelectorAll("[data-hapus]").forEach((tombol) => {
    tombol.addEventListener("click", () => omiHapusLayanan(tombol.dataset.hapus));
  });
}

function omiHapusLayanan(id) {
  const state = omiState();
  const paket = omiCariPaket(state, id);
  if (!paket) return;

  const dipakai = state.reservasi.some((r) => r.paketId === id);
  if (dipakai) {
    alert(
      `Layanan "${paket.nama}" tidak bisa dihapus karena masih dipakai pada reservasi yang ada.\n\n` +
      "Hapus atau ubah reservasi terkait terlebih dahulu."
    );
    return;
  }

  const yakin = window.confirm(`Hapus layanan "${paket.nama}"?`);
  if (!yakin) return;

  omiUpdate((s) => {
    s.paket = s.paket.filter((p) => p.id !== id);
  });

  omiRenderLayanan();
}

/* --------------------------------------------------------------------------
   2. FORM TAMBAH / EDIT LAYANAN
   -------------------------------------------------------------------------- */
function omiInitFormLayanan() {
  const form = document.getElementById("form-layanan");
  if (!form) return;

  const idEdit = omiParam("id");
  const modeEdit = Boolean(idEdit);
  const errorBox = document.getElementById("form-error");
  const judul = document.getElementById("form-judul");

  if (modeEdit) {
    const state = omiState();
    const paket = omiCariPaket(state, idEdit);

    if (!paket) {
      window.location.replace("admin-kelola-layanan.html");
      return;
    }

    if (judul) judul.textContent = "Edit Layanan";
    document.title = "Edit Layanan — OMI";

    form.nama.value = paket.nama;
    form.jenis.value = paket.jenis;
    form.harga.value = paket.harga;
    form.satuan.value = paket.satuan;
    form.deskripsi.value = paket.deskripsi;
  }

  form.addEventListener("submit", (event) => {
    event.preventDefault();
    omiSembunyikanError(errorBox);

    const nama = form.nama.value.trim();
    const jenis = form.jenis.value;
    const harga = Number(form.harga.value);
    const satuan = form.satuan.value.trim();
    const deskripsi = form.deskripsi.value.trim();

    // --- Validasi ---
    if (!nama) {
      omiTampilkanError(errorBox, "Nama layanan wajib diisi.");
      return;
    }

    if (!jenis) {
      omiTampilkanError(errorBox, "Jenis layanan wajib dipilih.");
      return;
    }

    if (!harga || harga <= 0) {
      omiTampilkanError(errorBox, "Harga harus lebih besar dari 0.");
      return;
    }

    if (!satuan) {
      omiTampilkanError(errorBox, "Satuan wajib diisi. Contoh: malam, trip, hari.");
      return;
    }

    if (!deskripsi) {
      omiTampilkanError(errorBox, "Deskripsi wajib diisi.");
      return;
    }

    // --- Simpan ---
    const data = { nama, jenis, harga, satuan, deskripsi };

    if (modeEdit) {
      omiUpdate((s) => {
        const target = s.paket.find((p) => p.id === idEdit);
        if (!target) return;
        Object.assign(target, data);
        // Fitur pertama mengikuti deskripsi terbaru
        target.fitur = [deskripsi, ...(target.fitur || []).slice(1)];
      });
    } else {
      omiUpdate((s) => {
        s.paket.push({
          id: "pkg-" + Date.now(),
          ...data,
          fitur: [deskripsi],
        });
      });
    }

    window.location.href = "admin-kelola-layanan.html";
  });

  const btnBatal = document.getElementById("btn-batal");
  if (btnBatal) {
    btnBatal.addEventListener("click", () => {
      window.location.href = "admin-kelola-layanan.html";
    });
  }
}

/* --------------------------------------------------------------------------
   3. RIWAYAT RESERVASI (frame 27)
   -------------------------------------------------------------------------- */
function omiInitRiwayatReservasiAdmin() {
  const body = document.getElementById("admin-reservasi-body");
  if (!body) return;

  const daftar = omiState().riwayatReservasi;

  body.innerHTML = daftar
    .map(
      (r) => `
      <tr>
        <td class="omi-fw-semibold">${omiEsc(r.id)}</td>
        <td>${omiEsc(r.pemilik)}</td>
        <td>${omiEsc(r.kucing)}</td>
        <td>${omiEsc(r.paket)}</td>
        <td>${omiEsc(r.tanggal)}</td>
        <td><span class="omi-badge omi-badge--${omiStatusBadge(r.status)}">${omiEsc(r.status)}</span></td>
      </tr>`
    )
    .join("");
}

/* --------------------------------------------------------------------------
   4. RIWAYAT PEMBAYARAN (frame 28)
   -------------------------------------------------------------------------- */
function omiInitRiwayatPembayaranAdmin() {
  const body = document.getElementById("admin-pembayaran-body");
  if (!body) return;

  const daftar = omiState().riwayatPembayaran;

  body.innerHTML = daftar
    .map(
      (p) => `
      <tr>
        <td class="omi-fw-semibold">${omiEsc(p.id)}</td>
        <td>${omiEsc(p.pemilik)}</td>
        <td>${omiRupiah(p.nominal)}</td>
        <td>${omiEsc(p.metode)}</td>
        <td>${omiEsc(p.tanggal)}</td>
        <td><span class="omi-badge omi-badge--${omiStatusBadge(p.status)}">${omiEsc(p.status)}</span></td>
      </tr>`
    )
    .join("");
}

/* --------------------------------------------------------------------------
   5. RIWAYAT PEMERIKSAAN MEDIS (frame 29)
   -------------------------------------------------------------------------- */
function omiInitRiwayatMedisAdmin() {
  const body = document.getElementById("admin-medis-body");
  if (!body) return;

  const daftar = omiState().riwayatMedis;

  body.innerHTML = daftar
    .map(
      (m) => `
      <tr>
        <td class="omi-fw-semibold">${omiEsc(m.kucing)}</td>
        <td>${omiEsc(m.pemilik)}</td>
        <td>${omiEsc(m.tanggal)}</td>
        <td>${omiEsc(m.pemeriksaan)}</td>
        <td><span class="omi-badge omi-badge--${omiStatusBadge(m.kondisi)}">${omiEsc(m.kondisi)}</span></td>
        <td>${omiEsc(m.catatan)}</td>
      </tr>`
    )
    .join("");
}

/* --------------------------------------------------------------------------
   6. RESERVASI + SLOT KANDANG (frame 30)
   -------------------------------------------------------------------------- */
function omiInitReservasiAdmin() {
  const body = document.getElementById("admin-reservasi-terkini-body");
  if (!body) return;

  const state = omiState();
  const daftar = state.riwayatReservasi.slice(0, 5);

  body.innerHTML = daftar
    .map(
      (r) => `
      <tr>
        <td class="omi-fw-semibold">${omiEsc(r.id)}</td>
        <td>${omiEsc(r.pemilik)}</td>
        <td>${omiEsc(r.kucing)}</td>
        <td>${omiEsc(omiTanggalSingkat(r.checkIn))}</td>
        <td><span class="omi-badge omi-badge--${omiStatusBadge(r.status)}">${omiEsc(r.status)}</span></td>
      </tr>`
    )
    .join("");

  omiRenderSlot();

  const btnCatat = document.getElementById("btn-catat-slot");
  if (btnCatat) {
    btnCatat.addEventListener("click", () => {
      alert("Pilih salah satu slot untuk mencatat status kandang.");
    });
  }
}

function omiRenderSlot() {
  const host = document.getElementById("slot-grid");
  if (!host) return;

  host.innerHTML = omiState()
    .kandang.map(
      (slot) => `
      <button type="button" class="omi-slot is-${slot.status.toLowerCase()}" data-kode="${omiEsc(slot.kode)}">
        <span class="omi-slot-kode">${omiEsc(slot.kode)}</span>
        <span class="omi-slot-status">${omiEsc(slot.status)}</span>
      </button>`
    )
    .join("");

  host.querySelectorAll("[data-kode]").forEach((tombol) => {
    tombol.addEventListener("click", () => {
      const urutan = ["Tersedia", "Terisi", "Maintenance"];
      omiUpdate((s) => {
        const slot = s.kandang.find((k) => k.kode === tombol.dataset.kode);
        if (!slot) return;
        slot.status = urutan[(urutan.indexOf(slot.status) + 1) % urutan.length];
      });
      omiRenderSlot();
    });
  });
}

/* --------------------------------------------------------------------------
   Auto-init
   -------------------------------------------------------------------------- */
document.addEventListener("DOMContentLoaded", () => {
  if (document.getElementById("layanan-grid")) {
    if (!omiBoot("admin", "Kelola Layanan")) return;
    omiInitKelolaLayanan();
    return;
  }

  if (document.getElementById("form-layanan")) {
    if (!omiBoot("admin", "Kelola Layanan")) return;
    omiInitFormLayanan();
    return;
  }

  if (document.getElementById("admin-reservasi-body")) {
    if (!omiBoot("admin", "Riwayat")) return;
    omiInitRiwayatReservasiAdmin();
    return;
  }

  if (document.getElementById("admin-pembayaran-body")) {
    if (!omiBoot("admin", "Riwayat")) return;
    omiInitRiwayatPembayaranAdmin();
    return;
  }

  if (document.getElementById("admin-medis-body")) {
    if (!omiBoot("admin", "Riwayat")) return;
    omiInitRiwayatMedisAdmin();
    return;
  }

  if (document.getElementById("slot-grid")) {
    if (!omiBoot("admin", "Reservasi")) return;
    omiInitReservasiAdmin();
  }
});
