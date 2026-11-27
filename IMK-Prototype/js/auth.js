/* ==========================================================================
   OMI — Logika Autentikasi Prototipe
   Menangani halaman Login (index.html) dan Sign Up (signup.html).

   Catatan kejujuran: autentikasi di sini hanya mencocokkan data contoh di
   localStorage. Ini BUKAN autentikasi aman dan tidak boleh dipakai produksi.
   ========================================================================== */

/* --------------------------------------------------------------------------
   Halaman Login
   -------------------------------------------------------------------------- */
function omiInitLogin() {
  const form = document.getElementById("form-login");
  if (!form) return;

  // Kalau sudah ada sesi, langsung arahkan ke halaman sesuai peran.
  const sesi = omiGetSession();
  if (sesi) {
    omiRedirectByRole(sesi.role);
    return;
  }

  const errorBox = document.getElementById("login-error");

  form.addEventListener("submit", (event) => {
    event.preventDefault();
    omiSembunyikanError(errorBox);

    const username = form.username.value.trim();
    const password = form.password.value;

    if (!username || !password) {
      omiTampilkanError(errorBox, "Username dan password wajib diisi.");
      return;
    }

    const state = omiState();
    const user = state.users.find(
      (u) =>
        (u.username.toLowerCase() === username.toLowerCase() ||
          u.email.toLowerCase() === username.toLowerCase()) &&
        u.password === password
    );

    if (!user) {
      omiTampilkanError(errorBox, "Username atau password salah. Coba akun demo di bawah.");
      return;
    }

    omiSetSession(user);
    omiRedirectByRole(user.role);
  });

  // Tombol akun demo mengisi form otomatis
  document.querySelectorAll("[data-user]").forEach((tombol) => {
    tombol.addEventListener("click", () => {
      const username = tombol.dataset.user;
      const state = omiState();
      const user = state.users.find((u) => u.username === username);
      if (!user) return;
      form.username.value = user.username;
      form.password.value = user.password;
      omiSembunyikanError(errorBox);
      form.requestSubmit();
    });
  });
}

function omiRedirectByRole(role) {
  window.location.href = OMI_BERANDA[role] || "home.html";
}

/* --------------------------------------------------------------------------
   Halaman Sign Up
   Figma frame 02: Email, Phone Number, Username, Password, Confirm Password.
   Pendaftaran hanya membuat akun peran "customer" (Pemilik Kucing).
   -------------------------------------------------------------------------- */
function omiInitSignup() {
  const form = document.getElementById("form-signup");
  if (!form) return;

  const errorBox = document.getElementById("signup-error");

  form.addEventListener("submit", (event) => {
    event.preventDefault();
    omiSembunyikanError(errorBox);

    const email = form.email.value.trim();
    const telepon = form.telepon.value.trim();
    const username = form.username.value.trim();
    const password = form.password.value;
    const konfirmasi = form.konfirmasi.value;

    // --- Validasi berurutan, pesan dibuat mudah dipahami ---
    if (!email || !telepon || !username || !password || !konfirmasi) {
      omiTampilkanError(errorBox, "Semua kolom wajib diisi.");
      return;
    }

    if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email)) {
      omiTampilkanError(errorBox, "Format email belum benar. Contoh: nama@email.com");
      return;
    }

    if (!/^[0-9+\-\s]{8,20}$/.test(telepon)) {
      omiTampilkanError(errorBox, "Nomor HP hanya boleh angka, 8–20 digit.");
      return;
    }

    if (username.length < 3) {
      omiTampilkanError(errorBox, "Username minimal 3 karakter.");
      return;
    }

    if (password.length < 6) {
      omiTampilkanError(errorBox, "Password minimal 6 karakter.");
      return;
    }

    if (password !== konfirmasi) {
      omiTampilkanError(errorBox, "Password dan konfirmasi password tidak sama.");
      return;
    }

    const state = omiState();
    const sudahAda = state.users.some(
      (u) =>
        u.username.toLowerCase() === username.toLowerCase() ||
        u.email.toLowerCase() === email.toLowerCase()
    );

    if (sudahAda) {
      omiTampilkanError(errorBox, "Username atau email sudah terdaftar. Coba yang lain.");
      return;
    }

    // --- Simpan akun baru ---
    const userBaru = {
      id: "u-" + Date.now(),
      role: "customer",
      nama: username,
      email,
      username,
      password,
      telepon,
      alamat: "",
      inisial: username.charAt(0).toUpperCase(),
    };

    omiUpdate((s) => {
      s.users.push(userBaru);
    });

    // Tampilkan konfirmasi singkat lalu masuk otomatis
    const sukses = document.getElementById("signup-success");
    if (sukses) {
      sukses.classList.remove("omi-hidden");
      sukses.textContent = "Akun berhasil dibuat. Mengarahkan ke beranda…";
    }

    setTimeout(() => {
      omiSetSession(userBaru);
      window.location.href = "home.html";
    }, 900);
  });
}

/* Catatan: omiTampilkanError() dan omiSembunyikanError() didefinisikan
   di common.js karena dipakai di banyak halaman, bukan hanya auth. */

/* --------------------------------------------------------------------------
   Auto-init sesuai halaman
   -------------------------------------------------------------------------- */
document.addEventListener("DOMContentLoaded", () => {
  omiInitLogin();
  omiInitSignup();
});
