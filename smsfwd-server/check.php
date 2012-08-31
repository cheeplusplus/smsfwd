<?php // SMSFWD by Andrew Koester <andrew@neocodenetworks.com>

include("mysql.inc.php");

// Get input parameters
$phone = $_GET["phone"];

header("Content-type: text/xml");

print "<?xml version=\"1.0\" encoding=\"utf-8\"?>";

function dieError($message) {
	die("<smsfwd><error>".$message."</error></smsfwd>");
}

if (strlen($phone) < 5) {
	dieError("Phone number was too short.");
}

if (strlen($phone) > 11) {
	dieError("Phone number was too many characters.");
}

print "<smsfwd>\r\n";

if ($mysql["statements"]["getsms"]->execute(array($phone))) {
	$values = $mysql["statements"]["getsms"]->fetchAll();
	
	foreach ($values as $val) {
		print "\t<message from=\"".$val["From"]."\" time=\"".$val["ReceiveTime"]."\">".$val["Body"]."</message>\r\n";
		$mysql["statements"]["delsms"]->execute(array($val["MessageID"]));
	}
}

print "</smsfwd>";

?>