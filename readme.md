This is a dead project that I wrote before DeskSMS (https://play.google.com/store/apps/details?id=com.koushikdutta.desktopsms) came out.
It takes SMS messages sent to your Android phone, encrypts them, and sends them to a server, to be retrieved later by a client.

It consists of three parts:

* smsfwd-android: Android client that reads SMS messages and encrypts them before sending to a server
* smsfwd-server: PHP (I'm sorry) scripts that use mySQL (sorry again) to store and retrieve the messages
* smsfwd-windows-client: Windows client that retrieves messages from the server and decrypts them

There are a few places with hard coded values.
With the current design, it's probably safe to use with a private server and build of the applications, but I don't think the encryption will hold up in a multiuser environment.