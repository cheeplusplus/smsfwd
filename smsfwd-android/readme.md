This is the Android client for smsfwd. It catches incoming SMS messages and sends them off to a remote server.

To make this work you'll need to change the following:

* Set the ```rawSecretKey``` in ```Crypto.java``` to match the C# version
* Set the ```_destURL``` in ```NetComm.java``` to point at ```receive.php``` from the smsfwd-server install

Uses iHarder's public domain base64 library (http://iharder.net/base64)