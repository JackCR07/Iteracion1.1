CREATE DATABASE  IF NOT EXISTS `cii` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `cii`;
-- MySQL dump 10.13  Distrib 5.6.13, for Win32 (x86)
--
-- Host: 127.0.0.1    Database: cii
-- ------------------------------------------------------
-- Server version	5.5.33

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `cii_cliente`
--

DROP TABLE IF EXISTS `cii_cliente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cii_cliente` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(30) NOT NULL,
  `Telefono1` varchar(12) NOT NULL,
  `Telefono2` varchar(12) NOT NULL,
  `Identificacion` varchar(17) NOT NULL,
  `fk_cii_usuario_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `fk_cii_usuario_id` (`fk_cii_usuario_id`),
  CONSTRAINT `fk_cii_usuario_id` FOREIGN KEY (`fk_cii_usuario_id`) REFERENCES `cii_usuario` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cii_cliente`
--

LOCK TABLES `cii_cliente` WRITE;
/*!40000 ALTER TABLE `cii_cliente` DISABLE KEYS */;
INSERT INTO `cii_cliente` VALUES (1,'Ricardo','89542748','22541212','R2013DO',1);
/*!40000 ALTER TABLE `cii_cliente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cii_contrato`
--

DROP TABLE IF EXISTS `cii_contrato`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cii_contrato` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `NombreNi√±o` varchar(40) NOT NULL,
  `Costo` float NOT NULL,
  `CII_Funcionario_ID` int(11) NOT NULL,
  `fk_cii_usuario_id` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `fk_CII_Contrato_CII_Funcionario1_idx` (`CII_Funcionario_ID`),
  KEY `cii_usuario_id` (`fk_cii_usuario_id`),
  CONSTRAINT `cii_usuario_id` FOREIGN KEY (`fk_cii_usuario_id`) REFERENCES `cii_usuario` (`ID`),
  CONSTRAINT `fk_CII_Contrato_CII_Funcionario1` FOREIGN KEY (`CII_Funcionario_ID`) REFERENCES `cii_funcionario` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cii_contrato`
--

LOCK TABLES `cii_contrato` WRITE;
/*!40000 ALTER TABLE `cii_contrato` DISABLE KEYS */;
INSERT INTO `cii_contrato` VALUES (1,'pedro',6500,1,1),(2,'juan',11000,1,1),(3,'paco',11000,2,1),(4,'Julio',6500,2,1),(5,'aeg',10000,1,1),(6,'gre',10000,2,1);
/*!40000 ALTER TABLE `cii_contrato` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cii_contratoxhorarioxservicio`
--

DROP TABLE IF EXISTS `cii_contratoxhorarioxservicio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cii_contratoxhorarioxservicio` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `FK_CII_Contrato_ID` int(11) NOT NULL,
  `FK_CII_HorarioxServicio_ID` int(11) NOT NULL,
  PRIMARY KEY (`ID`,`FK_CII_Contrato_ID`,`FK_CII_HorarioxServicio_ID`),
  KEY `fk_CII_ContratoxHorarioxServicio_CII_Contrato1_idx` (`FK_CII_Contrato_ID`),
  KEY `fk_CII_ContratoxHorarioxServicio_CII_HorarioxServicio1_idx` (`FK_CII_HorarioxServicio_ID`),
  CONSTRAINT `fk_CII_ContratoxHorarioxServicio_CII_Contrato1` FOREIGN KEY (`FK_CII_Contrato_ID`) REFERENCES `cii_contrato` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_CII_ContratoxHorarioxServicio_CII_HorarioxServicio1` FOREIGN KEY (`FK_CII_HorarioxServicio_ID`) REFERENCES `cii_horarioxservicio` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cii_contratoxhorarioxservicio`
--

LOCK TABLES `cii_contratoxhorarioxservicio` WRITE;
/*!40000 ALTER TABLE `cii_contratoxhorarioxservicio` DISABLE KEYS */;
INSERT INTO `cii_contratoxhorarioxservicio` VALUES (1,3,1),(2,3,2),(3,3,3),(4,3,4),(5,3,5),(6,4,2),(7,4,3),(8,4,4),(9,4,5),(10,4,9),(11,6,1),(12,6,10);
/*!40000 ALTER TABLE `cii_contratoxhorarioxservicio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cii_funcionario`
--

DROP TABLE IF EXISTS `cii_funcionario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cii_funcionario` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(30) NOT NULL,
  `Contrase√±a` varbinary(128) DEFAULT NULL,
  `CII_TipoFuncionario_ID` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `fk_CII_Funcionario_CII_TipoFuncionario_idx` (`CII_TipoFuncionario_ID`),
  CONSTRAINT `fk_CII_Funcionario_CII_TipoFuncionario` FOREIGN KEY (`CII_TipoFuncionario_ID`) REFERENCES `cii_tipofuncionario` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cii_funcionario`
--

LOCK TABLES `cii_funcionario` WRITE;
/*!40000 ALTER TABLE `cii_funcionario` DISABLE KEYS */;
INSERT INTO `cii_funcionario` VALUES (1,'Jack','ÿÓ∆õ-|pΩKCy∏¿+ò¡',1),(2,'Fabian','ÿÓ∆õ-|pΩKCy∏¿+ò¡',1);
/*!40000 ALTER TABLE `cii_funcionario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cii_horario`
--

DROP TABLE IF EXISTS `cii_horario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cii_horario` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Dias` varchar(50) NOT NULL,
  `HoraInicio` time NOT NULL,
  `HoraFin` time NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cii_horario`
--

LOCK TABLES `cii_horario` WRITE;
/*!40000 ALTER TABLE `cii_horario` DISABLE KEYS */;
INSERT INTO `cii_horario` VALUES (1,'L-V','06:00:00','16:30:00'),(2,'L-V','07:00:00','07:30:00'),(3,'L-V','09:00:00','09:15:00'),(4,'L-V','11:00:00','12:00:00'),(5,'L-V','15:00:00','15:15:00'),(6,'L-K','08:00:00','09:00:00'),(7,'K-M','09:30:00','10:30:00'),(8,'M-V','12:30:00','13:30:00'),(9,'L-V','14:00:00','15:00:00'),(10,'L-V','07:00:00','07:30:00');
/*!40000 ALTER TABLE `cii_horario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cii_horarioxservicio`
--

DROP TABLE IF EXISTS `cii_horarioxservicio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cii_horarioxservicio` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `FK_CII_Horario_ID` int(11) NOT NULL,
  `FK_CII_Servicio_ID` int(11) NOT NULL,
  PRIMARY KEY (`ID`,`FK_CII_Horario_ID`,`FK_CII_Servicio_ID`),
  KEY `fk_CII_HorarioxServicio_CII_Horario1_idx` (`FK_CII_Horario_ID`),
  KEY `fk_CII_HorarioxServicio_CII_Servicio1_idx` (`FK_CII_Servicio_ID`),
  CONSTRAINT `fk_CII_HorarioxServicio_CII_Horario1` FOREIGN KEY (`FK_CII_Horario_ID`) REFERENCES `cii_horario` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_CII_HorarioxServicio_CII_Servicio1` FOREIGN KEY (`FK_CII_Servicio_ID`) REFERENCES `cii_servicio` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cii_horarioxservicio`
--

LOCK TABLES `cii_horarioxservicio` WRITE;
/*!40000 ALTER TABLE `cii_horarioxservicio` DISABLE KEYS */;
INSERT INTO `cii_horarioxservicio` VALUES (1,1,1),(2,2,2),(3,3,2),(4,4,2),(5,5,2),(6,6,3),(7,7,4),(8,8,5),(9,9,6),(10,10,7);
/*!40000 ALTER TABLE `cii_horarioxservicio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cii_servicio`
--

DROP TABLE IF EXISTS `cii_servicio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cii_servicio` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(20) NOT NULL,
  `Cupo` int(11) DEFAULT NULL,
  `Costo` float NOT NULL,
  `FK_CII_TipoServicio_ID` int(11) NOT NULL,
  PRIMARY KEY (`ID`,`FK_CII_TipoServicio_ID`),
  KEY `fk_CII_Servicio_CII_TipoServicio1_idx` (`FK_CII_TipoServicio_ID`),
  CONSTRAINT `fk_CII_Servicio_CII_TipoServicio1` FOREIGN KEY (`FK_CII_TipoServicio_ID`) REFERENCES `cii_tiposervicio` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cii_servicio`
--

LOCK TABLES `cii_servicio` WRITE;
/*!40000 ALTER TABLE `cii_servicio` DISABLE KEYS */;
INSERT INTO `cii_servicio` VALUES (1,'Cuido General',NULL,6500,1),(2,'Alimentacion',NULL,4500,2),(3,'Canto',35,5000,2),(4,'Pintura',35,2500,2),(5,'Musica',35,3000,2),(6,'Deporte',NULL,2000,2),(7,'Clases',NULL,3500,2);
/*!40000 ALTER TABLE `cii_servicio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cii_tipofuncionario`
--

DROP TABLE IF EXISTS `cii_tipofuncionario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cii_tipofuncionario` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(15) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cii_tipofuncionario`
--

LOCK TABLES `cii_tipofuncionario` WRITE;
/*!40000 ALTER TABLE `cii_tipofuncionario` DISABLE KEYS */;
INSERT INTO `cii_tipofuncionario` VALUES (1,'ROOT');
/*!40000 ALTER TABLE `cii_tipofuncionario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cii_tiposervicio`
--

DROP TABLE IF EXISTS `cii_tiposervicio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cii_tiposervicio` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(12) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cii_tiposervicio`
--

LOCK TABLES `cii_tiposervicio` WRITE;
/*!40000 ALTER TABLE `cii_tiposervicio` DISABLE KEYS */;
INSERT INTO `cii_tiposervicio` VALUES (1,'Basico'),(2,'Externo');
/*!40000 ALTER TABLE `cii_tiposervicio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cii_usuario`
--

DROP TABLE IF EXISTS `cii_usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cii_usuario` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(15) NOT NULL,
  `Contrase√±a` varbinary(128) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cii_usuario`
--

LOCK TABLES `cii_usuario` WRITE;
/*!40000 ALTER TABLE `cii_usuario` DISABLE KEYS */;
INSERT INTO `cii_usuario` VALUES (1,'Ricardo','ÿÓ∆õ-|pΩKCy∏¿+ò¡');
/*!40000 ALTER TABLE `cii_usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'cii'
--
/*!50003 DROP PROCEDURE IF EXISTS `almacenarservicio` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `almacenarservicio`(IN nom varchar(20),IN cup int,IN cost float,IN dia varchar(50),IN h1 time,IN h2 time)
BEGIN
declare idh int;
declare ids int;
Insert into cii_horario(Dias,HoraInicio,HoraFin)
values (dia,h1,h2);
set idh=(SELECT LAST_INSERT_ID());
Insert into cii_servicio(Nombre,Cupo,Costo,fk_cii_tiposervicio_id)
values(nom,cup,cost,2);
set ids=(SELECT LAST_INSERT_ID());
Insert into cii_horarioxservicio(fk_cii_horario_id,fk_cii_servicio_id)
values(idh,ids);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `CostoServicio` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `CostoServicio`(in ids int,out cost float,out res bool)
BEGIN
set res=false;
set cost=(SELECT `Costo` FROM `cii`.`cii_servicio` where id=ids);
if cost is not null then
set res=true;
end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `eliminarservicio` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `eliminarservicio`(IN ids int,out res bool)
BEGIN
declare idh int;
set res=false;
set idh=(select fk_cii_horario_id from cii_horarioxservicio where fk_cii_servicio_id=ids);
if idh IS NOT NULL then
set res=true;
Delete from cii_horarioxservicio
where fk_cii_servicio_id=ids;
Delete from cii_horario
where id=idh;
Delete from cii_servicio
where id=ids;
end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `enlazarcontratohorario` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `enlazarcontratohorario`(in idc int, in ids int)
BEGIN
declare idh int;
set idh=(select fk_cii_horario_id from cii_horarioxservicio where fk_cii_servicio_id=ids limit 1);
while ids=(select fk_cii_servicio_id from cii_horarioxservicio where fk_cii_horario_id=idh) do
Insert into cii_contratoxhorarioxservicio(fk_cii_contrato_id,fk_cii_horarioxservicio_id)
values(idc,idh);
set idh=idh+1;
end while;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `ListaROOT` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `ListaROOT`()
BEGIN
Select Nombre from cii_funcionario where cii_tipofuncionario_id=1;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `listaservicios` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `listaservicios`(OUT lista varchar(10000))
BEGIN
declare ids int default 1;
declare idh int default 1;
declare nom varchar(20);
declare d varchar(50);
declare h1 time;
declare h2 time;
declare maxid int;
set lista='';
set maxid=(select max(id) from cii_servicio);
while ids<=maxid DO
set nom=(select Nombre from cii_servicio where ID=ids);
set lista=concat(lista,' ',ids,' ',nom,' ');
while ids=(select fk_cii_servicio_id from cii_horarioxservicio where fk_cii_horario_id=idh) do
set @d=(select Dias from cii_horario where id=idh);
set @h1=(select HoraInicio from cii_horario where id=idh);
set @h2=(select @h2:=HoraFin from cii_horario where id=idh);
set lista=concat(lista,' ',@d,' ',@h1,'-',@h2,' ');
set idh=idh+1;
end while;
set lista=concat(lista,'\n');
set ids=ids+1;
END WHILE;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `modificarservicio` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `modificarservicio`(IN ids int,IN cup int,IN cost float,IN dia varchar(50),IN h1 time,IN h2 time,out res bool)
BEGIN
declare idh int;
set res=false;
set idh=(select fk_cii_horario_id from cii_horarioxservicio where fk_cii_servicio_id=ids);
if idh IS NOT NULL then
set res=true;
if cup IS NOT NULL then
UPDATE cii_servicio
SET
cupo=cup
where id=ids;
end if;
if cost IS NOT NULL then
UPDATE cii_servicio
SET
costo=cost
where id=ids;
end if;
if dia IS NOT NULL then
UPDATE cii_horario
SET
dias=dia
where id=idh;
end if;
if h1 IS NOT NULL then
UPDATE cii_horario
SET
HoraInicio=h1
where id=idh;
end if;
if h2 IS NOT NULL then
UPDATE cii_horario
SET
HoraFin=h2
where id=idh;
end if;
end if;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `NuevoContrato` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `NuevoContrato`(in ni√±o varchar(40),in cost float,in funcionarioid varchar(30),in user varchar(15),out res bool, out idc int)
BEGIN
declare idf int;
declare idu int;
set res=false;
set idu=(select id from cii_usuario where nombre=user);
set idf=(select id from cii_funcionario where nombre=funcionarioid);
if idf is not null then
if idu is not null then
set res=true;
Insert into cii_contrato(nombreni√±o,costo,cii_funcionario_id,fk_cii_usuario_id)
values(ni√±o,cost,idf,idu);
set idc=(select LAST_INSERT_ID());
end if;
end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `ValidarUsuario` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `ValidarUsuario`(IN nom varchar(15), IN pass varchar(35),OUT res bool, OUT tipou varchar(15))
BEGIN
Declare temp int;
Declare idtf int; 
set res=FALSE;
set temp=(select id from CII_Funcionario where Nombre=nom and Contrase√±a=AES_ENCRYPT(pass,'supreme'));
set res=(select temp IS NOT NULL);
set idtf=(select CII_TipoFuncionario_ID from CII_Funcionario where id=temp);
set tipou=(select Nombre from CII_TipoFuncionario where id=idtf);


END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2013-09-23 15:14:07
