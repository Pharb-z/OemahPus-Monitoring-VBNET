-- Jalankan sekali kalau database sudah ter-import dari backup_OMIDB_1.sql
-- sebelum hash staf01 / driver01 diperbaiki.
-- Password: staf01 = staf123, driver01 = driver123.

USE `omidb`;

UPDATE `users`
SET `password_hash` = '$2a$11$OnZen6UTcsRayPjkNc6m3uKnVqhlPHjnNOP23NuW797d4UCkoFwG2'
WHERE `username` = 'staf01';

UPDATE `users`
SET `password_hash` = '$2a$11$mLzI.r2ibVXDrJeRQEpFUOAQWiu1kt2vUh8C/PT0tYkMb/nYwmhRy'
WHERE `username` = 'driver01';
