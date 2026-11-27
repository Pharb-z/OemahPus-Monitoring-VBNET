/* ==========================================================================
   OMI — Logika Modul Profil Kucing
   Menangani tiga halaman:
   - profil-kucing.html  (daftar kartu)
   - tambah-kucing.html  (form kosong)
   - edit-kucing.html    (form terisi, ?id=cat-01)
   ========================================================================== */

/* --------------------------------------------------------------------------
   1. DAFTAR KUCING
   -------------------------------------------------------------------------- */
function omiInitDaftarKucing() {
  const host = document.getElementById("kucing-grid");
  if (!host) return;

  const state = omiState();
  const sesi = omiGetSession();
  const milikSaya = state.kucing.filter((k) => k.pemilikId === sesi.userId);

  const kosong = document.getElementById("kucing-kosong");

  if (milikSaya.length === 0) {
    host.classList.add("omi-hidden");
    if (kosong) kosong.classList.remove("omi-hidden");
    return;
  }

  if (kosong) kosong.classList.add("omi-hidden");

  host.innerHTML = milikSaya
    .map(
      (kucing) => `
      <article class="omi-card omi-cat-card">
        <div class="omi-cat-photo">${kucing.emoji || "🐱"}</div>
        <h3 class="omi-cat-name omi-fw-semibold">${omiEsc(kucing.nama)} · ${kucing.usia} tahun</h3>
        <p class="omi-cat-breed">${omiEsc(kucing.ras)} · ${omiEsc(kucing.jenisKelamin)}</p>
        <div class="omi-cat-actions">
          <a class="omi-btn omi-btn--soft" href="edit-kucing.html?id=${encodeURIComponent(kucing.id)}">Edit</a>
          <button type="button" class="omi-btn omi-btn--danger" data-hapus="${omiEsc(kucing.id)}">Hapus</button>
        </div>
      </article>
    `
    )
    .join("");

  // Pasang aksi hapus
  host.querySelectorAll("[data-hapus]").forEach((tombol) => {
    tombol.addEventListener("click", () => omiHapusKucing(tombol.dataset.hapus));
  });
}

function omiHapusKucing(id) {
  const state = omiState();
  const kucing = omiCariKucing(state, id);
  if (!kucing) return;

  const yakin = window.confirm(
    `Hapus profil "${kucing.nama}"? Data yang sudah dihapus tidak bisa dikembalikan.`
  );
  if (!yakin) return;

  omiUpdate((s) => {
    s.kucing = s.kucing.filter((k) => k.id !== id);
  });

  window.location.reload();
}

/* --------------------------------------------------------------------------
   2. FORM TAMBAH / EDIT
   -------------------------------------------------------------------------- */
function omiInitFormKucing() {
  const form = document.getElementById("form-kucing");
  if (!form) return;

  const sesi = omiGetSession();
  const idEdit = omiParam("id");
  const modeEdit = Boolean(idEdit);

  const judul = document.getElementById("form-judul");
  const errorBox = document.getElementById("form-error");
  const preview = document.getElementById("foto-preview");

  let kucingLama = null;

  if (modeEdit) {
    const state = omiState();
    kucingLama = omiCariKucing(state, idEdit);

    if (!kucingLama) {
      // ID tidak ditemukan — kembali ke daftar.
      window.location.replace("profil-kucing.html");
      return;
    }

    if (judul) judul.textContent = "Edit Profil Kucing";
    document.title = "Edit Kucing — OMI";

    // Isi form dengan data yang ada
    form.nama.value = kucingLama.nama;
    form.usia.value = kucingLama.usia;
    form.jenisKelamin.value = kucingLama.jenisKelamin;
    form.ras.value = kucingLama.ras;
    form.warna.value = kucingLama.warna;
    form.berat.value = kucingLama.berat;
    form.catatan.value = kucingLama.catatan === "-" ? "" : kucingLama.catatan;

    if (preview) preview.textContent = kucingLama.emoji || "🐱";
  }

  // Tombol ganti foto — memilih emoji pengganti (simulasi unggah foto)
  const pilihanEmoji = ["🐱", "🐈", "🐈‍⬛", "😺", "😸"];
  let emojiTerpilih = kucingLama ? kucingLama.emoji || "🐱" : "🐱";

  const btnUbah = document.getElementById("btn-ubah-foto");
  if (btnUbah) {
    btnUbah.addEventListener("click", () => {
      const index = pilihanEmoji.indexOf(emojiTerpilih);
      emojiTerpilih = pilihanEmoji[(index + 1) % pilihanEmoji.length];
      if (preview) preview.textContent = emojiTerpilih;
    });
  }

  const btnHapusFoto = document.getElementById("btn-hapus-foto");
  if (btnHapusFoto) {
    btnHapusFoto.addEventListener("click", () => {
      emojiTerpilih = "🐾";
      if (preview) preview.textContent = emojiTerpilih;
    });
  }

  // Simpan
  form.addEventListener("submit", (event) => {
    event.preventDefault();
    omiSembunyikanError(errorBox);

    const nama = form.nama.value.trim();
    const usia = Number(form.usia.value);
    const jenisKelamin = form.jenisKelamin.value;
    const ras = form.ras.value.trim();
    const warna = form.warna.value.trim();
    const berat = Number(form.berat.value);
    const catatan = form.catatan.value.trim() || "-";

    // --- Validasi ---
    if (!nama) {
      omiTampilkanError(errorBox, "Nama kucing wajib diisi.");
      return;
    }

    if (!usia || usia < 0 || usia > 30) {
      omiTampilkanError(errorBox, "Usia kucing harus antara 0 sampai 30 tahun.");
      return;
    }

    if (!jenisKelamin) {
      omiTampilkanError(errorBox, "Jenis kelamin wajib dipilih.");
      return;
    }

    if (!ras) {
      omiTampilkanError(errorBox, "Ras kucing wajib diisi.");
      return;
    }

    if (!berat || berat <= 0 || berat > 30) {
      omiTampilkanError(errorBox, "Berat badan harus antara 0,1 sampai 30 kg.");
      return;
    }

    // --- Simpan ---
    const data = {
      nama,
      usia,
      jenisKelamin,
      ras,
      warna: warna || "-",
      berat,
      catatan,
      emoji: emojiTerpilih,
    };

    if (modeEdit) {
      omiUpdate((s) => {
        const target = s.kucing.find((k) => k.id === idEdit);
        if (target) Object.assign(target, data);
      });
    } else {
      omiUpdate((s) => {
        s.kucing.push({
          id: "cat-" + Date.now(),
          ...data,
          pemilikId: sesi.userId,
        });
      });
    }

    window.location.href = "profil-kucing.html";
  });

  // Tombol batal
  const btnBatal = document.getElementById("btn-batal");
  if (btnBatal) {
    btnBatal.addEventListener("click", () => {
      window.location.href = "profil-kucing.html";
    });
  }
}

/* --------------------------------------------------------------------------
   Auto-init
   -------------------------------------------------------------------------- */
document.addEventListener("DOMContentLoaded", () => {
  // Daftar kucing
  if (document.getElementById("kucing-grid")) {
    const sesi = omiBoot("customer", "Profil Kucing");
    if (!sesi) return;
    omiInitDaftarKucing();
    return;
  }

  // Form tambah / edit
  if (document.getElementById("form-kucing")) {
    const sesi = omiBoot("customer", "Profil Kucing");
    if (!sesi) return;
    omiInitFormKucing();
  }
});
