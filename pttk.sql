CREATE DATABASE  IF NOT EXISTS `quanlyquancafe` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `quanlyquancafe`;
-- MySQL dump 10.13  Distrib 8.0.42, for Win64 (x86_64)
--
-- Host: localhost    Database: quanlyquancafe
-- ------------------------------------------------------
-- Server version	8.0.42

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `ban`
--

DROP TABLE IF EXISTS `ban`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ban` (
  `SoBan` int NOT NULL,
  `TrangThai` varchar(20) NOT NULL DEFAULT 'Trong',
  PRIMARY KEY (`SoBan`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ban`
--

LOCK TABLES `ban` WRITE;
/*!40000 ALTER TABLE `ban` DISABLE KEYS */;
INSERT INTO `ban` VALUES (1,'Trong'),(2,'Trong'),(3,'Trong'),(4,'Trong'),(5,'Trong'),(6,'Trong'),(7,'Trong'),(8,'Trong'),(9,'Trong'),(10,'Trong'),(11,'Trong'),(12,'Trong'),(13,'Trong'),(14,'Trong');
/*!40000 ALTER TABLE `ban` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `chitiethoadon`
--

DROP TABLE IF EXISTS `chitiethoadon`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `chitiethoadon` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `MaHD` varchar(10) DEFAULT NULL,
  `MaSP` varchar(10) DEFAULT NULL,
  `TenSP` varchar(100) DEFAULT NULL,
  `SoLuong` int NOT NULL,
  `DonGia` int NOT NULL,
  `ThanhTien` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `MaHD` (`MaHD`),
  CONSTRAINT `chitiethoadon_ibfk_1` FOREIGN KEY (`MaHD`) REFERENCES `hoadon` (`MaHD`)
) ENGINE=InnoDB AUTO_INCREMENT=103 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `chitiethoadon`
--

LOCK TABLES `chitiethoadon` WRITE;
/*!40000 ALTER TABLE `chitiethoadon` DISABLE KEYS */;
INSERT INTO `chitiethoadon` VALUES (1,'HD001','DU001','Cà phê đen',2,20000,40000),(2,'HD001','DA001','Bánh mì thịt',1,35000,35000),(3,'HD001','CB001','Combo sáng',1,65000,58500),(4,'HD002','DU007','Matcha latte',1,96000,96000),(5,'HD002','DA010','Bánh kem',1,120000,120000),(6,'HD002','CB005','Combo best friend',1,200000,180000),(7,'HD003','DU004','Trà xanh',3,22000,66000),(8,'HD003','DA009','Xôi xéo',2,25000,50000),(9,'HD004','DU002','Cà phê sữa',1,50000,50000),(10,'HD004','DA006','Cơm gà xối mỡ',1,60000,60000),(11,'HD004','CB002','Combo trưa',1,78000,70200),(12,'HD005','DU005','Capuchino',2,70000,140000),(13,'HD005','DA008','Gà rán',1,65000,65000),(14,'HD005','DU006','Espresso',1,18000,18000),(15,'HD006','DU009','Trà sữa trân châu',1,56000,56000),(16,'HD006','DA004','Bánh cuốn',1,32000,32000),(17,'HD006','DU008','Soda chanh',1,24000,24000),(18,'HD007','CB003','Combo tối',1,89000,80100),(19,'HD007','DU010','Nước cam ép',1,78000,78000),(20,'HD007','DA007','Khoai tây chiên',1,40000,40000),(21,'HD008','DU003','Trà đào',1,90000,90000),(22,'HD008','DA005','Mì xào bò',1,55000,55000),(23,'HD008','DU001','Cà phê đen',2,20000,40000),(24,'HD009','CB004','Combo gia đình',1,125000,112500),(25,'HD009','DU007','Matcha latte',1,96000,96000),(26,'HD009','DA003','Bún chả',1,45000,45000),(27,'HD009','DA001','Bánh mì thịt',1,35000,35000),(28,'HD010','CB005','Combo best friend',1,200000,180000),(29,'HD010','DU002','Cà phê sữa',2,50000,100000),(30,'HD010','DA010','Bánh kem',1,120000,120000),(31,'HD010','DU006','Espresso',2,18000,36000),(32,'HD011','DU002','Cà phê sữa',2,50000,100000),(33,'HD011','DA001','Bánh mì thịt',1,35000,35000),(34,'HD011','CB001','Combo sáng',1,65000,58500),(35,'HD012','DU005','Capuchino',1,70000,70000),(36,'HD012','DA006','Cơm gà xối mỡ',1,60000,60000),(37,'HD012','DU008','Soda chanh',2,24000,48000),(38,'HD013','DU003','Trà đào',1,90000,90000),(39,'HD013','DA010','Bánh kem',1,120000,120000),(40,'HD013','CB002','Combo trưa',1,78000,70200),(41,'HD014','DU001','Cà phê đen',3,20000,60000),(42,'HD014','DA009','Xôi xéo',2,25000,50000),(43,'HD014','DU006','Espresso',1,18000,18000),(44,'HD015','DU007','Matcha latte',1,96000,96000),(45,'HD015','DA008','Gà rán',1,65000,65000),(46,'HD015','CB003','Combo tối',1,89000,80100),(47,'HD015','DA004','Bánh cuốn',1,32000,32000),(48,'HD016','DU009','Trà sữa trân châu',2,56000,112000),(49,'HD016','DA005','Mì xào bò',1,55000,55000),(50,'HD016','DU004','Trà xanh',1,22000,22000),(51,'HD017','CB004','Combo gia đình',1,125000,112500),(52,'HD017','DU010','Nước cam ép',1,78000,78000),(53,'HD017','DA007','Khoai tây chiên',1,40000,40000),(54,'HD018','DU002','Cà phê sữa',1,50000,50000),(55,'HD018','DU008','Soda chanh',2,24000,48000),(56,'HD018','DA001','Bánh mì thịt',2,35000,70000),(57,'HD018','DA009','Xôi xéo',1,25000,25000),(58,'HD019','CB005','Combo best friend',1,200000,180000),(59,'HD019','DU005','Capuchino',1,70000,70000),(60,'HD019','DA003','Bún chả',1,45000,45000),(61,'HD020','DU003','Trà đào',2,90000,180000),(62,'HD020','DA010','Bánh kem',1,120000,120000),(63,'HD020','DA006','Cơm gà xối mỡ',1,60000,60000),(64,'HD020','DU006','Espresso',2,18000,36000),(65,'HD021','DU001','Cà phê đen',2,20000,40000),(66,'HD021','DA001','Bánh mì thịt',1,35000,35000),(67,'HD021','CB001','Combo sáng',1,65000,58500),(68,'HD022','DU005','Capuchino',2,70000,140000),(69,'HD022','DA006','Cơm gà xối mỡ',1,60000,60000),(70,'HD022','CB002','Combo trưa',1,78000,70200),(71,'HD023','DU009','Trà sữa trân châu',3,56000,168000),(72,'HD023','DA008','Gà rán',2,65000,130000),(73,'HD023','CB003','Combo tối',1,89000,80100),(74,'HD024','DU002','Cà phê sữa',1,50000,50000),(75,'HD024','DU004','Trà xanh',2,22000,44000),(76,'HD024','DA009','Xôi xéo',2,25000,50000),(77,'HD024','DA004','Bánh cuốn',1,32000,32000),(78,'HD025','DU003','Trà đào',1,90000,90000),(79,'HD025','DA005','Mì xào bò',1,55000,55000),(80,'HD025','CB004','Combo gia đình',1,125000,112500),(81,'HD026','DU006','Espresso',4,18000,72000),(82,'HD026','DA007','Khoai tây chiên',2,40000,80000),(83,'HD026','DA001','Bánh mì thịt',1,35000,35000),(84,'HD027','DU010','Nước cam ép',1,78000,78000),(85,'HD027','DA010','Bánh kem',1,120000,120000),(86,'HD027','CB005','Combo best friend',1,200000,180000),(87,'HD028','DU008','Soda chanh',3,24000,72000),(88,'HD028','DU004','Trà xanh',1,22000,22000),(89,'HD028','DA003','Bún chả',2,45000,90000),(90,'HD029','DU007','Matcha latte',1,96000,96000),(91,'HD029','DA006','Cơm gà xối mỡ',1,60000,60000),(92,'HD029','CB001','Combo sáng',2,65000,117000),(93,'HD029','DA009','Xôi xéo',1,25000,25000),(94,'HD030','DU001','Cà phê đen',1,20000,20000),(95,'HD030','DU002','Cà phê sữa',2,50000,100000),(96,'HD030','DA008','Gà rán',1,65000,65000),(97,'HD030','CB002','Combo trưa',1,78000,70200),(98,'HD031','DA008','Gà rán',4,65000,260000),(99,'HD031','DA009','Xôi xéo',2,25000,50000),(100,'HD032','DU025','Trà sữa sầu riêng',2,140000,280000),(101,'HD033','CB003','Combo tối',2,89000,160200),(102,'HD034','CB001','Combo sáng',2,65000,117000);
/*!40000 ALTER TABLE `chitiethoadon` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `hoadon`
--

DROP TABLE IF EXISTS `hoadon`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `hoadon` (
  `MaHD` varchar(10) NOT NULL,
  `NgayGioThang` datetime NOT NULL,
  `SoBan` int NOT NULL,
  `MaNV` varchar(10) DEFAULT NULL,
  `TrangThai` varchar(20) NOT NULL DEFAULT 'Chua thanh toan',
  PRIMARY KEY (`MaHD`),
  KEY `MaNV` (`MaNV`),
  CONSTRAINT `hoadon_ibfk_1` FOREIGN KEY (`MaNV`) REFERENCES `nhanvien` (`MaNV`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `hoadon`
--

LOCK TABLES `hoadon` WRITE;
/*!40000 ALTER TABLE `hoadon` DISABLE KEYS */;
INSERT INTO `hoadon` VALUES ('HD001','2024-01-08 08:30:00',5,'NV001','Da thanh toan'),('HD002','2024-02-14 18:15:00',12,'NV002','Da thanh toan'),('HD003','2024-03-30 09:50:00',3,'NV001','Da thanh toan'),('HD004','2024-05-01 10:00:00',6,'NV002','Da thanh toan'),('HD005','2024-05-01 10:45:00',11,'NV001','Da thanh toan'),('HD006','2024-07-19 15:30:00',2,'NV002','Da thanh toan'),('HD007','2024-08-25 13:20:00',7,'NV001','Da thanh toan'),('HD008','2024-10-10 09:15:00',4,'NV002','Da thanh toan'),('HD009','2024-10-10 19:50:00',9,'NV001','Da thanh toan'),('HD010','2024-12-31 23:00:00',1,'NV002','Da thanh toan'),('HD011','2025-01-15 08:20:00',3,'NV001','Da thanh toan'),('HD012','2025-02-10 09:40:00',5,'NV002','Da thanh toan'),('HD013','2025-03-22 12:15:00',2,'NV001','Da thanh toan'),('HD014','2025-04-18 10:05:00',7,'NV002','Da thanh toan'),('HD015','2025-04-18 10:30:00',4,'NV001','Da thanh toan'),('HD016','2025-06-05 14:00:00',9,'NV002','Da thanh toan'),('HD017','2025-07-14 16:45:00',1,'NV001','Da thanh toan'),('HD018','2025-09-02 11:10:00',6,'NV002','Da thanh toan'),('HD019','2025-11-20 19:20:00',10,'NV001','Da thanh toan'),('HD020','2025-12-24 20:00:00',8,'NV002','Da thanh toan'),('HD021','2026-08-25 08:15:00',3,'NV001','Da thanh toan'),('HD022','2026-08-25 09:30:00',7,'NV002','Da thanh toan'),('HD023','2026-08-26 10:45:00',2,'NV001','Da thanh toan'),('HD024','2026-08-26 12:00:00',5,'NV002','Da thanh toan'),('HD025','2026-08-27 13:15:00',9,'NV001','Da thanh toan'),('HD026','2026-08-27 14:30:00',4,'NV002','Da thanh toan'),('HD027','2026-08-28 09:00:00',1,'NV001','Da thanh toan'),('HD028','2026-08-28 11:20:00',6,'NV002','Da thanh toan'),('HD029','2026-08-29 15:45:00',10,'NV001','Da thanh toan'),('HD030','2026-08-29 18:10:00',8,'NV002','Da thanh toan'),('HD031','2026-08-31 13:10:00',11,'NV001','Da thanh toan'),('HD032','2026-08-31 13:14:00',12,'NV002','Da thanh toan'),('HD033','2026-09-09 13:59:42',7,'NV001','Da thanh toan'),('HD034','2026-09-29 07:52:30',10,'NV001','Da thanh toan');
/*!40000 ALTER TABLE `hoadon` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `nhanvien`
--

DROP TABLE IF EXISTS `nhanvien`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `nhanvien` (
  `MaNV` varchar(10) NOT NULL,
  `TenNV` varchar(100) NOT NULL,
  `MatKhau` varchar(100) NOT NULL,
  `ChucVu` varchar(20) NOT NULL DEFAULT 'Nhan vien',
  PRIMARY KEY (`MaNV`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `nhanvien`
--

LOCK TABLES `nhanvien` WRITE;
/*!40000 ALTER TABLE `nhanvien` DISABLE KEYS */;
INSERT INTO `nhanvien` VALUES ('NV001','Ngô Kiều Đình Trung','131106','Quan ly'),('NV002','Hồ Nguyễn Quỳnh Như','140806','Nhan vien');
/*!40000 ALTER TABLE `nhanvien` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sanpham`
--

DROP TABLE IF EXISTS `sanpham`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sanpham` (
  `MaSP` varchar(10) NOT NULL,
  `Loai` varchar(10) NOT NULL,
  `TenSP` varchar(100) NOT NULL,
  `GiaGoc` int NOT NULL,
  `ThuocTinhRieng` varchar(20) DEFAULT NULL,
  `SoLuongTon` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`MaSP`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sanpham`
--

LOCK TABLES `sanpham` WRITE;
/*!40000 ALTER TABLE `sanpham` DISABLE KEYS */;
INSERT INTO `sanpham` VALUES ('CB001','Combo','Combo sáng',65000,'10',19),('CB002','Combo','Combo trưa',80000,'10',20),('CB003','Combo','Combo tối',89000,'10',13),('CB004','Combo','Combo gia đình',125000,'10',10),('CB005','Combo','Combo best friend',200000,'10',10),('DA001','DoAn','Bánh mì thịt',35000,'False',30),('DA002','DoAn','Bánh mì chả',30000,'False',30),('DA003','DoAn','Bún chả',45000,'True',20),('DA004','DoAn','Bánh cuốn',32000,'True',20),('DA005','DoAn','Mì xào bò',55000,'False',20),('DA006','DoAn','Cơm gà xối mỡ',60000,'True',20),('DA007','DoAn','Khoai tây chiên',40000,'False',30),('DA008','DoAn','Gà rán',65000,'True',25),('DA009','DoAn','Xôi xéo',25000,'False',25),('DA010','DoAn','Bánh kem',120000,'False',15),('DU001','DoUong','Cà phê đen',20000,'S',50),('DU002','DoUong','Cà phê sữa',25000,'M',50),('DU003','DoUong','Trà đào',30000,'L',40),('DU004','DoUong','Trà xanh',22000,'S',40),('DU005','DoUong','Capuchino',35000,'M',30),('DU006','DoUong','Espresso',18000,'S',30),('DU007','DoUong','Matcha latte',32000,'L',30),('DU008','DoUong','Soda chanh',24000,'S',40),('DU009','DoUong','Trà sữa trân châu',28000,'M',40),('DU010','DoUong','Nước cam ép',26000,'L',30),('DU027','DoUong','OOLongTeaPlus',12000,'M',11);
/*!40000 ALTER TABLE `sanpham` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-09-30  7:20:20
