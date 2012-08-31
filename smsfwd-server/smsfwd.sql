CREATE TABLE IF NOT EXISTS `messages` (
  `MessageID` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` int(11) NOT NULL,
  `ReceiveTime` int(11) NOT NULL,
  `From` varchar(20) NOT NULL,
  `To` varchar(20) NOT NULL,
  `Body` text NOT NULL,
  PRIMARY KEY (`MessageID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;