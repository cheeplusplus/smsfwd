<?php // SMSFWD by Andrew Koester <andrew@neocodenetworks.com>

$mysql = array("host" => "", "database" => "", "username" => "", "password" => "", "connection" => "", "statements" => array());

try {
	$mysql["connection"] = new PDO("mysql:host=".$mysql["host"].";dbname=".$mysql["database"].";", $mysql["username"], $mysql["password"]);
}
catch (PDOException $ex) {
	die("Error connecting to server.");	
}

$mysql["statements"]["addsms"] = $mysql["connection"]->prepare("INSERT INTO `messages` (`ReceiveTime`, `From`, `To`, `Body`) VALUES (?, ?, ?, ?)");
$mysql["statements"]["getsms"] = $mysql["connection"]->prepare("SELECT * FROM `messages` WHERE (`To` = ?) ORDER BY `MessageID`");
$mysql["statements"]["delsms"] = $mysql["connection"]->prepare("DELETE FROM `messages` WHERE (`MessageID` = ?)");

?>
