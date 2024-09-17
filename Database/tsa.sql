-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Jan 07, 2023 at 09:44 PM
-- Server version: 5.7.36
-- PHP Version: 7.4.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `tsa`
--

-- --------------------------------------------------------

--
-- Table structure for table `customers`
--

DROP TABLE IF EXISTS `customers`;
CREATE TABLE IF NOT EXISTS `customers` (
  `InvoiceID` int(20) NOT NULL AUTO_INCREMENT,
  `Name` varchar(20) NOT NULL,
  `Surname` varchar(20) NOT NULL,
  `Gender` varchar(20) DEFAULT NULL,
  `Nationality` varchar(50) DEFAULT NULL,
  `PhoneNumber` int(20) DEFAULT NULL,
  PRIMARY KEY (`InvoiceID`),
  KEY `InvoiceID_fk` (`InvoiceID`)
) ENGINE=MyISAM AUTO_INCREMENT=2491894 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `customers`
--

INSERT INTO `customers` (`InvoiceID`, `Name`, `Surname`, `Gender`, `Nationality`, `PhoneNumber`) VALUES
(2491861, 'Ahme', 'Avci', 'Male', 'Istanbul', 0),
(2491860, 'Kerem', 'Aslan', 'Male', 'Adana', 0),
(2491891, 'Eylul', 'Aydin', 'female', 'Cypriot', 0),
(2491893, 'Zehra', 'Ozkurt', 'female', 'Turkey', 0),
(2491892, 'Zehra', 'Ozkurt', 'Female', 'Turkey', 0),
(2491890, 'Naser ', 'Aga', 'Male', 'Turkey', 0),
(2491889, 'Mehmet', 'Can', 'Male', 'Turkey', 0),
(2491888, 'Selis', 'Oglu', 'Female', 'Turkey', 0),
(2491887, 'Ahmet', 'Can', 'Male', 'Cypriot', 0),
(2491886, 'Fatma', 'Arslan', 'Male', 'Turkey', 0),
(2491885, 'Ersan', 'Oglu', 'Male', 'Cypriot', 0),
(2491884, 'Eylul', 'Aydin', 'Female', 'Cypriot', 0),
(2491883, 'Yusuf', 'Aydeniz', 'male', 'Adana', 0),
(2491882, 'Mert', 'Can', 'male', 'Cypriot', 0);

-- --------------------------------------------------------

--
-- Table structure for table `employees`
--

DROP TABLE IF EXISTS `employees`;
CREATE TABLE IF NOT EXISTS `employees` (
  `EmployeeID` int(10) NOT NULL AUTO_INCREMENT,
  `UserType` varchar(20) NOT NULL DEFAULT 'user',
  `Name` varchar(20) NOT NULL,
  `Surname` varchar(20) NOT NULL,
  `Departement` varchar(20) NOT NULL,
  `Email` varchar(20) NOT NULL,
  `Password` varchar(200) NOT NULL,
  PRIMARY KEY (`EmployeeID`)
) ENGINE=MyISAM AUTO_INCREMENT=220239 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `employees`
--

INSERT INTO `employees` (`EmployeeID`, `UserType`, `Name`, `Surname`, `Departement`, `Email`, `Password`) VALUES
(220220, 'User', 'Admin', 'Admin', 'Software Manager', 'Admin@linasoft.com', 'Admin'),
(220231, 'user', 'Celine', 'Oglu', 'Accountant', 'CO@linasoft.com', 'edad44b7328782dce8ab554496d8a359'),
(220221, 'User', 'Saidan', 'Polat', 'Egitim', 'SP@linasoft.com', '0B70D308F0090DC0F90D50370BB0580F804E00800302B0F00080D40280210C202503000609609D0A50610860980B90BA'),
(220222, 'User', 'Yusuf', 'Bey', 'Egitim', 'YB@linasoft.com', '0DD02E0D10D80500600CD08B06404804003D0E901E0AA0F60C80620220D00BA09204E0FF06806B0A705B0DC067026089'),
(220223, 'User', 'Elif', 'Bay', 'Accountant', 'EB@linasoft.com', '04002A0930A90B10A00AB07803E0070B000401E0B908D08E0E70560100F405A0C30D904B06B0110EB04B0480DA0BE04D'),
(220224, 'User', 'Eylul', 'Aydin', 'Accountant', 'EA@linasoft.com', '00A0A305205E0590EF06A0EE00903109104A08101C0700CF0770A60990C80050C60DD00006E0530670750CA08A09E0C5'),
(220225, 'admin', '', '', '', '', '098f6bcd4621d373cade4e832627b4f6'),
(220226, 'user', 'Celine', 'Paris', 'IT', 'Celine@linasoft.com', '512e75b64be8625c77c37064e1231ccd'),
(220227, 'user', 'Yusuf', 'kazim', 'SE', 'YK@linasoft.com', '7ca28712ca156fd52f252cd22791fd40'),
(220228, 'user', 'h', 'vdaf', 'vdf', 'dfv@gd.gdf', '098f6bcd4621d373cade4e832627b4f6'),
(220229, 'user', 'hss', 'Paris', 'vdf', 'YK@linasoft.com', '098f6bcd4621d373cade4e832627b4f6'),
(220230, 'admin', 'admin', 'NA', 'NA', 'Admin@linasoft.com', '21232f297a57a5a743894a0e4a801fc3'),
(220232, 'user', 'Hash', 'Hash', 'IT', 'Hash@linasoft', '0A901006901407F09B0D902405C0DA0CA0EF08E0AD04C0350780ED0440F10790D70EB06B0D406900E0620BA0460580F2'),
(220233, 'user', 'Saidan', 'Polat', 'test', 'test@linasoft.com', '098f6bcd4621d373cade4e832627b4f6'),
(220234, 'user', 'Hash', 'Kay', 'IT', 'Hash@linasoft.com', 'qfVVl320tY'),
(220235, 'User', 'test', 'test', 'test', 'test', '09F0860D008108804C07D06509A02F0EA0A00C505A0D00150A30BF04F01B02B00B08202C0D105D06C0150B00F000A008'),
(220236, 'Admin', 'test', 'test', 'test', 'test', '09F0860D008108804C07D06509A02F0EA0A00C505A0D00150A30BF04F01B02B00B08202C0D105D06C0150B00F000A008'),
(220237, 'User', 'test', 'test', 'test', 'test', '09F0860D008108804C07D06509A02F0EA0A00C505A0D00150A30BF04F01B02B00B08202C0D105D06C0150B00F000A008'),
(220238, '', 'test', 'test', 'test', 'test@linasoft.com', '09F0860D008108804C07D06509A02F0EA0A00C505A0D00150A30BF04F01B02B00B08202C0D105D06C0150B00F000A008');

-- --------------------------------------------------------

--
-- Table structure for table `invoice_activity`
--

DROP TABLE IF EXISTS `invoice_activity`;
CREATE TABLE IF NOT EXISTS `invoice_activity` (
  `InvoiceID` int(10) NOT NULL AUTO_INCREMENT,
  `EmployeeID` int(10) NOT NULL,
  `InvoiceType` varchar(50) NOT NULL,
  `Status` varchar(50) NOT NULL,
  `Date` varchar(50) DEFAULT NULL,
  `Comment` varchar(100) NOT NULL,
  PRIMARY KEY (`InvoiceID`),
  KEY `InvoiceID` (`InvoiceID`)
) ENGINE=MyISAM AUTO_INCREMENT=2491894 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `invoice_activity`
--

INSERT INTO `invoice_activity` (`InvoiceID`, `EmployeeID`, `InvoiceType`, `Status`, `Date`, `Comment`) VALUES
(2491890, 220224, 'Report', 'Verified', 'Thursday, December 8, 2022', 'Bug problem has been solved'),
(2491889, 220224, 'Report', 'Verified', 'Thursday, December 8, 2022', 'Error problem has been solved'),
(2491888, 220223, 'Request', 'Verified', 'Tuesday, December 13, 2022', 'New client request done '),
(2491861, 220221, 'Request', 'Pending', '2022-12-14', 'Software Management'),
(2491860, 220222, 'Report', 'Cancelled', 'Tuesday, December 6, 2022', 'Remote Connection'),
(2491887, 220222, 'Report', 'Cancelled', 'Sunday, December 18, 2022', 'Missed appointement with Ahmet Can'),
(2491886, 220222, 'Request', 'Verified', 'Thursday, December 15, 2022', 'Call request has been done '),
(2491884, 220220, 'Request', 'Pending', 'Thursday, December 15, 2022', 'Request a new software feature'),
(2491885, 220221, 'Education', 'Pending', 'Friday, December 16, 2022', 'Training to use the software'),
(2491883, 220221, 'Request', 'Pending', '2022-12-14', 'Software Management'),
(2491882, 220220, 'Training', 'Verified', '2022-12-14', 'Software usage'),
(2491891, 220220, 'Request', 'Pending', '2022-12-15', 'Request a new software feature'),
(2491892, 220220, 'Education', 'Pending', 'Wednesday, December 14, 2022', 'Software Training'),
(2491893, 220220, 'Training', 'Verified', '2022-12-15', 'Software Training');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
