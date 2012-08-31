<?php // SMSFWD by Andrew Koester <andrew@neocodenetworks.com>

include("mysql.inc.php");

// Get input parameters
$time = $_GET["time"];
$fromname = $_GET["fromname"];
$from = $_GET["from"];
$to = $_GET["to"];
$body = $_GET["body"];

// Process security
if (strlen($time) < 9) {
	die("Time was too short.");
}

if ((!is_numeric($time)) || ((int)$time != $time)) {
	die("Time is not a number.");	
}

if (strlen($from) < 5) {
	die("From was too short.");	
}

if (strlen($from) > 11) {
	die("From was too many characters.");
}

if (strlen($to) < 5) {
	die("To was too short.");	
}

if (strlen($to) > 11) {
	die("To was too many characters.");	
}

if (strlen($body) < 1) {
	die("No body found.");	
}

$b64 = base64_decode($body);
if (strlen($b64) < 1) {
	die("Invalid body content.");	
}

// Add the SMS
if ($mysql["statements"]["addsms"]->execute(array($time, $from, $to, $body))) {
	die("Success");
}

die("Failure");

?>