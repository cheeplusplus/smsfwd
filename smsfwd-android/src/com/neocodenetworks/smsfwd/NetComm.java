// SMSFWD by Andrew Koester <andrew@neocodenetworks.com>

package com.neocodenetworks.smsfwd;

import java.io.*;
import java.net.*;
import android.util.Log;

public final class NetComm {
	private static final String _destURL = "http://SERVER/receive.php";
	private static final String _destTags = "?time=%d&to=%s&from=%s&body=%s";
	private static final String TAG = "smsfwd";

    /**
     * Gets the response from the server.
     * @param conn - Connection
     * @return Response string
     */
    private static String getResponse(HttpURLConnection conn)
    {
        try 
        {
            DataInputStream dis = new DataInputStream(conn.getInputStream()); 
            byte[] data = new byte[1024];
            int len = dis.read(data, 0, 1024);

            dis.close();

            if (len > 0)
                return new String(data, 0, len);
            else
                return "";
        }
        catch(IOException e)
        {
            Log.e(TAG, "IOException while reading server response");
            return "";
        }
    }
	
    /**
     * Sends the SMS to the server.
     * @param to - SMS destination
     * @param from - SMS sender
     * @param body - SMS body
     * @return Success/failure
     * @throws NetCommException 
     */
	public static Boolean SendMessage(long time, String to, String from, String body) throws NetCommException {
		//Log.i(TAG, "Disabling HTTPS trust for message send");
		//trustEveryone();
		
		// Prevent connection errors
		System.setProperty("http.keepAlive", "false");
		
		URL url;
		try {
			url = new URL(_destURL + String.format(_destTags, time, to, from, URLEncoder.encode(body)));
		} catch (MalformedURLException e) {
			Log.e(TAG, "MalformedURLException during send", e);
			// Might want to send an error back to the user (likely bad user input)
			throw new NetCommException("Bad URL", e);
			//return false;
		}
		
		//Log.d(TAG, "Sending message to " + url.toString());
		
		HttpURLConnection conn;
		//HttpsURLConnection conn;
		try {
			conn = (HttpURLConnection)url.openConnection();
			//conn = (HttpsURLConnection)url.openConnection();
			conn.connect();
			int responseCode = conn.getResponseCode();
			
			if (responseCode != 200) {
				// Might want to send an error back to the user
				Log.e(TAG, "Response came back HTTP " + String.valueOf(responseCode));
				throw new NetCommException("Bad response from the server.");
				//return false;
			}
		} catch (IOException e) {
			Log.e(TAG, "IOException during send", e);
			throw new NetCommException("Error while talking to the server.", e);
			//return false;
		}
		
		String resp = getResponse(conn);
		conn.disconnect();
		
		if (!resp.equals("Success")) {
			// Might want to send an error back to the user
			Log.e(TAG, "Response came back with message '" + resp + "'");
			throw new NetCommException("Server replied with the message '" + resp + "'");
			//return false;
		}
		
		Log.i(TAG, "SMS message sent to server successfully.");
		return true;
	}
}