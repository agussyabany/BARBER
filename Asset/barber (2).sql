-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 05, 2020 at 02:17 AM
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
  `KODE` varchar(50) NOT NULL,
  `NAMA` varchar(100) NOT NULL,
  `SATUAN` varchar(20) NOT NULL,
  `KATEGORI` varchar(20) NOT NULL
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
  `IDJUAL` varchar(100) NOT NULL,
  `USERID` varchar(50) NOT NULL,
  `NOHP` varchar(100) NOT NULL,
  `TANGGAL` date NOT NULL,
  `NAMA` varchar(100) NOT NULL,
  `PEGAWAI` varchar(100) NOT NULL,
  `BIAYA` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `kategori`
--

CREATE TABLE `kategori` (
  `ID` varchar(50) NOT NULL,
  `KATEGORI` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `kategori`
--

INSERT INTO `kategori` (`ID`, `KATEGORI`) VALUES
('KT01', 'Minyak Rambut'),
('KT03', 'Shampo'),
('KT04', 'Alat Pencukur');

-- --------------------------------------------------------

--
-- Table structure for table `kopi`
--

CREATE TABLE `kopi` (
  `KODE` int(11) NOT NULL,
  `MENU` int(11) NOT NULL,
  `HARGA` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `layanan`
--

CREATE TABLE `layanan` (
  `KODE` varchar(50) NOT NULL,
  `LAYANAN` varchar(100) NOT NULL,
  `HARGA` varchar(100) NOT NULL,
  `FEE` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `pegawai`
--

CREATE TABLE `pegawai` (
  `IDCARD` varchar(50) NOT NULL,
  `NAMA` varchar(100) NOT NULL,
  `ALAMAT` varchar(100) NOT NULL,
  `JABATAN` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `pegawai`
--

INSERT INTO `pegawai` (`IDCARD`, `NAMA`, `ALAMAT`, `JABATAN`) VALUES
('21645897321564', 'Muhammad Agus Syabany', 'Jl Tirta Kencana No 1', 'ADMIN');

-- --------------------------------------------------------

--
-- Table structure for table `pelanggan`
--

CREATE TABLE `pelanggan` (
  `NOHP` varchar(100) NOT NULL,
  `NAMA` varchar(50) NOT NULL,
  `ALAMAT` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `pelanggan`
--

INSERT INTO `pelanggan` (`NOHP`, `NAMA`, `ALAMAT`) VALUES
('081349557223', 'Muhammad Agus Syabany', 'Jl Tirta Kencana No.2');

-- --------------------------------------------------------

--
-- Table structure for table `pembelian`
--

CREATE TABLE `pembelian` (
  `FAKTUR` varchar(100) NOT NULL,
  `USERID` varchar(50) NOT NULL,
  `TANGGAL` date NOT NULL,
  `SUPLIER` varchar(100) NOT NULL,
  `INVOICE` varchar(50) NOT NULL,
  `DEADLINE` date NOT NULL,
  `TOTAL` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `satuan`
--

CREATE TABLE `satuan` (
  `KODE` varchar(100) NOT NULL,
  `SATUAN` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `satuan`
--

INSERT INTO `satuan` (`KODE`, `SATUAN`) VALUES
('ST01', 'PCS'),
('ST03', 'BOTTLE'),
('ST04', 'PACK'),
('ST05', 'BUNGKUS');

-- --------------------------------------------------------

--
-- Table structure for table `suplier`
--

CREATE TABLE `suplier` (
  `KODE` varchar(100) NOT NULL,
  `NAMA` varchar(100) NOT NULL,
  `ALAMAT` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `USERID` varchar(50) NOT NULL,
  `NAMA` varchar(100) NOT NULL,
  `USERNAME` varchar(100) NOT NULL,
  `PASSWORD` varchar(100) NOT NULL,
  `LEVEL` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`USERID`, `NAMA`, `USERNAME`, `PASSWORD`, `LEVEL`) VALUES
('BB01', 'Muhammad Agus Syabany', 'muhammad', 'muhammad123', 'admin'),
('BB02', 'Agus', 'agus', 'agus123', 'ADMIN'),
('BB04', 'Dea Inrum Ristia', 'irum', 'irum1234', 'USER');

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
  ADD PRIMARY KEY (`KODE`);

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
  ADD PRIMARY KEY (`IDJUAL`),
  ADD KEY `noHp` (`NOHP`),
  ADD KEY `userID` (`USERID`);

--
-- Indexes for table `kategori`
--
ALTER TABLE `kategori`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `kopi`
--
ALTER TABLE `kopi`
  ADD PRIMARY KEY (`KODE`);

--
-- Indexes for table `layanan`
--
ALTER TABLE `layanan`
  ADD PRIMARY KEY (`KODE`);

--
-- Indexes for table `pegawai`
--
ALTER TABLE `pegawai`
  ADD PRIMARY KEY (`IDCARD`);

--
-- Indexes for table `pelanggan`
--
ALTER TABLE `pelanggan`
  ADD PRIMARY KEY (`NOHP`);

--
-- Indexes for table `pembelian`
--
ALTER TABLE `pembelian`
  ADD PRIMARY KEY (`FAKTUR`),
  ADD KEY `userID` (`USERID`);

--
-- Indexes for table `satuan`
--
ALTER TABLE `satuan`
  ADD PRIMARY KEY (`KODE`);

--
-- Indexes for table `suplier`
--
ALTER TABLE `suplier`
  ADD PRIMARY KEY (`KODE`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`USERID`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `detailbeli`
--
ALTER TABLE `detailbeli`
  ADD CONSTRAINT `detailbeli_ibfk_1` FOREIGN KEY (`faktur`) REFERENCES `pembelian` (`FAKTUR`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `detailbeli_ibfk_2` FOREIGN KEY (`kodeBar`) REFERENCES `barang` (`KODE`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `detailbeli_ibfk_3` FOREIGN KEY (`idKat`) REFERENCES `kategori` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `detailjual`
--
ALTER TABLE `detailjual`
  ADD CONSTRAINT `detailjual_ibfk_1` FOREIGN KEY (`idJual`) REFERENCES `jual` (`IDJUAL`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `detailjual_ibfk_2` FOREIGN KEY (`kodLayan`) REFERENCES `layanan` (`KODE`) ON DELETE CASCADE,
  ADD CONSTRAINT `detailjual_ibfk_3` FOREIGN KEY (`idKat`) REFERENCES `kategori` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `detailjual_ibfk_4` FOREIGN KEY (`kodBar`) REFERENCES `barang` (`KODE`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `jual`
--
ALTER TABLE `jual`
  ADD CONSTRAINT `jual_ibfk_1` FOREIGN KEY (`NOHP`) REFERENCES `pelanggan` (`NOHP`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `jual_ibfk_2` FOREIGN KEY (`USERID`) REFERENCES `user` (`USERID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `pembelian`
--
ALTER TABLE `pembelian`
  ADD CONSTRAINT `pembelian_ibfk_1` FOREIGN KEY (`USERID`) REFERENCES `user` (`USERID`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
