This is the Windows smsfwd client, written in C#.

To make this work you'll need to change the following:

* Set the ```rawSecretKey``` in ```Crypto.cs``` to match the Android version
* Set the ```_remoteURL``` in ```SmsFwdComm.cs``` to point at ```check.php``` from the smsfwd-server install