/* ==========================================================================
   OMI — Logika Halaman Ubah Password
   Catatan kejujuran: password hanya disimpan di localStorage sebagai data
   contoh. Ini BUKAN mekanisme keamanan dan tidak boleh dipakai produksi.
   ========================================================================== */

document.addEventListener("DOMContentLoaded", () => {
  const sesi = omiBoot(["customer", "admin", "staff", "kurir"], "Akun Saya");
  if (!sesi) return;

  const form = document.getElementById("form-password");
  if (!form) return;

  const errorBox = document.getElementById("form-error");
  const suksesBox = document.getElementById("form-sukses");

  form.addEventListener("submit", (event) => {
    event.preventDefault();
    omiSembunyikanError(errorBox);
    if (suksesBox) suksesBox.classList.add("omi-hidden");

    const lama = form.lama.value;
    const baru = form.baru.value;
    const konfirmasi = form.konfirmasi.value;

    const user = omiCariUser(omiState(), sesi.userId);
    if (!user) {
      omiTampilkanError(errorBox, "Akun tidak ditemukan. Coba masuk lagi.");
      return;
    }

    if (!lama || !baru || !konfirmasi) {
      omiTampilkanError(errorBox, "Semua kolom wajib diisi.");
      return;
    }

    if (lama !== user.password) {
      omiTampilkanError(errorBox, "Password lama tidak cocok.");
      return;
    }

    if (baru.length < 6) {
      omiTampilkanError(errorBox, "Password baru minimal 6 karakter.");
      return;
    }

    if (baru !== konfirmasi) {
      omiTampilkanError(errorBox, "Password baru dan konfirmasi tidak sama.");
      return;
    }

    omiUpdate((s) => {
      const target = s.users.find((u) => u.id === user.id);
      if (target) target.password = baru;
    });

    form.reset();
    if (suksesBox) {
      suksesBox.textContent = "Password berhasil diubah.";
      suksesBox.classList.remove("omi-hidden");
    }
  });
});