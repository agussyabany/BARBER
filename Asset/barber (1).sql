-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Aug 30, 2020 at 02:16 AM
-- Server version: 10.4.6-MariaDB
-- PHP Version: 7.3.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `barber`
--

-- --------------------------------------------------------

--
-- Table structure for table `akun`
--

CREATE TABLE `akun` (
  `idAkun` varchar(50) NOT NULL,
  `katAkun` varchar(100) NOT NULL,
  `namAkun` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `barang`
--

CREATE TABLE `barang` (
  `kodeBar` varchar(50) NOT NULL,
  `namBar` varchar(100) NOT NULL,
  `satuan` varchar(20) NOT NULL,
  `kat` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `detailbeli`
--

CREATE TABLE `detailbeli` (
  `faktur` varchar(100) NOT NULL,
  `kodeBar` varchar(50) NOT NULL,
  `idKat` varchar(50) NOT NULL,
  `merk` varchar(100) NOT NULL,
  `jumlah` varchar(50) NOT NULL,
  `harga` varchar(100) NOT NULL,
  `expTgl` date NOT NULL,
  `harga1` varchar(100) NOT NULL,
  `harga2` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `detailjual`
--

CREATE TABLE `detailjual` (
  `idJual` varchar(100) NOT NULL,
  `kodLayan` varchar(50) NOT NULL,
  `kodBar` varchar(50) NOT NULL,
  `idKat` varchar(50) NOT NULL,
  `jumLay` int(100) NOT NULL,
  `biaya` int(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `jual`
--

CREATE TABLE `jual` (
  `idJual` varchar(100) NOT NULL,
  `userID` varchar(50) NOT NULL,
  `noHp` varchar(100) NOT NULL,
  `tgl` date NOT NULL,
  `namPel` varchar(100) NOT NULL,
  `petugas` varchar(100) NOT NULL,
  `totalBiaya` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `kategori`
--

CREATE TABLE `kategori` (
  `idKat` varchar(50) NOT NULL,
  `kategori` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `kopi`
--

CREATE TABLE `kopi` (
  `kodeKop` int(11) NOT NULL,
  `manu` int(11) NOT NULL,
  `harga` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `layanan`
--

CREATE TABLE `layanan` (
  `kodLayan` varchar(50) NOT NULL,
  `layanan` varchar(100) NOT NULL,
  `harga` varchar(100) NOT NULL,
  `fee` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `pegawai`
--

CREATE TABLE `pegawai` (
  `pegID` varchar(50) NOT NULL,
  `namPeg` varchar(100) NOT NULL,
  `Idcard` varchar(100) NOT NULL,
  `alamat` varchar(100) NOT NULL,
  `noHP` varchar(100) NOT NULL,
  `jabatan` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `pelanggan`
--

CREATE TABLE `pelanggan` (
  `noHp` varchar(100) NOT NULL,
  `namPel` varchar(50) NOT NULL,
  `alamat` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `pembelian`
--

CREATE TABLE `pembelian` (
  `faktur` varchar(100) NOT NULL,
  `userID` varchar(50) NOT NULL,
  `tgl` date NOT NULL,
  `suplier` varchar(100) NOT NULL,
  `hutangC` varchar(50) NOT NULL,
  `tglTemp` date NOT NULL,
  `totalBeli` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `satuan`
--

CREATE TABLE `satuan` (
  `kodeSAT` varchar(100) NOT NULL,
  `satuan` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `suplier`
--

CREATE TABLE `suplier` (
  `kodeSup` varchar(100) NOT NULL,
  `namaSup` varchar(100) NOT NULL,
  `alamat` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `userID` varchar(50) NOT NULL,
  `namPeg` varchar(100) NOT NULL,
  `user` varchar(100) NOT NULL,
  `pass` varchar(100) NOT NULL,
  `level` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`userID`, `namPeg`, `user`, `pass`, `level`) VALUES
('BB01', 'Muhammad Agus Syabany', 'agus', 'agus123', '1');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `akun`
--
ALTER TABLE `akun`
  ADD PRIMARY KEY (`idAkun`);

--
-- Indexes for table `barang`
--
ALTER TABLE `barang`
  ADD PRIMARY KEY (`kodeBar`);

--
-- Indexes for table `detailbeli`
--
ALTER TABLE `detailbeli`
  ADD KEY `faktur` (`faktur`),
  ADD KEY `faktur_2` (`faktur`),
  ADD KEY `idKat` (`idKat`),
  ADD KEY `kodeBar` (`kodeBar`);

--
-- Indexes for table `detailjual`
--
ALTER TABLE `detailjual`
  ADD KEY `idJual` (`idJual`),
  ADD KEY `kodLayan` (`kodLayan`),
  ADD KEY `idKat` (`idKat`),
  ADD KEY `kodBar` (`kodBar`);

--
-- Indexes for table `jual`
--
ALTER TABLE `jual`
  ADD PRIMARY KEY (`idJual`),
  ADD KEY `noHp` (`noHp`),
  ADD KEY `userID` (`userID`);

--
-- Indexes for table `kategori`
--
ALTER TABLE `kategori`
  ADD PRIMARY KEY (`idKat`);

--
-- Indexes for table `kopi`
--
ALTER TABLE `kopi`
  ADD PRIMARY KEY (`kodeKop`);

--
-- Indexes for table `layanan`
--
ALTER TABLE `layanan`
  ADD PRIMARY KEY (`kodLayan`);

--
-- Indexes for table `pegawai`
--
ALTER TABLE `pegawai`
  ADD PRIMARY KEY (`pegID`);

--
-- Indexes for table `pelanggan`
--
ALTER TABLE `pelanggan`
  ADD PRIMARY KEY (`noHp`);

--
-- Indexes for table `pembelian`
--
ALTER TABLE `pembelian`
  ADD PRIMARY KEY (`faktur`),
  ADD KEY `userID` (`userID`);

--
-- Indexes for table `satuan`
--
ALTER TABLE `satuan`
  ADD PRIMARY KEY (`kodeSAT`);

--
-- Indexes for table `suplier`
--
ALTER TABLE `suplier`
  ADD PRIMARY KEY (`kodeSup`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`userID`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `detailbeli`
--
ALTER TABLE `detailbeli`
  ADD CONSTRAINT `detailbeli_ibfk_1` FOREIGN KEY (`faktur`) REFERENCES `pembelian` (`faktur`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `detailbeli_ibfk_2` FOREIGN KEY (`kodeBar`) REFERENCES `barang` (`kodeBar`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `detailbeli_ibfk_3` FOREIGN KEY (`idKat`) REFERENCES `kategori` (`idKat`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `detailjual`
--
ALTER TABLE `detailjual`
  ADD CONSTRAINT `detailjual_ibfk_1` FOREIGN KEY (`idJual`) REFERENCES `jual` (`idJual`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `detailjual_ibfk_2` FOREIGN KEY (`kodLayan`) REFERENCES `layanan` (`kodLayan`) ON DELETE CASCADE,
  ADD CONSTRAINT `detailjual_ibfk_3` FOREIGN KEY (`idKat`) REFERENCES `kategori` (`idKat`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `detailjual_ibfk_4` FOREIGN KEY (`kodBar`) REFERENCES `barang` (`kodeBar`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `jual`
--
ALTER TABLE `jual`
  ADD CONSTRAINT `jual_ibfk_1` FOREIGN KEY (`noHp`) REFERENCES `pelanggan` (`noHp`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `jual_ibfk_2` FOREIGN KEY (`userID`) REFERENCES `user` (`userID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `pembelian`
--
ALTER TABLE `pembelian`
  ADD CONSTRAINT `pembelian_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `user` (`userID`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
