CREATE TABLE `automod_mlog` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `date` datetime NOT NULL,
  `info` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
);

CREATE TABLE `automod_ulog` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `iduser` int(9) NOT NULL,
  `date` datetime NOT NULL,
  `info` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
);
