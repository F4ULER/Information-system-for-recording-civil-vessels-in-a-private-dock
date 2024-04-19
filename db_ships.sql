-- phpMyAdmin SQL Dump
-- version 4.9.5
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Apr 19, 2024 at 07:57 AM
-- Server version: 5.7.24
-- PHP Version: 7.4.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_ships`
--

-- --------------------------------------------------------

--
-- Table structure for table `additional_services`
--

CREATE TABLE `additional_services` (
  `id` int(11) NOT NULL,
  `board number` varchar(100) NOT NULL,
  `service` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `additional_services`
--

INSERT INTO `additional_services` (`id`, `board number`, `service`) VALUES
(1, 'АН9876', 'Мойка'),
(2, 'ОА7890', 'Ремонт'),
(3, 'РН9876', 'Ремонт'),
(4, 'ЛК5821', 'Мойка'),
(5, 'АИ4065', 'Теплое хранение'),
(6, 'ПА5231', 'Теплое хранение'),
(7, 'ПА5231', 'Мойка');

-- --------------------------------------------------------

--
-- Table structure for table `ships`
--

CREATE TABLE `ships` (
  `id` int(50) NOT NULL,
  `status` varchar(40) NOT NULL,
  `board number` varchar(100) NOT NULL,
  `owner` varchar(50) NOT NULL,
  `brand` varchar(100) NOT NULL,
  `start date` varchar(10) NOT NULL,
  `end date` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `ships`
--

INSERT INTO `ships` (`id`, `status`, `board number`, `owner`, `brand`, `start date`, `end date`) VALUES
(1, 'active', 'АЕ1234', 'Ruper', 'Кальмар', '01.11.2022', '08.05.2023'),
(2, 'requires moderation', 'РН5678', 'Devers', 'Наутилус', '05.05.2023', '09.07.2023'),
(3, 'active', 'АН9876', 'Pirus', 'Кальмар', '19.10.2022', '09.07.2023'),
(4, 'active', 'ОА7890', 'Ruper', 'Наутилус', '12.09.2022', '28.04.2023'),
(5, 'requires moderation', 'АВ7231', 'Alexandr', 'Пегас', '01.04.2023', '05.06.2023'),
(6, 'requires moderation', 'АИ4065', 'Fedor12', 'Кальмар', '23.09.2022', '25.04.2023'),
(7, 'active', 'ЛК5821', 'Gubin', 'Спрут', '07.09.2022', '01.04.2023'),
(8, 'requires moderation', 'ЛР9532', 'Pirus', 'Кальмар', '03.10.2022', '06.07.2023'),
(9, 'active', 'ОЛ7692', 'Fedor12', 'Дельта', '23.11.2022', '03.03.2023'),
(10, 'active', 'ОЛ7934', 'Alexandr', 'Кальмар', '07.10.2022', '25.07.2023'),
(11, 'requires moderation', 'РН9876', 'Pirus', 'Кальмар', '27.05.2023', '23.06.2023'),
(12, 'requires moderation', 'АР5823', 'Devers', 'Кальмар', '05.06.2023', '28.06.2023'),
(13, 'requires moderation', 'ПР5846', 'Ruper', 'Спрут', '03.04.2023', '21.07.2023'),
(14, 'requires moderation', 'РК6434', 'Alexandr', 'Кальмар', '09.03.2023', '25.07.2023'),
(15, 'active', 'ПА5231', 'Fantom', 'Спрут', '02.05.2023', '25.06.2023');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(50) UNSIGNED NOT NULL,
  `login` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  `name` varchar(100) NOT NULL,
  `phone_number` varchar(11) NOT NULL,
  `email` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `login`, `password`, `name`, `phone_number`, `email`) VALUES
(1, 'admin', 'admin', 'admin', '', ''),
(8, 'Alexandr', '27', 'Гаврилов Александр Максимович', '89040215759', 'f4uler@gmail.com'),
(2, 'Devers', '123', 'Шилов Кирилл Валентинович', '89045798486', 'Dev@gmail.com'),
(7, 'Fantom', '123', 'Карлов Юрий Петрович', '89517453123', 'Fantom1985@gmaim.com'),
(5, 'Fedor12', '1212', 'Романов Федор Петрович', '89516327419', 'Petrrom@gmaim.com'),
(6, 'Gubin', '0987', 'Губин Алексей Михайлович', '89046513749', 'Gub87@yandex.ru'),
(3, 'Pirus', '123', 'Негодин Вадим Дмитриевич', '89514763719', 'PirusNeg@gmail.com'),
(4, 'Ruper', '123', 'Горохов Евгений Михайлович', '89046248547', 'Ruper12@gmail.com');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `additional_services`
--
ALTER TABLE `additional_services`
  ADD PRIMARY KEY (`id`),
  ADD KEY `board number` (`board number`);

--
-- Indexes for table `ships`
--
ALTER TABLE `ships`
  ADD UNIQUE KEY `id` (`id`),
  ADD KEY `owner` (`owner`),
  ADD KEY `board number` (`board number`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`login`),
  ADD UNIQUE KEY `id` (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `additional_services`
--
ALTER TABLE `additional_services`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `ships`
--
ALTER TABLE `ships`
  MODIFY `id` int(50) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(50) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `additional_services`
--
ALTER TABLE `additional_services`
  ADD CONSTRAINT `additional_services_ibfk_1` FOREIGN KEY (`board number`) REFERENCES `ships` (`board number`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `ships`
--
ALTER TABLE `ships`
  ADD CONSTRAINT `ships_ibfk_1` FOREIGN KEY (`owner`) REFERENCES `users` (`login`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
