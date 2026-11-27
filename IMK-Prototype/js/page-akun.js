/* ==========================================================================
   OMI — Logika Halaman Akun Saya (frame 14, node 71:609)
   ========================================================================== */

document.addEventListener("DOMContentLoaded", () => {
  // Akun bisa dibuka oleh semua peran, jadi tidak dibatasi role tertentu.
  const sesi = omiBoot(["customer", "admin", "staff", "kurir"], "Akun Saya");
  if (!sesi) return;

  omiInitAkun(sesi);
});

function omiInitAkun(sesi) {
  const state = omiState();
  const user = omiCariUser(state, sesi.userId);

  if (!user) {
    window.location.replace("index.html");
    return;
  }

  const form = document.getElementById("form-akun");
  const errorBox = document.getElementById("akun-error");
  const suksesBox = document.getElementById("akun-sukses");

  // --- Isi kartu identitas ---
  const setTeks = (id, teks) => {
    const el = document.getElementById(id);
    if (el) el.textContent = teks;
  };

  setTeks("akun-nama", user.nama);
  setTeks("akun-email", user.email);
  setTeks("akun-inisial", user.inisial || user.nama.charAt(0).toUpperCase());
  setTeks("akun-peran", omiLabelPeran(user.role));

  // --- Isi form ---
  const bagianNama = String(user.nama || "").split(" ");
  form.namaDepan.value = bagianNama[0] || "";
  form.namaBelakang.value = bagianNama.slice(1).join(" ");
  form.telepon.value = user.telepon || "";
  form.email.value = user.email || "";
  form.alamat.value = user.alamat || "";

  // --- Simpan ---
  form.addEventListener("submit", (event) => {
    event.preventDefault();
    omiSembunyikanError(errorBox);
    if (suksesBox) suksesBox.classList.add("omi-hidden");

    const namaDepan = form.namaDepan.value.trim();
    const namaBelakang = form.namaBelakang.value.trim();
    const telepon = form.telepon.value.trim();
    const email = form.email.value.trim();
    const alamat = form.alamat.value.trim();

    if (!namaDepan) {
      omiTampilkanError(errorBox, "Nama depan wajib diisi.");
      return;
    }

    if (!email) {
      omiTampilkanError(errorBox, "Email wajib diisi.");
      return;
    }

    if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email)) {
      omiTampilkanError(errorBox, "Format email belum benar. Contoh: nama@email.com");
      return;
    }

    if (telepon && !/^[0-9+\-\s]{8,20}$/.test(telepon)) {
      omiTampilkanError(errorBox, "Nomor telepon hanya boleh angka, 8–20 digit.");
      return;
    }

    // Cek email dipakai akun lain
    const dipakai = state.users.some(
      (u) => u.id !== user.id && u.email.toLowerCase() === email.toLowerCase()
    );
    if (dipakai) {
      omiTampilkanError(errorBox, "Email sudah dipakai akun lain.");
      return;
    }

    const namaLengkap = [namaDepan, namaBelakang].filter(Boolean).join(" ");

    omiUpdate((s) => {
      const target = s.users.find((u) => u.id === user.id);
      if (!target) return;
      target.nama = namaLengkap;
      target.telepon = telepon;
      target.email = email;
      target.alamat = alamat;
      target.inisial = namaDepan.charAt(0).toUpperCase();

      // Sinkronkan sesi supaya navbar langsung ikut berubah
      if (s.sesi) {
        s.sesi.nama = namaLengkap;
        s.sesi.email = email;
        s.sesi.inisial = target.inisial;
      }
    });

    // Perbarui tampilan tanpa reload
    setTeks("akun-nama", namaLengkap);
    setTeks("akun-email", email);
    setTeks("akun-inisial", namaDepan.charAt(0).toUpperCase());
    omiRenderNavbar("Akun Saya", omiGetSession());

    if (suksesBox) {
      suksesBox.textContent = "Perubahan berhasil disimpan.";
      suksesBox.classList.remove("omi-hidden");
    }
  });

  // --- Keluar ---
  const btnKeluar = document.getElementById("btn-keluar");
  if (btnKeluar) {
    btnKeluar.addEventListener("click", () => {
      if (window.confirm("Keluar dari akun?")) omiLogout();
    });
  }

  // --- Reset data demo ---
  const btnReset = document.getElementById("btn-reset");
  if (btnReset) {
    btnReset.addEventListener("click", () => {
      const yakin = window.confirm(
        "Reset semua data demo ke kondisi awal?\n" +
        "Kucing, reservasi, dan pembayaran yang kamu tambahkan akan hilang."
      );
      if (!yakin) return;
      omiResetState();
      window.location.href = "index.html";
    });
  }
}
