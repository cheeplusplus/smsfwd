// SMSFWD by Andrew Koester <andrew@neocodenetworks.com>

package com.neocodenetworks.smsfwd;

import android.content.*;
import android.net.ConnectivityManager;
import android.os.Bundle;
import android.preference.PreferenceManager;
import android.telephony.*;
import android.util.Log;

public class SmsReceiver extends BroadcastReceiver {
	private static final String SMS_RECEIVED = "android.provider.Telephony.SMS_RECEIVED";
	private static final String TAG = "smsfwd";
	
	/**
	 * Reads the phone's phone number.
	 * @param context - Activity context
	 * @return Phone number as string.
	 */
	private String readPhoneNumber(Context context) {
		TelephonyManager manager = (TelephonyManager)context.getSystemService(Context.TELEPHONY_SERVICE);
		return manager.getLine1Number();
	}
	
	/**
	 * Get the background data setting.
	 * @param context - Activity context
	 * @return Background data setting.
	 */
	private boolean getBackgroundDataSetting(Context context) {
		ConnectivityManager manager = (ConnectivityManager)context.getSystemService(Context.CONNECTIVITY_SERVICE);
		return manager.getBackgroundDataSetting();
	}
	
	@Override
	public void onReceive(Context context, Intent intent) {
		SharedPreferences prefs = PreferenceManager.getDefaultSharedPreferences(context);
		
		// Check to see if we're enabled
		if (!prefs.getBoolean("enableFwd", true))
		{
			Log.i(TAG, "SMS message recieved, but smsfwd was disabled by pref. Ignoring.");
			return;
		}
		
		String passphrase = prefs.getString("encryptionKey", "");
		if (passphrase.trim().equals(""))
		{
			Log.i(TAG, "SMS message recieved, but no encryption key was set. Ignoring.");
			UserNotification.NotifyError(context, "smsfwd cannot operate without an encrpytion key. Please set one in smsfwd configuration.", true);
			return;
		}
		
		// Check if background data is allowed
		if (!getBackgroundDataSetting(context)) {
			Log.i(TAG, "SMS message recieved, but background data was turned off. Ignoring.");
			return;
		}
		
		if (intent.getAction().equals(SMS_RECEIVED)) {
			Bundle bundle = intent.getExtras();
			if (bundle != null) {
				Object[] pdus = (Object[])bundle.get("pdus");
				final SmsMessage[] messages = new SmsMessage[pdus.length];
				
				StringBuilder builder = new StringBuilder();
				for (int i = 0; i < pdus.length; i++) {
					messages[i] = SmsMessage.createFromPdu((byte[])pdus[i]);
					builder.append(messages[i].getMessageBody());
				}
				
				if (messages.length > 0) {
					Log.i(TAG, "Valid SMS message was recieved, forwarding.");
					
					String phoneNumber = readPhoneNumber(context);
					Crypto c = new Crypto(passphrase + "//" + phoneNumber);
					String body = c.encryptAsBase64(builder.toString().getBytes());
					
					try {
						NetComm.SendMessage(messages[0].getTimestampMillis() / 1000, phoneNumber, messages[0].getOriginatingAddress(), body);
					}
					catch (NetCommException ex) {
						UserNotification.NotifyError(context, ex.getMessage());
					}
				}
			}
		}
	}
}
